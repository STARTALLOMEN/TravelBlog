using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Data.Entities
{
    public class ImageReview
    {
        public int Id { get; set; }
        public string Image { get; set; }
        public int? ReviewDestinationId { get; set; }
        public ReviewDestination? ReviewDestination { get; set; }
    }
}