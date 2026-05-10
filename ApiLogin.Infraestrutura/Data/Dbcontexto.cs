using ApiLogin.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiLogin.Infraestrutura.Data
{
    public class Dbcontexto:DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }
        public Dbcontexto(DbContextOptions<Dbcontexto> options):base(options)
        {
            
        }
    }
}
