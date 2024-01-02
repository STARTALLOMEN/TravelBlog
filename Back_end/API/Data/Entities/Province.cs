using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API.Data.Entities
{
    // public enum enumProvince{
    //     Province = 0,
    //     City = 1
    // }
    public class Province
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Destination> Destinations { get; set; }
    }
}