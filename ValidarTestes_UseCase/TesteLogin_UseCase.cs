using ApiLogin.Comunication.Response;
using ApiLogin.Domain.Entities;
using ApiLogin.Exception.Login;
using Moq;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using UseCases_Testes.Repositorio;

namespace ValidarTestes_UseCase
{
    public class TesteLogin_UseCase
    {
        [Fact]
        public async Task Sucesso()
        {
            var teste_login = UseCases_Testes.Login.ValidarLogin.FazerLogin();
            var login = LoginMoq.Login();
            var token = IToken.Token();

            Mock.Get(login)
         .Setup(s => s.LoginUsuario(It.IsAny<string>(), It.IsAny<string>()))
         .ReturnsAsync(new ApiLogin.Domain.Entities.Usuario
         {
             nome = "Luiz",
             TokenUsuario = "token-jwt"
         });

            Mock.Get(token)
                .Setup(s => s.GerarToken(It.IsAny<string>()))
                .Returns("token-jwt");

             var login_user = new ApiLogin.Application.UseCases.Login.Login(login, token);
            var fazer_login = await login_user.FazerLogin(teste_login);

            Assert.NotNull(fazer_login);
            Assert.NotNull(fazer_login.token);
        }

        [Fact]
        public async Task Campos_Vazio()
        {
            var teste_login = UseCases_Testes.Login.ValidarLogin.FazerLogin();
            var login = LoginMoq.Login();
            var token = IToken.Token();
            Mock.Get(login).Setup(s => s.LoginUsuario(It.IsAny<string>(), It.IsAny<string>()))
                .ReturnsAsync((Usuario)null);
          
            var login_user = new ApiLogin.Application.UseCases.Login.Login(login, token);
            await Assert.ThrowsAsync<LoginExcpetion>(() => login_user.FazerLogin(teste_login));


        }
      
    }
}
