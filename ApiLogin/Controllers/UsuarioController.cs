using ApiLogin.Application.UseCases.Usuario;
using ApiLogin.Comunication.Request;
using ApiLogin.Comunication.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiLogin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(typeof(UsuarioResponse),StatusCodes.Status201Created)]

        public async Task<IActionResult> RegistraUsuario([FromBody] UsuarioRequest user, [FromServices] IUserRegistro register)
        {
            var response=await register.RegistrarUsuario(user);
            return Created("",response);
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> ListaUsuario([FromServices]IGetUsario usario)
        {
            var user = await usario.GetUsarioAsync();
            return Ok(user);
        }

        [HttpPatch("{id}")]
        [Authorize]
        public async Task<IActionResult> DesativarUsuario([FromServices]IUserDelete user, int id)
        {
            var delete_usuario = await user.UsuarioDelete(id);
            return NoContent();
        }
    }
}
