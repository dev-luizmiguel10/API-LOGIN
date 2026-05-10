using ApiLogin.Domain.Repository;
using ApiLogin.Exception.Login;
using ApiLogin.Exception.Usuario;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiLogin.Application.UseCases.Usuario
{
    public class UserDelete : IUserDelete
    {
        private readonly IUSerRepository _user;
        private readonly IUnitiOfWork _unit;
        public UserDelete(IUSerRepository user, IUnitiOfWork uniti)
        {
            _user = user;
            _unit = uniti;
        }
        public async Task<int> UsuarioDelete(int id)
        {
            var user = await _user.UsuarioDesabilitado(id);
            await _unit.Salvar();
            return user;
        }
    }
}
