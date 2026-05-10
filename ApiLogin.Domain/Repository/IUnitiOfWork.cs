using System;
using System.Collections.Generic;
using System.Text;

namespace ApiLogin.Domain.Repository
{
    public interface IUnitiOfWork
    {
        public Task Salvar();
    }
}
