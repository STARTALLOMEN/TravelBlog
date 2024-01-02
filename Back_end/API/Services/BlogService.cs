using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using API.Data.Entities;
using API.Models;
using API.Repositories;

namespace API.Services
{
    public class BlogService : IBlogService
    {
        private readonly IBlogRepository _repository;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IUploadImgService _uploadImgService;

        public BlogService(IBlogRepository repository, IUserRepository userRepository, IMapper mapper, IUploadImgService uploadImgService)
        {
            _repository = repository;
            _userRepository = userRepository;
            _mapper = mapper;
            _uploadImgService = uploadImgService;

        }

        public void CreateBlog(BlogAdd Blogadd, string username)
        {
            var user = _userRepository.GetUserByUsername(username);
            var blog = _mapper.Map<BlogAdd, Blog>(Blogadd);
            var linkImage = _uploadImgService.UploadImage("BlogImage", username, Blogadd.ImgAvatarFile);
            blog.UserId = user.Id;
            blog.ImgAvatar = linkImage.Result;
            blog.CreatedAt = DateTime.Now;
            blog.UpdateAt = DateTime.Now;
            _repository.CreateBlog(blog);
            var lastQues = _repository.GetLastBlogByUserId(user.Id);
            if (Blogadd.DesId != null)
            {
                _repository.CreateBlogDestination(lastQues.Id, Blogadd.DesId);
            }

        }

        public List<Blog>? GetAllBlog()
        {
            return _repository.GetAllBlog();
        }

        public Blog? GetBlogById(int id)
        {
            return _repository.GetBlogById(id);
        }

        public Blog? GetBlogByName(string name)
        {
            return _repository.GetBlogByName(name);
        }

        public List<Blog>? GetBlogsByName(string name)
        {
            return _repository.GetBlogsByName(name);
        }

        public List<BlogDto>? GetBlogsOfDestination(int desId)
        {
            var listBlog = _repository.GetAllBlog();
            var listBlogDes = new List<BlogDto>();
            if (listBlog != null)
            {
                foreach (var blog in listBlog)
                {
                    foreach (var blogdDes in blog.BlogDestinations)
                    {
                        if (blogdDes.DestinationId == desId)
                        {
                            listBlogDes.Add(_mapper.Map<Blog, BlogDto>(blog));
                        }
                    }
                }
            }
            return listBlogDes;
        }
    }
}