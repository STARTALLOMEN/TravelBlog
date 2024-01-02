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
    public class ImageShareController : ControllerBase
    {
        private readonly IImageShareService _ImageShareService;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        public ImageShareController(IImageShareService ImageShareService, IUserService userService, IMapper mapper)
        {
            _ImageShareService = ImageShareService;
            _userService = userService;
            _mapper = mapper;
        }
        [HttpGet("")]
        public ActionResult<List<ImageShareDto>> GetAllImageShare()
        {
            var listImageShare = _ImageShareService.GetAllImageShare();
            return _mapper.Map<List<ImageShare>, List<ImageShareDto>>(listImageShare);
        }

        [HttpGet("{name}")]
        public ActionResult<ImageShareDto> GetImageShare(string name)
        {
            var ImageShare = _ImageShareService.GetImageShareByName(name);
            return _mapper.Map<ImageShare, ImageShareDto>(ImageShare);
        }

        [Authorize(Roles = "admin, user")]
        [HttpPost("")]
        public ActionResult<string> Post([FromForm] ImageShareAdd ImageShareAdd)
        {
            var des = ImageShareAdd;
            try
            {
                var username = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
                _ImageShareService.CreateImageShare(ImageShareAdd,username);
                MessageReturn success = new MessageReturn()
                {
                    StatusCode = enumMessage.Success,
                    Message = "Chia sẻ thành công"
                };
                return Ok(success);
            }
            catch(Exception ex)
            {
                MessageReturn fail = new MessageReturn()
                {
                    StatusCode = enumMessage.Fail,
                    Message = "Chia sẻ thất bại."
                };
                return BadRequest();
            }
        }
    }
}