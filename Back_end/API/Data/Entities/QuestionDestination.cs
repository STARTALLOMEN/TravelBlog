using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Data.Entities
{
    public class QuestionDestination
    {
        public int DestinationId { get; set; }
        public Destination Destination { get; set; }
        public int QuestionId { get; set; }
        public Question Question { get; set; }
    }
}