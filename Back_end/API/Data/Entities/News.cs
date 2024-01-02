using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Data.Entities
{
    public class News
    {
        public int Id { get; set; }
        public int Views { get; set; }
        public string Name { get; set; }
        public bool Status { get; set; }
        public string Content { get; set; }
        public string ImgAvatar { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdateAt { get; set; }
        public List<Comment> Comments { get; set; }
    }
}