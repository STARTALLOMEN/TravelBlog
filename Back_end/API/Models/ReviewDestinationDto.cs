using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class ReviewDestinationDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public decimal NumberStar { get; set; }
        public string WhenGo { get; set; }
        public string WhoGoTogether { get; set; }
        public string TimeVisitRecomment { get; set; }
        public int UserId { get; set; }
        public UserDto User { get; set; }
        public int DestinationId { get; set; }
        public DestinationDto Destination { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdateAt { get; set; }
       
    }
}