using ApiLogin.Domain.Repository;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;

namespace UseCases_Testes.Repositorio
{
    public static class LoginMoq
    {
        public static ILoginEntry Login()
        {
            var moq = new Mock<ILoginEntry>();
            return moq.Object;
        }
    }
}
