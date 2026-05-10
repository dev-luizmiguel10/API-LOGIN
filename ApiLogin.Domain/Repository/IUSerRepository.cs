using ApiLogin.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiLogin.Domain.Repository
{
    public interface IUSerRepository
    {
        public Task Adicionar(Usuario usuario);
        public Task<bool> EmailJaCadastrado(string email);
        Task<List<Usuario>> GetUsuario();

        Task<int> UsuarioDesabilitado(int  id);
    }
}
