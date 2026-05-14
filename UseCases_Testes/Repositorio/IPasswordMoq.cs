using ApiLogin.Domain.Repository;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;

namespace UseCases_Testes.Repositorio
{
    public static class IPasswordMoq
    {
       public static IPassword Senha()
        {
            var moq= new Mock<IPassword>();
            return moq.Object;
        }
    }
}
