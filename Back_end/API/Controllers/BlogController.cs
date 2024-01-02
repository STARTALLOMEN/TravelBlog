using System.Security.Claims;
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
    public class BlogController : ControllerBase
    {
        private readonly IBlogService _BlogService;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        public BlogController(IBlogService BlogService, IUserService userService, IMapper mapper)
        {
            _BlogService = BlogService;
            _userService = userService;
            _mapper = mapper;
        }
        [HttpGet("")]
        public ActionResult<List<BlogDto>> GetAllBlog()
        {
            var listBlog = _BlogService.GetAllBlog();
            return _mapper.Map<List<Blog>, List<BlogDto>>(listBlog);
        }

        [HttpGet("{name}")]
        public ActionResult<BlogDto> GetBlog(string name)
        {
            var Blog = _BlogService.GetBlogByName(name);
            return _mapper.Map<Blog, BlogDto>(Blog);
        }

        [Authorize(Roles = "admin, user")]
        [HttpPost("")]
        public ActionResult<string> Post([FromForm] BlogAdd BlogAdd)
        {
            var des = BlogAdd;
            try
            {
                var username = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
                _BlogService.CreateBlog(BlogAdd,username);
                MessageReturn success = new MessageReturn()
                {
                    StatusCode = enumMessage.Success,
                    Message = "Thêm Blog thành công"
                };
                return Ok(success);
            }
            catch(Exception ex)
            {
                MessageReturn fail = new MessageReturn()
                {
                    StatusCode = enumMessage.Fail,
                    Message = "Thêm Blog thất bại."
                };
                return Ok(fail);
            }
        }

        [HttpGet("Destination/{id}")]
        public ActionResult<List<BlogDto>> GetBlogByDesId(int id)
        {
            var Blog = _BlogService.GetBlogsOfDestination(id);
            return Blog;
        }

        [HttpGet("{id}/blogDetail")]
        public ActionResult<BlogDto> GetBlogById(int id)
        {
            var Blog = _BlogService.GetBlogById(id);
            return _mapper.Map<Blog, BlogDto>(Blog);
        }
        
    }
}