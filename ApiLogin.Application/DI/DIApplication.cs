using ApiLogin.Application.Services;
using ApiLogin.Application.UseCases.Login;
using ApiLogin.Application.UseCases.Usuario;
using ApiLogin.Domain.Repository;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace ApiLogin.Application.DI
{
    public static class DIApplication
    {
        public static void InjecaoDepedenciaApplication( this IServiceCollection services)
        {
            Usecase(services);
            Automapper(services);
        }
        public static void Usecase(IServiceCollection services)
        {
            services.AddScoped<IUserRegistro, Usuario>();
            services.AddScoped<ILogin, Login>();
            services.AddScoped<IGetUsario, GetUsuario>();
            services.AddScoped<IUserDelete, UserDelete>();
            services.AddScoped<IUserDelete, UserDelete>();
            services.AddScoped<IPassword, CryptSenha>();
        }
      
        public static void Automapper(IServiceCollection services)
        {
            services.AddScoped(s => new AutoMapper.MapperConfiguration(u =>
            {
                u.AddProfile(new AutoMapping());
            }).CreateMapper());
        }
       
    }
}
