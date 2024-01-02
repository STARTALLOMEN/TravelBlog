using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Data.Entities
{
    public class ImageQuestion
    {
        public int Id { get; set; }
        public string Images { get; set; }
        public int QuestionId { get; set; }
        public Question Question { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdateAt { get; set; }   
    }
}