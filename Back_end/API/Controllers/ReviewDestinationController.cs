using System;
using System.Collections.Generic;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using API.Data.Entities;
using API.Models;
using API.Services;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewDestinationController : ControllerBase
    {
        private readonly IReviewDestinationService _ReviewDestinationService;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        public ReviewDestinationController(IReviewDestinationService ReviewDestinationService, IUserService userService, IMapper mapper)
        {
            _ReviewDestinationService = ReviewDestinationService;
            _userService = userService;
            _mapper = mapper;
        }
        [HttpGet("")]
        public ActionResult<List<ReviewDestinationDto>> GetAllReviewDestination()
        {
            var listReviewDestination = _ReviewDestinationService.GetAllReviewDestination();
            return _mapper.Map<List<ReviewDestination>, List<ReviewDestinationDto>>(listReviewDestination);
        }

        // [HttpGet("{name}")]
        // public ActionResult<ReviewDestinationDto> GetReviewDestination(string name)
        // {
        //     var ReviewDestination = _ReviewDestinationService.GetReviewDestinationByName(name);
        //     return _mapper.Map<ReviewDestination, ReviewDestinationDto>(ReviewDestination);
        // }

        [Authorize(Roles = "admin, user")]
        [HttpPost("Destination/{id}")]
        public ActionResult<string> Post([FromForm] ReviewDestinationAdd ReviewDestinationAdd, int id)
        {
            var des = ReviewDestinationAdd;
            try
            {
                var username = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
                _ReviewDestinationService.CreateReviewDestination(ReviewDestinationAdd,username, id);
                MessageReturn success = new MessageReturn()
                {
                    StatusCode = enumMessage.Success,
                    Message = "Thêm review thành công"
                };
                return Ok(success);
            }
            catch(Exception ex)
            {
                MessageReturn fail = new MessageReturn()
                {
                    StatusCode = enumMessage.Fail,
                    Message = "Thêm review thất bại."
                };
                return BadRequest();
            }
        }

        // [HttpGet("{id}")]
        // public ActionResult<ReviewDestinationDto> GetDestinationById(int id)
        // {
        //     var ques = _ReviewDestinationService.GetReviewDestinationById(id);
        //     return ques;
        // }
        // [HttpGet("/Destionation/{id}/ReviewDestination")]
        // public ActionResult<List<ReviewDestinationDto>> GetReviewDestinationsByDesId(int id)
        // {
        //     var ques = _ReviewDestinationService.GetReviewDestinationByDesId(id);
        //     return ques;
        // }
    }
}