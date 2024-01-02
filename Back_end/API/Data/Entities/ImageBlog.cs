using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Data.Entities
{
    public class ImageBlog
    {
        public int Id { get; set; }
        public string Image { get; set; }
        public int BlogId { get; set; }
        public Blog Blog { get; set; }
    }
}