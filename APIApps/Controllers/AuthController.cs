using APIApps.Models;
using APIApps.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIApps.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly SecurityService securityService;

        public AuthController(SecurityService securityService)
        {
            this.securityService = securityService;
        }
        [HttpPost]
        [ActionName("register")]
        public async Task<SecureResponse> Register(RegisterUser user)
        {
            SecureResponse response = new SecureResponse(); 
            try
            {
                response = await securityService.RegisterUserAsync(user);   
            }
            catch (Exception ex)
            {
                response.Message += $"   {ex.Message}";
            }
            return response;
        }

        [HttpPost]
        [ActionName("login")]
        public async Task<SecureResponse> Authenticate(LoginUser user)
        {
            SecureResponse response = new SecureResponse();
            try
            {
                response = await securityService.AuthUser(user);
            }
            catch (Exception ex)
            {
                response.Message += $"   {ex.Message}";
            }
            return response;
        }
    }
}
