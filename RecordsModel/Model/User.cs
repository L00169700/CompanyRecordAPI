using System.ComponentModel.DataAnnotations;

namespace RecordsModel.Model
{
    public class User
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "The Username must be less then 50 characters")]
        public string Username { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "The Password  must be less then 50 characters")]
        public string Password { get; set; }
    }
}
