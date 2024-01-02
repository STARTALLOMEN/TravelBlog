using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class RegisterDto
    {
        [Required(ErrorMessage = "Bạn cần nhập Firstname.")]
        public string Firstname { set; get; }
        [Required(ErrorMessage = "Bạn cần nhập LastName.")]
        public string LastName { set; get; }

        [Required(ErrorMessage = "Bạn cần nhập username.")]
        public string UserName { set; get; }

        [Required(ErrorMessage = "Bạn cần nhập password.")]
        [MinLength(6, ErrorMessage = "Password phải có ít nhất 6 ký tự")]
        public string Password { set; get; }

        [Required(ErrorMessage = "Bạn cần nhập password.")]
        [MinLength(6, ErrorMessage = "Password phải có ít nhất 6 ký tự")]
        public string ConfirmPassword { set; get; }

    //     [Phone]
    //     [Required(ErrorMessage = "Bạn cần nhập số điện thoại.")]
    //     public string Phone { set; get; }

    //     [EmailAddress]
    //     [Required(ErrorMessage = "Bạn cần nhập email.")]
    //     public string Email { set; get; }
    }
}

