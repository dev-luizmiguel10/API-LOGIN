using ApiLogin.Application.Services;
using ApiLogin.Application.UseCases.Login;
using ApiLogin.Application.UseCases.Usuario;
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
            Password(services);
            Automapper(services);
            Senha(services);

        }
        public static void Usecase(IServiceCollection services)
        {
            services.AddScoped<IUserRegistro, Usuario>();
            services.AddScoped<ILogin, Login>();
            services.AddScoped<IGetUsario, GetUsuario>();
            services.AddScoped<IUserDelete, UserDelete>();
        }
        public static void Password(IServiceCollection services)
        {
            services.AddScoped(s => new EncriptarSenha());
        }
        public static void Automapper(IServiceCollection services)
        {
            services.AddScoped(s => new AutoMapper.MapperConfiguration(u =>
            {
                u.AddProfile(new AutoMapping());
            }).CreateMapper());
        }
        public static void Senha( IServiceCollection services)
        {
            services.AddScoped(s=>new CryptSenha());
        }
    }
}
