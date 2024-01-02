using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Data.Entities
{
    public enum enumComment{
        commentBlog = 0,
        commentQuestion = 1,
        commentReview = 2
    }
    public enum enumStatusDelOrEx{
        Delete = 0,
        Exist = 1
    }
    public class Comment
    {
        public int Id { get; set; }
        public enumComment TypeComment { get; set; }
        public int ParentCommentId { get; set; }
        public int Likes { get; set; }
        public int Dislikes { get; set; }
        public enumStatusDelOrEx enumStatus { get; set; }
        public string Content { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int? BlogId { get; set; }
        public Blog? Blog { get; set; }
        public int? QuestionId { get; set; }
        public Question? Question { get; set; }
        public int? ReviewDestinationId { get; set; }
        public ReviewDestination? ReviewDestination { get; set; }
        public int? NewId { get; set; }
        public News? News { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdateAt { get; set; }
    }
}