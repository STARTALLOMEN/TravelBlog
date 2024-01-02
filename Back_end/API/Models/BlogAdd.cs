using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data.Entities;

namespace API.Models
{
    public class BlogAdd
    {
        public string Title { get; set; }
        public IFormFile ImgAvatarFile { get; set; }
        public string? ShortDecription { get; set; }
        public string? Content { get; set; }
        public DateTime? DateStart { get; set; }
        public int? TotalDate { get; set; }
        public int? Cost { get; set; }
        public List<int> DesId { get; set; }

    }
}