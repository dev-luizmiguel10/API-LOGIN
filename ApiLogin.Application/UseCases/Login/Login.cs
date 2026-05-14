using ApiLogin.Application.Services;
using ApiLogin.Comunication.Request;
using ApiLogin.Comunication.Response;
using ApiLogin.Domain.Repository;
using ApiLogin.Exception.Login;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiLogin.Application.UseCases.Login
{
    public class Login : ILogin
    {
        private readonly ILoginEntry _login;
        private readonly ITokenGerado _token;
        public Login(ILoginEntry login, ITokenGerado token)
        {
            _login = login;
            _token = token;
           
        }

        public async Task<UsuarioResponse> FazerLogin(LoginRequest login)
        {
            var user = await _login.LoginUsuario(login.email, login.senha) ?? throw new LoginExcpetion();
            return new UsuarioResponse
            {
                nome
                = user.nome,
                token = user.TokenUsuario

            };

        }

    }
}
