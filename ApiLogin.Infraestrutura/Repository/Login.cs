using ApiLogin.Domain.Repository;
using ApiLogin.Infraestrutura.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiLogin.Infraestrutura.Repository
{
    public class Login : ILoginEntry
    {
        private readonly Dbcontexto _db;
        public Login(Dbcontexto dbcontexto)
        {
            _db = dbcontexto;
        }

        public async Task<Domain.Entities.Usuario> LoginUsuario(string email, string password)
        {
            var user = await _db.Usuarios.FirstOrDefaultAsync(u =>
    u.email == email && u.senha == password);
            return user;
        }
    }
}
