using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Data.Entities
{
    public class Blog
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ImgAvatar { get; set; }
        public string? ShortDecription { get; set; }
        public string? Content { get; set; }
        public DateTime? DateStart { get; set; }
        public int? TotalDate { get; set; }
        public int? Cost { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdateAt { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        // public int DestinationId { get; set; }
        // public Destination Destination { get; set; }
        public List<Comment> Comments { get; set; }
        public List<ImageBlog> ImageBlogs{ get; set; }
        public List<Like> Likes { get; set; }
        public List<BlogDestination> BlogDestinations { get; set; }
    }
}