using System.ComponentModel.DataAnnotations;

namespace MyApplication.api.Models
{
    public class LoginModel
    {
        [Required]
        [EmailAddress]
        public string EmailId { get; set; }
        [Required]
        public string Password { get; set; }
    }
}