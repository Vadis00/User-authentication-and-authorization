using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Text.Json.Serialization;
using User_authentication.BLL.Service;
using User_authentication.Common.Model;

namespace User_authentication.WebAPI.Controllers
{
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private AuthService authService;
        public AuthController(AuthService authService)
        {
            this.authService = authService;  
        }

        [HttpPost]
        public async Task<IActionResult> Auth(string email, string password)
        {

            return Ok(await authService.Login(email, password));
        }
    }
}
