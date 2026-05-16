using ApiLogin.Comunication.Request;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http.Json;
using System.Text;

namespace IntegrationTests_ApiLogin.ApiLogin
{
    public class LoginTesteApIntegracaoi: IClassFixture<ApiLoginFActory>
    {
        private readonly HttpClient _client;
        
        public LoginTesteApIntegracaoi(ApiLoginFActory factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task Cadastrar_Usuario_Sucesso()
        {
            // arrange
            var request = new UsuarioRequest
            {
                nome = "Luiz",
                email = "luiz@teste.com",
                senha = "senha123"
            };

            // act
            var response = await _client.PostAsJsonAsync("/api/Usuario", request);

            // assert
            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
        }
        [Fact]
        public async Task Cadastrar_Usuario_Email_Duplicado()
        {
            // arrange
            var request = new UsuarioRequest
            {
                nome = "Luiz",
                email = "luiz@teste.com",
                senha = "senha123"
            };

            // cadastra o primeiro
            await _client.PostAsJsonAsync("/api/Usuario", request);

            // act — tenta cadastrar o mesmo email
            var response = await _client.PostAsJsonAsync("/api/Usuario", request);

            // assert
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }
        [Fact]
        public async Task Cadastrar_Usuario_Campos_Vazios()
        {
            // arrange
            var request = new UsuarioRequest
            {
                nome = "",
                email = "",
                senha = ""
            };

            // act
            var response = await _client.PostAsJsonAsync("/api/Usuario", request);

            // assert
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Fact]
        public async Task Login_Sucesso()
        {
            // arrange — primeiro cadastra o usuário
            var cadastro = new UsuarioRequest
            {
                nome = "Luiz",
                email = "luiz@login.com",
                senha = "senha123"
            };
            await _client.PostAsJsonAsync("/api/Usuario", cadastro);

            // act — faz o login
            var login = new LoginRequest
            {
                email = "luiz@login.com",
                senha = "senha123"
            };
            var response = await _client.PostAsJsonAsync("/api/Login", login);

            // assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
        [Fact]
        public async Task Login_Credenciais_Invalidas()
        {
            // arrange
            var login = new LoginRequest
            {
                email = "naoexiste@teste.com",
                senha = "senhaerrada"
            };

            // act
            var response = await _client.PostAsJsonAsync("/api/Login", login);

            // assert
            Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
        }
    }
    
}
