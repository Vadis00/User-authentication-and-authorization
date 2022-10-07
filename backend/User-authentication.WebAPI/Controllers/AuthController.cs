using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Text.Json;
using System.Text.Json.Serialization;
using User_authentication.BLL.Service;
using User_authentication.Common.Model;
using User_authentication.Identity.Model;

namespace User_authentication.WebAPI.Controllers
{
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly AuthService authService;
        private readonly IOptions<AuthOptions> options;

        public AuthController(IOptions<AuthOptions> options,  AuthService authService)
        {
            this.authService = authService;  
            this.options = options;  
        }

        [HttpPost]
        public async Task<IActionResult> Auth(string email, string password)
        {

            return Ok(await authService.AuthenticateUser(email, password));
        }
    }
}
