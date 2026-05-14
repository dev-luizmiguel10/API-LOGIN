using ApiLogin.Comunication.Request;
using Bogus;
using System;
using System.Collections.Generic;
using System.Text;

namespace UseCases_Testes.Login
{
    public class ValidarLogin
    {
        public static LoginRequest FazerLogin()
        {
            return new Faker<LoginRequest>()
                .RuleFor(s => s.email, f => f.Internet.Email())
                .RuleFor(p => p.senha, (f, s) => f.Internet.Password())
                .Generate();
           
        }
    }
}
