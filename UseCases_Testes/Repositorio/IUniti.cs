using ApiLogin.Comunication.Request;
using ApiLogin.Domain.Repository;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;

namespace UseCases_Testes.Repositorio
{
    public class IUniti
    {
        public static IUnitiOfWork validate()
        {
            var moq= new Mock<IUnitiOfWork>();
            return moq.Object;
        }
    }
}
