using ApiLogin.Application.UseCases.Usuario;
using ApiLogin.Domain.Repository;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;

namespace UseCases_Testes.Repositorio
{
    public class IUserMoq
    {
        public static IUSerRepository Register()
        {
            var moq = new Mock<IUSerRepository>();
            return moq.Object;
        }
    }
}
