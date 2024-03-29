using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class LoginDto
    {
        [Required(ErrorMessage ="Bạn cần nhập username")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Bạn cần nhập password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

    }
}