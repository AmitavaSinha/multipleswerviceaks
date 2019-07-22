using LoginAPIService.Models.DB;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace LoginAPIService.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IRAS_UserDBContext _context;
        public UserRepository(IRAS_UserDBContext context)
        {
            _context = context;
        }

        public async Task<bool> IsValidUser(string userName, string password, CancellationToken ct = default(CancellationToken))
        {
            UserLogin userLogin = new UserLogin();

            await Task.Run(() =>
            {
                userLogin = _context.UserLogin.Where(a => a.UserName.Equals(userName) && a.UserPassword.Equals(password)).FirstOrDefault();
            });

            if (userLogin != null)
            {
                return true;
            }

            return false;
        }

        public async Task<UserLogin> GetUserDetails(string userName, CancellationToken ct = default(CancellationToken))
        {
            UserLogin userLogin = new UserLogin();
            await Task.Run(() =>
            {
                userLogin = _context.UserLogin.Where(a => a.UserName.Equals(userName)).FirstOrDefault();
            });

            return userLogin;
        }
    }
}
