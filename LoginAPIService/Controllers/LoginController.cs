using LoginAPIService.Repositories;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace LoginAPIService.Controllers
{
    [Route("api/[controller]/[action]")]
    [EnableCors("projectAllowSpecificOrigins")]
    public class LoginController : Controller
    {

        private readonly IUserRepository _Repository;
        public LoginController(IUserRepository userRepository)
        {
            _Repository = userRepository;
        }
        [EnableCors("projectAllowSpecificOrigins")]
        [HttpGet]
        public async Task<IActionResult> IsValidUser(string userName, string password, CancellationToken ct = default(CancellationToken))
        {
            try
            {
                return new ObjectResult(await _Repository.IsValidUser(userName,password,ct));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }          
        }

        [EnableCors("projectAllowSpecificOrigins")]
        [HttpGet]
        public async Task<IActionResult> GetUserDetails(string userName, CancellationToken ct = default(CancellationToken))
        {
            try
            {
                return new ObjectResult(await _Repository.GetUserDetails(userName, ct));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }

        }

    }
}