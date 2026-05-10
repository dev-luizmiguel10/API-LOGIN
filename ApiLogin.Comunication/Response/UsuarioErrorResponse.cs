using System;
using System.Collections.Generic;
using System.Text;

namespace ApiLogin.Comunication.Response
{
    public class UsuarioErrorResponse
    {
        public List<string> Erros { get; set; }

        public UsuarioErrorResponse(List<string> erro)
        {
            Erros = erro;
        }
        public UsuarioErrorResponse(string erro)
        {
            Erros = new List<string> { erro };
        }
    }
}
