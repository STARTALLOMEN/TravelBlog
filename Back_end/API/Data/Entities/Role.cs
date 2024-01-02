using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Data.Entities
{
    public class Role
    {
       //[Key]
       [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        public string Name { get; set; }
        public List<User> Users { get; set; }
        public Role(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}