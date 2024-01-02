using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data.Entities;

namespace API.Models
{
    public class PlanDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdateAt { get; set; }
        public int UserId { get; set; }
        public UserDto UserDto { get; set; }
        public List<DestinationDto> DestinationDtos { get; set; }

    }
}