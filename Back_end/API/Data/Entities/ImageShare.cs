using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Data.Entities
{
    public class ImageShare
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ImageAvatar { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdateAt { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public List<Comment> Comments { get; set; }
        public List<ImageShareDetail> ImageShareDetails { get; set; }
        public List<ImageShareDestination> ImageShareDestinations { get; set; }
        public List<Like> Likes { get; set; }
    }
}