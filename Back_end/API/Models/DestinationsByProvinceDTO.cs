using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data.Entities;

namespace API.Models
{
    public class DestinationsByProvinceDTO
    {
        public int ProvinceId { get; set; }
        public string NameProvince { get; set; }
        public string ImageProvince { get; set; }
        public List<DestinationDto> Destinations { get; set; }
    }

}