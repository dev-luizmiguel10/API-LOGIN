using ApiLogin.Domain.Repository;
using BCrypt.Net;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiLogin.Application.Services
{
    public class CryptSenha:IPassword
    {
        public string EncryptSenha(string password)
        {
            string hash = BCrypt.Net.BCrypt.HashPassword(password);
            return hash;
        }
    }
}
