using ApiLogin.Application.UseCases.Login;
using ApiLogin.Comunication.Request;
using ApiLogin.Comunication.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiLogin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    [Authorize]
    public class LoginController : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(typeof(LoginResponse), StatusCodes.Status200OK)]
        //
        public async Task<IActionResult> Login([FromServices] ILogin login, [FromBody] LoginRequest request)
        {
            var response = await login.FazerLogin(request);
            return Ok(new
            {
                nome = response.nome,
                token = response.token
            });
        }
        

    }
}
