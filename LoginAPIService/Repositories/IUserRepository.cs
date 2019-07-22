using LoginAPIService.Models.DB;
using System.Threading;
using System.Threading.Tasks;

namespace LoginAPIService.Repositories
{
    public interface IUserRepository
    {
        Task<bool> IsValidUser(string userName, string password, CancellationToken ct = default(CancellationToken));
        Task<UserLogin> GetUserDetails(string userName, CancellationToken ct = default(CancellationToken));
    }
}
