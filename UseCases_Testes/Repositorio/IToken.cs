using ApiLogin.Domain.Repository;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;

namespace UseCases_Testes.Repositorio
{
    public class IToken
    {
        public static ITokenGerado Token()
        {
            var tkn = new Mock<ITokenGerado>();
            return tkn.Object;
        }
    }
}
