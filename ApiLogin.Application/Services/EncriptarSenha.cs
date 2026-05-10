using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace ApiLogin.Application.Services
{
    public class EncriptarSenha
    {
        public string SenhaEncriptada(string senha)
        {
            var password= Encoding.UTF8.GetBytes(senha);
            var hash=SHA3_512.HashData(password);
            StringBuilder sb= new StringBuilder();
            foreach (var b in hash)
            {
                var hex = b.ToString("x2");
                sb.Append(hex);
            }
            return sb.ToString();
        }
    }
}
