using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Data.Entities
{
    public class ReviewDestination
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public decimal NumberStar { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int DestinationId { get; set; }
        public Destination Destination { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdateAt { get; set; }
        public List<Comment> Comments { get; set; }
        public List<ImageReview> ImageReviews { get; set; }
    }
}