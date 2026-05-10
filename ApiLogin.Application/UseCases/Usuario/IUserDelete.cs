using System;
using System.Collections.Generic;
using System.Text;

namespace ApiLogin.Application.UseCases.Usuario
{
    public interface IUserDelete
    {
        Task<int> UsuarioDelete(int id);
    }
}
