using System;
using System.Collections.Generic;
using System.Text;

namespace ApiLogin.Domain.Repository
{
    public interface IPassword
    {
        public string EncryptSenha(string password);
    }
}
