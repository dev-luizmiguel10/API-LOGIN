using ApiLogin.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiLogin.Application.UseCases.Usuario
{
    public class GetUsuario : IGetUsario
    {
        private readonly IUSerRepository _user;
        public GetUsuario(IUSerRepository repository)
        {
            _user = repository;
        }

        async Task<List<Domain.Entities.Usuario>> IGetUsario.GetUsarioAsync()
        {
            return await _user.GetUsuario();
        }
    }
}
