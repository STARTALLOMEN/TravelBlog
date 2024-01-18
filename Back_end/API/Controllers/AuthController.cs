using System.Security.Cryptography;
using System.Text;
using API.Data.Entities;
using API.Models;
using API.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Identity;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase

    {
        private readonly ITokenService _tokenService;
        private readonly IUserService _userService;
        private readonly EmailSevice _emailService;
        public AuthController(ITokenService tokenService, IUserService userService, EmailSevice emailService)
        {
            _tokenService = tokenService;
            _userService = userService;
            _emailService = emailService;

        }

        [HttpPost("register")]
        public IActionResult Register([FromBody] RegisterDto register)
        {
            try
            {
                var username = register.UserName.ToLower();
                if (_userService.GetUserByUsername(username) != null)
                {
                    var fail = new MessageReturn
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
                    Phone = register.Phone,
                    Email = register.Email,
                    Firstname = register.Firstname,
                    LastName = register.LastName,
                    PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(register.Password)),
                    PasswordSalt = hmac.Key,
                    CreateAt = DateTime.Now,
                    UpdateAt = DateTime.Now,
                    Avatar = "https://firebasestorage.googleapis.com/v0/b/pbl6-b8cad.appspot.com/o/pbl6%2Favatar%2FAvataDefault%2FAvataDefault.jpg?alt=media&token=1c8be063-80ae-4eef-b0c0-7af84999bdb9&fbclid=IwAR3Vq7RhVsB46Knuo-hyfWyn_XkTgfCI8_u0a_DQTtQAf5D7AcSa9wor6b4",
                    Logitude = null,
                    Latitude = null,
                    Destinations = new List<Destination>(),
                    News = new List<News>(),
                    ReviewDestinations = new List<ReviewDestination>(),
                    Comments = new List<Comment>(),
                    Questions = new List<Question>(),
                    Likes = new List<Like>()
                };
                _userService.CreateUser(user);
                _userService.SaveChanges();
                var token = _tokenService.CreateToken(user);
                return Ok(new TokenDto()
                {
                    AccessToken = token
                });
            }
            catch (Exception ex) when (ex is BadHttpRequestException || ex is UnauthorizedAccessException)
            {
                var message = new Dictionary<string, string>
                {
                    ["Message"] = ex.Message
                };
                return BadRequest(message);
            }
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginDto login)
        {
            try
            {
                var user = _userService.GetUserByUsername(login.UserName);
                if (user == null)
                {
                    var fail = new MessageReturn
                    {
                        StatusCode = enumMessage.Fail,
                        Message = "Username không đúng."
                    };
                    return Ok(fail);
                }

                using var hmac = new HMACSHA512(user.PasswordSalt);
                var computeHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(login.Password));
                for (var i = 0; i < computeHash.Length; i++)
                {
                    if (computeHash[i] != user.PasswordHash[i])
                    {
                        var fail = new MessageReturn
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
                var message = new Dictionary<string, string>
                {
                    ["Message"] = ex.Message
                };
                return BadRequest(message);
            }
        }
        [HttpPost("forgotPassword")]
        public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordRequest model)
        {
            try
            {
                var user = _userService.GetUserByUsername(model.UserName);
                if (user == null)
                {
                    var fail = new MessageReturn
                    {
                        StatusCode = enumMessage.Fail,
                        Message = "Username không đúng."
                    };
                    return Ok(fail);
                }


                var token = _tokenService.CreateToken(user);
                var passwordResetLink = Url.Action("ResetPassword", "Auth",
            new { email = model.Email, token = token }, Request.Scheme);


                _emailService.SendEmail(model.Email, "Password Reset", $"Click here to reset your password: {passwordResetLink}");


                return Ok(new TokenDto
                {
                    AccessToken = token
                });
            }
            catch (UnauthorizedAccessException ex)
            {
                var message = new Dictionary<string, string>
                {
                    ["Message"] = ex.Message
                };
                return BadRequest(message);
            }
        }

        //[HttpPost("resetPassword")]
        //public IActionResult ResetPassword([FromBody] ResetPasswordRequest model)
        //{
        //    var user = _userService.FindByEmailAsync(model.Email);
        //    if (user == null)
        //    {
        //        // Don't reveal that the user does not exist
        //        return BadRequest("Invalid Request");
        //    }

        //    var result = _userService.ResetPasswordAsync(user, model.Token, model.Password);
        //    if (result.Succeeded)
        //    {
        //        return Ok();
        //    }

        //    return BadRequest("Error resetting password");
        //}


    }
}