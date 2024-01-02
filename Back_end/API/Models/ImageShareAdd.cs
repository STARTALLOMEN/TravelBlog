using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data.Entities;

namespace API.Models
{
    public class ImageShareAdd
    {
        public string Title { get; set; }
        public IFormFile ImgAvatarFile { get; set; }
        public List<IFormFile> ListImgShareFile { get; set; }
        public List<int>? DesId { get; set; }
        public string? ShortDecription { get; set; }
    }
}