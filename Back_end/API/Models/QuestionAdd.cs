using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class QuestionAdd
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public List<IFormFile> ImageQuestionsFile { get; set; }
        public List<int> DesId { get; set; }
    }
}