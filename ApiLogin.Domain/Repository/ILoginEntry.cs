using ApiLogin.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiLogin.Domain.Repository
{
    public interface ILoginEntry
    {
        public Task<Usuario> LoginUsuario(string email, string password);
    }
}
