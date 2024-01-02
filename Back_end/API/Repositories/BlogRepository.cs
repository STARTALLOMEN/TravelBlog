using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Text;
using System.Threading.Tasks;
using API.Data;
using API.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace API.Repositories
{
    public class BlogRepository : IBlogRepository
    {
        private readonly DataContext _context;
        public BlogRepository(DataContext context)
        {
            _context = context;
        }
        public List<Blog>? GetAllBlog()
        {
            return _context.Blogs.Include(p => p.BlogDestinations).ThenInclude(o => o.Destination)
                                .ToList();
        }

        public Blog? GetBlogById(int id)
        {
            return _context.Blogs.FirstOrDefault(u => u.Id == id);
        }

        public List<Blog>? GetBlogsByName(string name)
        {
            return _context.Blogs.Where(u => u.Title == name).ToList();
        }
        public Blog? GetBlogByName(string name)
        {
            var query = _context.Blogs
                                    .FirstOrDefault(u => u.Title == name);
            if (query == null)
            {
                query = _context.Blogs.FirstOrDefault(delegate (Blog c)
                {
                    if (ConvertToUnSign(c.Title).IndexOf(name, StringComparison.CurrentCultureIgnoreCase) >= 0)
                        return true;
                    else
                        return false;
                });

            }
            return query;
        }

        public static string RemoveDiacritics(string text)
        {
            string normalizedString = text.Normalize(NormalizationForm.FormD);
            StringBuilder stringBuilder = new StringBuilder();

            for (int i = 0; i < normalizedString.Length; i++)
            {
                UnicodeCategory unicodeCategory = CharUnicodeInfo.GetUnicodeCategory(normalizedString[i]);
                if (unicodeCategory != UnicodeCategory.NonSpacingMark)
                {
                    stringBuilder.Append(normalizedString[i]);
                }
            }

            return stringBuilder.ToString().Normalize(NormalizationForm.FormC);
        }
        private string ConvertToUnSign(string input)
        {
            input = input.Trim();
            for (int i = 0x20; i < 0x30; i++)
            {
                input = input.Replace(((char)i).ToString(), " ");
            }
            Regex regex = new Regex(@"\p{IsCombiningDiacriticalMarks}+");
            string str = input.Normalize(NormalizationForm.FormD);
            string str2 = regex.Replace(str, string.Empty).Replace('đ', 'd').Replace('Đ', 'D');
            while (str2.IndexOf("?") >= 0)
            {
                str2 = str2.Remove(str2.IndexOf("?"), 1);
            }
            return str2;
        }

        // public List<Blog>? GetBlogPopular()
        // {
        //    var top10Blogs = _context.Blogs
        //     .OrderByDescending(t => t.ReviewBlogs.Count())    
        //     .Take(10)
        //     .ToList();

        // return top10Blogs;
        // }

        public void CreateBlog(Blog Blog)
        {
            _context.Blogs.Add(Blog);
            SaveChanges();
            ;
        }
        public bool SaveChanges()
        {
            return (_context.SaveChanges() > 0);
        }

        public List<Blog>? GetBlogByDesId(int id)
        {
            var blogs = _context.Blogs
                                .Where(b => b.BlogDestinations.Any(bd => bd.DestinationId == id))
                                .ToList();


            return blogs;
        }

        public Blog? GetLastBlogByUserId(int userId)
        {
            var lastAddedBlog = _context.Blogs
                                        .Where(q => q.UserId == userId)
                                        .OrderByDescending(q => q.CreatedAt)
                                        .FirstOrDefault();
            return lastAddedBlog;
        }

        public void CreateBlogDestination(int blogId, List<int> desId)
        {
            foreach(int id in desId){
                _context.BlogDestination.Add(new BlogDestination {
                    BlogId = blogId,
                    DestinationId = id
                });
                SaveChanges();
            }
        }
    }
}