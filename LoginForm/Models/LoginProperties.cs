using System.ComponentModel.DataAnnotations;

namespace LoginForm.Models
{
    public class LoginProperties
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        public int UserID { get; set; }
        public DateTime Date { get; set; }
    }
}
