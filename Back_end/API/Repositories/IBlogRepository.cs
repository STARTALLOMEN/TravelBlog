using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data.Entities;

namespace API.Repositories
{
    public interface IBlogRepository
    {
        List<Blog>? GetAllBlog();
        Blog? GetBlogById(int id);
        List<Blog>? GetBlogByDesId(int id);
        List<Blog>? GetBlogsByName(string name);
        Blog? GetBlogByName(string name);
        // List<Blog>? GetBlogPopular();
        void CreateBlog(Blog Blog);
        bool SaveChanges();
        Blog? GetLastBlogByUserId(int userId);
        void CreateBlogDestination(int blogId, List<int> desId);
    }
}