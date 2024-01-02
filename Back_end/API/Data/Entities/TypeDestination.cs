using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API.Data.Entities
{
    public class TypeDestination
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Destination> Destinations { get; set; }
        public TypeDestination(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}