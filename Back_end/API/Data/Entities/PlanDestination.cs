using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Data.Entities
{
    public class PlanDestination
    {
        public int PlanId { get; set; }
        public Plan Plan { get; set; }
        public int DestinationId { get; set; }
        public Destination Destination { get; set; }
    }
}