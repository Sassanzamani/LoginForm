using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace LoginForm.Models
{
    public class UserInfo
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public int  RoleID { get; set; }
        public int UserID { get; set; }
        public string Mobile { get; set; }
    }
}
