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
        private readonly EncriptarSenha _senha;
        private readonly ITokenGerado _token;
        private readonly CryptSenha _password;
        public Login(ILoginEntry login, EncriptarSenha senha, ITokenGerado token, CryptSenha password)
        {
            _login = login;
            _senha = senha;
            _token = token;
            _password = password;
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
