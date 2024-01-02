using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data.Entities;
using API.Models;

namespace API.Services
{
    public interface IBlogService
    {
        List<Blog>? GetAllBlog();
        Blog? GetBlogById(int id);
        List<Blog>? GetBlogsByName(string name);
        Blog? GetBlogByName(string name);
        List<BlogDto>? GetBlogsOfDestination(int desId);
        void CreateBlog(BlogAdd Blog, string username);
    }
}