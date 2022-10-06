using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace User_authentication.WebAPI.Controllers
{
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        public AuthController()
        {

        }

        [Route("complete/{id}")]
        [HttpPut]
        public async Task<IActionResult> CompleteSprint(int id)
        {
            await _service.CompleteSprint(id);

            return Ok();
        }
    }
}
