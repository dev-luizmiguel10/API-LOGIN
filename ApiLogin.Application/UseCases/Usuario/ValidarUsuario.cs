using ApiLogin.Comunication.Request;
using ApiLogin.Exception.Usuario;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiLogin.Application.UseCases.Usuario
{
    public class ValidarUsuario:AbstractValidator<UsuarioRequest>
    {
        public ValidarUsuario()
        {
            RuleFor(c => c.nome).NotEmpty().NotNull().WithMessage(UserException.nome_vazio);
            RuleFor(c => c.email).EmailAddress().NotEmpty().WithMessage(UserException.email_endereco);
            RuleFor(c => c.senha).MinimumLength(6).NotNull().NotEmpty().WithMessage(UserException.senha_tamanho);
        }
    }
}
