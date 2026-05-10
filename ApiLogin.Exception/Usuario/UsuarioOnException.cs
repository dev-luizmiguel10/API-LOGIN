using System;
using System.Collections.Generic;
using System.Text;

namespace ApiLogin.Exception.Usuario
{
    public class UsuarioOnException:UsuarioException
    {
        public List<string> Erros { get; set; }
        public UsuarioOnException(List<string> error):base(string.Empty)
        {
            Erros = error;
        }
    }
}
