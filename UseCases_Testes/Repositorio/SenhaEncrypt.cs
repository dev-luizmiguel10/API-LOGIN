using System;
using System.Collections.Generic;
using System.Text;

namespace UseCases_Testes.Repositorio
{
    public static class SenhaEncrypt
    {
        public static string EncrptSenha(string senha)
        {
            string hash = BCrypt.Net.BCrypt.HashPassword(senha);
            return hash;
        }
    }
}
