using System;
using System.Collections.Generic;
using System.Text;

namespace ApiLogin.Domain.Repository
{
    public interface ITokenGerado
    {
        public string GerarToken(string token);
    }
}
