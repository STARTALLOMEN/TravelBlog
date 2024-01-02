using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using API.Data.Entities;
using API.Models;
using API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }


        [HttpGet]
        public ActionResult<IEnumerable<UserDto>> Get()
        {
            try
            {
                return Ok(_userService.GetAllUser());
            }
            catch
            {
                return null;
            }
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, UserDto userDto)
        {
            if (_userService.UpdateUser(userDto))
            {
                MessageReturn succcess = new MessageReturn()
                {
                    StatusCode = enumMessage.Success,
                    Message = "Cập nhật thành công."
                };
                return Ok(succcess);
            }
            else
            {
                MessageReturn fail = new MessageReturn()
                {
                    StatusCode = enumMessage.Fail,
                    Message = "Cập nhật thất bại."
                };
                return Ok(fail);
            }
        }

        [Authorize(Roles = "admin, user")]
        [HttpPost("/api/Plan/add")]
        public ActionResult<string> Post([FromForm] PlanAdd PlanAdd)
        {
            var des = PlanAdd;
            try
            {
                var username = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
                _userService.CreatePan(PlanAdd, username);
                MessageReturn success = new MessageReturn()
                {
                    StatusCode = enumMessage.Success,
                    Message = "Thêm Plan thành công"
                };
                return Ok(success);
            }
            catch (Exception ex)
            {
                MessageReturn fail = new MessageReturn()
                {
                    StatusCode = enumMessage.Fail,
                    Message = "Thêm Plan thất bại."
                };
                return Ok(fail);
            }
        }

        [Authorize(Roles = "admin, user")]
        [HttpGet("/api/Plan/get")]
        public ActionResult<IEnumerable<PlanDto>> GetPlanBuUserId()
        {
            try
            {
                var username = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
                var plan = _userService.GetPLanByUserId(username);
                MessageReturn success = new MessageReturn()
                {
                    StatusCode = enumMessage.Success,
                    Message = "Get Plan thành công"
                };
                return plan;
            }
            catch (Exception ex)
            {
                MessageReturn fail = new MessageReturn()
                {
                    StatusCode = enumMessage.Fail,
                    Message = "Get Plan thất bại."
                };
                return Ok(fail);
            }
        }

        [Authorize(Roles = "admin, user")]
        [HttpPost("/api/Plan/addPlanDes")]
        public ActionResult<string> PostPlan([FromForm] PlanDestinationAdd planDestinationAdd)
        {
            try
            {
                var username = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
                _userService.CreatePlanDestination(planDestinationAdd.PlanId, planDestinationAdd.DesId);
                MessageReturn success = new MessageReturn()
                {
                    StatusCode = enumMessage.Success,
                    Message = "Thêm PlanDes thành công"
                };
                return Ok(success);
            }
            catch (Exception ex)
            {
                MessageReturn fail = new MessageReturn()
                {
                    StatusCode = enumMessage.Fail,
                    Message = "Thêm PlanDes thất bại."
                };
                return Ok(fail);
            }
        }


    }
}