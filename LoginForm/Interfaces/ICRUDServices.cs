using LoginForm.Models;
using System.Collections.ObjectModel;

namespace LoginForm.Interfaces
{
    public interface ICRUDServices
    {
        Task<List<UserInfo>> GetUsersAsync();
        Task<List<LoginProperties>> CheckLoginInfoAsync(LoginProperties loginProperties);
        Task<IQueryable<UserInfo>> SearchUserAsync(UserInfo userInfo);
    }
}
 