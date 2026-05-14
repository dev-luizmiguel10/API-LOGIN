using ApiLogin.Comunication.Request;
using Bogus;
using System;
using System.Collections.Generic;
using System.Text;

namespace UseCases_Testes.Usuario
{
    public class ValidarUsuario
    {
        public static UsuarioRequest validate ()
        {
            return new Faker<UsuarioRequest>()

                .RuleFor(r => r.nome, f => f.Person.FirstName)
                .RuleFor(e => e.email, (f, user) => f.Internet.Email(user.nome))
                .RuleFor(s => s.senha, f => f.Internet.Password())
                .Generate();
                
        }
    }
}
