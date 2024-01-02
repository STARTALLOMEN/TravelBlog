using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Data.Entities
{
    public class ImageDestination
    {
        public int Id { get; set; }
        public string Images { get; set; }
        //public int UserId { get; set; }
        //public User User { get; set; }
        public int DestinationId { get; set; }
        public Destination Destination { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdateAt { get; set; }
    }
}