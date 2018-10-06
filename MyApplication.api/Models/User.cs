using System.ComponentModel.DataAnnotations;

namespace MyApplication.api.Models
{
    public class User
    {
        public int UserId { get; set; }   
        [Required]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ContactNumber { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public int Age { get; set; }
    }
}