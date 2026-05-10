using ApiLogin.Domain.Repository;
using ApiLogin.Exception.Usuario;
using ApiLogin.Infraestrutura.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiLogin.Infraestrutura.Repository
{
    public class Usuario:IUSerRepository
    {
        private readonly Dbcontexto _db;
        public Usuario(Dbcontexto dbcontexto)
        {
            _db = dbcontexto;
        }

        public async Task Adicionar(Domain.Entities.Usuario usuario)
        {
           _db.Usuarios.Add(usuario);
        }

        public async Task<bool> EmailJaCadastrado(string email)
        {
            return await _db.Usuarios.AnyAsync(u => u.email==email && u.Usuario_Ativo);
           
        }

        public async Task<List<Domain.Entities.Usuario>> GetUsuario()
        {
            return await _db.Usuarios.Where(s=>s.Usuario_Ativo==true).ToListAsync();
        }

        public async Task<int> UsuarioDesabilitado(int id)
        {
            
            var users = await _db.Usuarios.FirstOrDefaultAsync(s => s.UsuarioId == id) ?? throw new ApiLogin.Exception.Usuario.UserDelete(UserDeleteExcpetion.Usuario_Nullo);
            if (!users.Usuario_Ativo)
                throw new ApiLogin.Exception.Usuario.UserDelete(UserDeleteExcpetion.User_Desabilitado);

            users.Usuario_Ativo = false;
            return users.UsuarioId;
        }
    }
}
