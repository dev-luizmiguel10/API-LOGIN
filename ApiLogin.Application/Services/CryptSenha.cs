using BCrypt.Net;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiLogin.Application.Services
{
    public class CryptSenha
    {
        public string EncrptSenha(string senha )
        {
            string hash= BCrypt.Net.BCrypt.HashPassword( senha );
            return hash;
        }
       
    }
}
