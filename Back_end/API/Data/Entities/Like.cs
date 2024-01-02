using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Data.Entities
{
    public enum enumLikes{
        Blog = 0,
        Question = 1,
        ImageShare = 2
    }
    public class Like
    {
        public int Id { get; set; }
        public int NumberUserLike { get; set; }
        public enumLikes TypeLike { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int? BlogId { get; set; }
        public Blog? Blog { get; set; }
        public int? QuestionId { get; set; }
        public Question? Question { get; set; }
        public int? ImageShareId { get; set; }
        public ImageShare? ImageShare { get; set; }

    }
}