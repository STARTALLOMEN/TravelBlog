using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data.Entities;

namespace API.Models
{
    public class DestinationDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ShortDecription { get; set; }
        public string ProvinceOrAreaOrPrArea{ get; set; }
        public string Content { get; set; }
        public string Tips { get; set; }
        public decimal NumberStar { get; set; }
        // public StatusDestination Status { get; set; }
        public string Status { get; set; }
        public string TimeOpen { get; set; }
        public string TimeClose { get; set; }
        public string ImgAvatar { get; set; }
        public int NumberReviewers { get; set; }
        public string Address { get; set; }
        public string Logitude { get; set; }
        public string Latitude { get; set; }
        public UserDto UserDto { get; set; }
        public int? TypeDestinationId { get; set; }
        public int? ProvinceId { get; set; }
        public string NameProvince { get; set; }
    }
}