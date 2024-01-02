using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Data.Entities
{
    public class ImageShareDestination
    {
        public int ImageShareId { get; set; }
        public ImageShare ImageShare { get; set; }
        public int DestinationId { get; set; }
        public Destination Destination { get; set; }
    }
}