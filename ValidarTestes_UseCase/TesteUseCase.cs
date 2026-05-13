using ApiLogin.Application.UseCases.Usuario;
using ApiLogin.Comunication.Request;
using ApiLogin.Domain.Repository;
using Moq;
using UseCases_Testes.Repositorio;
using UseCases_Testes.Usuario;

namespace ValidarTestes_UseCase
{
    public class TesteUseCase
    {
        [Fact]
        public async Task Sucess()
        {
            
            var request = UseCases_Testes.Usuario.ValidarUsuario.validate();
            var validate = new ApiLogin.Application.UseCases.Usuario.ValidarUsuario();

           
            var result = validate.Validate(request);

            
            Assert.True(result.IsValid);
        }
        public Usuario CriarUsuario()
        {
            var validate = new ApiLogin.Application.UseCases.Usuario.ValidarUsuario();
            var user_request =  new UsuarioRequest();
            var user = IUserMoq.Register();
            var save = IUniti.validate();
            var tkn = IToken.Token();
            var mapper = Imapper.mapear();
            var senha = SenhaEncrypt.EncrptSenha("sadsasasdds");
            return new Usuario(user, mapper, save, tkn,senha);
        }
    }
}
