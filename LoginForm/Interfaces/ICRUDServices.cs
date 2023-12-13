using LoginForm.Models;

namespace LoginForm.Interfaces
{
    public interface ICRUDServices
    {
        Task<List<UserInfo>> GetUsersAsync();
    }
}
 