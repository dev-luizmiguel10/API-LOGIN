using System;
using System.Collections.Generic;
using System.Text;

namespace ApiLogin.Exception.Usuario
{
    public class UserDelete : UsuarioException
    {
        public UserDelete(string mensagem) : base(mensagem)
        {
        }
    }
}
