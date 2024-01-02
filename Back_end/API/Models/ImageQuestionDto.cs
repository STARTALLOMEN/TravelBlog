


using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data.Entities;

namespace API.Models
{
    public class ImageQuestionDto
    {
        public int Id { get; set; }
        public string Images { get; set; }
        public int QuestionId { get; set; }
    }
}