using ApiLogin.Comunication.Request;
using ApiLogin.Comunication.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiLogin.Application.UseCases.Usuario
{
    public interface IUserRegistro
    {
        public Task<UsuarioResponse> RegistrarUsuario(UsuarioRequest user);
    }
}
