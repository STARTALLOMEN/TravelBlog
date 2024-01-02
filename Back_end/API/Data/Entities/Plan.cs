using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Data.Entities
{
    public class Plan
    {
        public int Id { get; set; }
        //0:Private, 1:Public
        // public bool Scope { get; set; }
        public string Title { get; set; }
        // public string? Desc { get; set; }
        // 1:date. 2:dd/mm/yy
        // public DateTime? StartDate { get; set; }
        // public DateTime? EndDate { get; set; }
        // public int? TotalDays { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdateAt { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public List<PlanDestination> PlanDestinations { get; set; }
    }
}