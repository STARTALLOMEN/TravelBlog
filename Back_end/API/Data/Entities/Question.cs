using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Data.Entities
{
    public class Question
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdateAt { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public List<ImageQuestion> ImageQuestions { get; set; }
        // public int? DestinationId { get; set; }
        // public Destination? Destination { get; set; }
        public List<QuestionDestination> QuestionDestinations { get; set; }
        public List<Comment> Comments { get; set; }
        public List<Like> Likes { get; set; }
    }
}