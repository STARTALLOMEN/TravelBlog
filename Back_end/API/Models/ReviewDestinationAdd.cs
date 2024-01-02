using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class ReviewDestinationAdd
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public decimal NumberStar { get; set; }
        public List<IFormFile> ImageReviewsFile { get; set; }
        // public int DestinationId { get; set; }
    }
}