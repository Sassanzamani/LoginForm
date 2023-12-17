using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;

namespace LoginForm.Models
{
    public class UserInfo
    {
        [Required]
        [Display(Name = "Full name")]
        public string? FullName { get; set; }
        [Required]
        [Display(Name = "Email")]
        public string? Email { get; set; }
        [Required]
        [Display(Name = "Address")]
        public string? Address { get; set; }
        [Required]
        [Display(Name = "Role ID")]
        public int RoleID { get; set; }
        [Required]
        [Display(Name = "User ID")]
        public int UserID { get; set; }
        [Required]
        [Display(Name = "Cell phone number")]
        public string? Tel { get; set; }
    }
}
