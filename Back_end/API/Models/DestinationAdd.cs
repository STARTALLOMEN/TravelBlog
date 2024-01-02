using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data.Entities;

namespace API.Models
{
    public class DestinationAdd
    {
        public string Name { get; set; }
        public IFormFile ImgAvatarFile { get; set; }
        public string ShortDecription { get; set; }
        public int ProvinceOrAreaOrPrArea { get; set; }
        public string Content { get; set; }
        // public string Status { get; set; }
        // public decimal? NumberStar { get; set; }
        public string? Tips { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string? UrlWebsite { get; set; }
        public string? WhoGoTogether { get; set; }
        public string? TimeRecomment { get; set; }
        public string? TimeVisit { get; set; }
        public int? PriceAdv { get; set; }
        public string? Address { get; set; }
        public string? Logitude { get; set; }
        public string? Latitude { get; set; }
        public int? ProvinceId { get; set; }
        public int? TypeDestinationId { get; set; }
    }
}