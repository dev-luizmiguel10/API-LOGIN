using ApiLogin.Domain.Repository;
using ApiLogin.Infraestrutura.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiLogin.Infraestrutura.Repository
{
    public class Unity : IUnitiOfWork
    {
        private readonly Dbcontexto _db;
        public Unity(Dbcontexto dbcontexto)
        {
            _db = dbcontexto;
        }
        public async Task Salvar()
        {
            await _db.SaveChangesAsync();
        }
    }

}
