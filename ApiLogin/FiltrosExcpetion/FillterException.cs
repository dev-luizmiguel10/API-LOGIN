using ApiLogin.Comunication.Response;
using ApiLogin.Exception.Login;
using ApiLogin.Exception.Usuario;
using ApiLogin.Infraestrutura.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace ApiLogin.FiltrosExcpetion
{
    public class FillterException : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            if (context.Exception is UsuarioException user)
            {
                ValidarUsuario(context);
            }

            else
            {
                Desconhecido(context);
            }
        }
        public void ValidarUsuario(ExceptionContext context)
        {
            switch (context.Exception)
            {
                case UsuarioOnException ex:
                    context.Result = new BadRequestObjectResult(new UsuarioErrorResponse(ex.Erros));
                    context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    break;

                case LoginExcpetion ex:
                    context.Result = new UnauthorizedObjectResult(new UsuarioErrorResponse(ex.Message));
                    context.HttpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                    break;

                case ApiLogin.Exception.Usuario.UserDelete ex:
                    context.Result = new BadRequestObjectResult(new UsuarioErrorResponse(ex.Message));
                    context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    break;
            }

        }
        public void Desconhecido(ExceptionContext context)
        {
            context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            context.Result = new ObjectResult(new UsuarioErrorResponse(UserException.erro));
        }
    }
}
