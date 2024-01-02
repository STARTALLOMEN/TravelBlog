using System.Security.Cryptography;
using System.Text;
using API.Data.Entities;
using API.Models;
using API.Services;
using Microsoft.AspNetCore.Mvc;
using API.Models;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ITokenService _tokenService;
        private readonly IUserService _userService;
        public AuthController(ITokenService tokenService, IUserService userService)
        {
            _tokenService = tokenService;
            _userService = userService;
        }

        [HttpPost("register")]
        public IActionResult Register([FromBody] RegisterDto register)
        {
            try
            {
                var username = register.UserName.ToLower();
                if(_userService.GetUserByUsername(username) != null){
                    MessageReturn fail = new MessageReturn()
                    {
                        StatusCode = enumMessage.Fail,
                        Message = "Username đã tồn tại."
                    };
                    return Ok(fail);
                }

                using var hmac = new HMACSHA512();

                var user = new User
                {
                    Username = register.UserName,
                    Phone = null,
                    Email = null,
                    Firstname = register.Firstname,
                    LastName = register.LastName,
                    PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(register.Password)),
                    PasswordSalt = hmac.Key,
                    CreateAt = DateTime.Now,
                    UpdateAt = DateTime.Now,
                    Avatar = "https://firebasestorage.googleapis.com/v0/b/pbl6-b8cad.appspot.com/o/pbl6%2Favatar%2FAvataDefault%2FAvataDefault.jpg?alt=media&token=1c8be063-80ae-4eef-b0c0-7af84999bdb9&fbclid=IwAR3Vq7RhVsB46Knuo-hyfWyn_XkTgfCI8_u0a_DQTtQAf5D7AcSa9wor6b4",
                    Logitude = null,
                    Latitude = null,
                    Destinations = null,
                    News = null,
                    ReviewDestinations = null,
                    Comments = null,
                    Questions = null,
                    Likes = null
                };
                _userService.CreateUser(user);
                _userService.SaveChanges();
                var token = _tokenService.CreateToken(user);
                return Ok(new TokenDto()
                {
                    AccessToken = token
                });
            }
            catch (BadHttpRequestException ex)
            {
                Dictionary<string, string> message = new Dictionary<string, string>();
                message.Add("Message", ex.ToString());
                return BadRequest(message);
                //return Unauthorized(ex.Message);
            }
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginDto login)
        {
            try
            {
                // return Ok(_authService.Login(authUserDto));
                var user = _userService.GetUserByUsername(login.UserName);
                if(user == null) {
                    MessageReturn fail = new MessageReturn()
                    {
                        StatusCode = enumMessage.Fail,
                        Message = "Username không đúng."
                    };
                    return Ok(fail);
                    // return Unauthorized("Username is invalid.");
                } 
                
                using var hmac = new HMACSHA512(user.PasswordSalt);
                var computeHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(login.Password));
                for( var i = 0; i < computeHash.Length; i++){
                    if(computeHash[i] != user.PasswordHash[i]){
                        MessageReturn fail = new MessageReturn()
                        {
                            StatusCode = enumMessage.Fail,
                            Message = "Password không đúng."
                        };
                        return Ok(fail);
                    } 
                }
                var token = _tokenService.CreateToken(user);
                return Ok(new TokenDto()
                {
                    AccessToken = token
                });
            }
            catch (UnauthorizedAccessException ex)
            {
                // Dictionary<string, string> message = new Dictionary<string, string>();
                // message.Add("Message", ex.Message);
                return BadRequest(ex);
            }
        }
    }
}