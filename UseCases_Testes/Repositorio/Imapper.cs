using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace UseCases_Testes.Repositorio
{
    public class Imapper
    {
        public static IMapper mapear() {
            var moq =  new AutoMapper.MapperConfiguration(u =>
            {
                u.AddProfile(new ApiLogin.Application.Services.AutoMapping());
            }).CreateMapper();
            return moq;
        }
    }
}
