using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data.Entities;

namespace API.Models
{
    public class ImageShareDto
    {
        public string Title { get; set; }
        public string ImgAvatar { get; set; }
        public string? ShortDecription { get; set; }
        public string? Content { get; set; }
        public List<DestinationDto> DestinationDtos { get; set; }
        public List<Comment> Comments { get; set; }
        public List<ImageShareDestination> ImageShareDestinations { get; set; }
        public List<Like> Likes { get; set; }
    }
}