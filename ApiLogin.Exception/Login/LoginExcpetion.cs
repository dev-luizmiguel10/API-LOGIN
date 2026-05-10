using ApiLogin.Exception.Usuario;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiLogin.Exception.Login
{
    public class LoginExcpetion : UsuarioException
    {
        public LoginExcpetion() : base(Login_User.Login)
        {
        }
    }
}
