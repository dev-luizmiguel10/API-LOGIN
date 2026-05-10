using ApiLogin.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiLogin.Application.UseCases.Usuario
{
    public interface IGetUsario
    {
        Task<List<Domain.Entities.Usuario>> GetUsarioAsync();
    }
}
