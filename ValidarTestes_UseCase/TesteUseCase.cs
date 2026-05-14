using ApiLogin.Application.UseCases.Usuario;
using ApiLogin.Comunication.Request;
using ApiLogin.Domain.Entities;
using ApiLogin.Domain.Repository;
using ApiLogin.Exception.Usuario;
using Moq;
using Newtonsoft.Json.Linq;
using UseCases_Testes.Repositorio;
using UseCases_Testes.Usuario;

namespace ValidarTestes_UseCase
{
    public class TesteUseCase
    {
        [Fact]
        public async Task Sucess()
        {
            // arrange 
            var request_testes = UseCases_Testes.Usuario.ValidarUsuario.validate();


            var Ipass = IPasswordMoq.Senha();
            var IUSer = IUserMoq.Register();
            var Itokens = IToken.Token();
            var Iuniti = IUniti.Save();
            var mapper = Imapper.mapear();

            Mock.Get(IUSer)
         .Setup(x => x.EmailJaCadastrado(It.IsAny<string>()))
         .ReturnsAsync(false);
            
            Mock.Get(Itokens)
                .Setup(x => x.GerarToken(It.IsAny<string>()))
                .Returns("token-fake");

            Mock.Get(Ipass)
                .Setup(x => x.EncryptSenha(It.IsAny<string>()))
                .Returns("senha-hash");

            

            var usuario_criado = new ApiLogin.Application.UseCases.Usuario.Usuario(IUSer, mapper, Iuniti, Itokens, Ipass);

            var user = await usuario_criado.RegistrarUsuario(request_testes);

            Assert.NotNull(user);
        }
        [Fact]
        public async Task Error_Name_Vazio()
        {
            // arrange 
            var request_nome = UseCases_Testes.Usuario.ValidarUsuario.validate();
            request_nome.nome = string.Empty;
            // act
            var validar_usuario = new ApiLogin.Application.UseCases.Usuario.ValidarUsuario();
            var result_usuario = validar_usuario.Validate(request_nome);

            // arrange
            Assert.False(result_usuario.IsValid);
        }
        [Fact]
        public async Task Erro_Email_Vazio()
        {
            // arrange 
            var request_email_teste = UseCases_Testes.Usuario.ValidarUsuario.validate();
            request_email_teste.email = string.Empty;
            // act
            var validar_usuario = new ApiLogin.Application.UseCases.Usuario.ValidarUsuario();
            var result_usuario = validar_usuario.Validate(request_email_teste);

            // arrange
            Assert.False(result_usuario.IsValid);
        }

        [Theory]
        [InlineData("")]
        [InlineData("1234")]
        [InlineData("12345")]

        public async Task Password_Vazio(string senha)
        {
            // arrange 
            var request_teste_senha = UseCases_Testes.Usuario.ValidarUsuario.validate();
            request_teste_senha.senha = senha;
            // act
            var validar_usuario = new ApiLogin.Application.UseCases.Usuario.ValidarUsuario();
            var result_usuario = validar_usuario.Validate(request_teste_senha);

            // arrange
            Assert.False(result_usuario.IsValid);
        }
        [Fact]
        public async Task Email_Duplicado()
        {
            // arrange 
            var request_teste_email = UseCases_Testes.Usuario.ValidarUsuario.validate();

            var Ipass = IPasswordMoq.Senha();
            var IUSer = IUserMoq.Register();
            var Itokens = IToken.Token();
            var Iuniti = IUniti.Save();
            var mapper = Imapper.mapear();

            Mock.Get(IUSer)
            .Setup(x => x.EmailJaCadastrado(It.IsAny<string>()))
            .ReturnsAsync(true); // email ja existe

            var usuario_criado = new ApiLogin.Application.UseCases.Usuario.Usuario(IUSer, mapper, Iuniti, Itokens, Ipass);

            await Assert.ThrowsAsync<UsuarioOnException>(()=>usuario_criado.RegistrarUsuario(request_teste_email));
        }

    }
}
