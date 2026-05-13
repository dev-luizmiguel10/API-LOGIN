using ApiLogin.Application.UseCases.Usuario;
using UseCases_Testes.Usuario;

namespace ValidarTestes_UseCase
{
    public class TesteUseCase
    {
        [Fact]
        public async Task Sucess()
        {
            // arrange
            var request = UseCases_Testes.Usuario.ValidarUsuario.validate();
            var validate = new ApiLogin.Application.UseCases.Usuario.ValidarUsuario();

            // act
            var result = validate.Validate(request);

            
            Assert.True(result.IsValid);
        }
    }
}
