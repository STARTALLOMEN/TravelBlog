using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class ForgotPasswordRequest
    {
        [Required]
        [EmailAddress]
        public string? UserName { get; set; }
        public string? Email { get; set; }
    }
}
