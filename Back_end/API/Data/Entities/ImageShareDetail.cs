using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Data.Entities
{
    public class ImageShareDetail
    {
        public int Id { get; set; }
        public string Image { get; set; }
        // public string Caption { get; set; }
        public int ImageShareId { get; set; }
        public ImageShare ImageShare { get; set; }
    }
}