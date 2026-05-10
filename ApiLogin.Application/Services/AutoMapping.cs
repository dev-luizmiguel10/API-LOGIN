using ApiLogin.Application.UseCases.Usuario;
using ApiLogin.Comunication.Request;
using ApiLogin.Domain.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiLogin.Application.Services
{
    public class AutoMapping:Profile
    {
        public AutoMapping()
        {
            CreateUser();
        }

        public void CreateUser()
        {
            CreateMap<UsuarioRequest, Domain.Entities.Usuario>().ForMember(s => s.senha,r=>r.Ignore());
        }
    }
}
