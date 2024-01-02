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
    public class QuestionController : ControllerBase
    {
        private readonly IQuestionService _QuestionService;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        public QuestionController(IQuestionService QuestionService, IUserService userService, IMapper mapper)
        {
            _QuestionService = QuestionService;
            _userService = userService;
            _mapper = mapper;
        }
        [HttpGet("")]
        public ActionResult<List<QuestionDto>> GetAllQuestion()
        {
            var listQuestion = _QuestionService.GetAllQuestion();
            return _mapper.Map<List<Question>, List<QuestionDto>>(listQuestion);
        }

        [HttpGet("{name}")]
        public ActionResult<QuestionDto> GetQuestion(string name)
        {
            var Question = _QuestionService.GetQuestionByName(name);
            return _mapper.Map<Question, QuestionDto>(Question);
        }

        [Authorize(Roles = "admin, user")]
        [HttpPost("")]
        public ActionResult<string> Post([FromForm] QuestionAdd QuestionAdd)
        {
            var des = QuestionAdd;
            try
            {
                var username = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
                _QuestionService.CreateQuestion(QuestionAdd,username);
                MessageReturn success = new MessageReturn()
                {
                    StatusCode = enumMessage.Success,
                    Message = "Thêm câu hỏi thành công"
                };
                return Ok(success);
            }
            catch(Exception ex)
            {
                MessageReturn fail = new MessageReturn()
                {
                    StatusCode = enumMessage.Fail,
                    Message = "Thêm câu hỏi thất bại."
                };
                return BadRequest();
            }
        }

        [HttpGet("{id}")]
        public ActionResult<QuestionDto> GetDestinationById(int id)
        {
            var ques = _QuestionService.GetQuestionById(id);
            return ques;
        }
        [HttpGet("/Destionation/{id}/question")]
        public ActionResult<List<QuestionDto>> GetQuestionsByDesId(int id)
        {
            var ques = _QuestionService.GetQuestionByDesId(id);
            return ques;
        }
    }
}