using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;

namespace LoginForm.Models
{
    public class UserInfo
    {
        [Required]
        public string FullName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public int RoleID { get; set; }
        [Required]
        public int UserID { get; set; }
        [Required]
        public string Tel { get; set; }
    }
}
