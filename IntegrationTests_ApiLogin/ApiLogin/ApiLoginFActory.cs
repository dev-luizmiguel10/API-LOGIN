using ApiLogin.Infraestrutura.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace IntegrationTests_ApiLogin.ApiLogin
{
    public class ApiLoginFActory : WebApplicationFactory<Program>
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                // Remove TODOS os DbContext registrados
                var descriptors = services.Where(
                    d => d.ServiceType == typeof(DbContextOptions<Dbcontexto>) ||
                         d.ServiceType == typeof(DbContextOptions)).ToList();

                foreach (var descriptor in descriptors)
                    services.Remove(descriptor);

                // Remove o provider do SQL Server
                var dbProvider = services.Where(
                    d => d.ServiceType == typeof(IDbContextOptionsConfiguration<Dbcontexto>))
                    .ToList();

                foreach (var descriptor in dbProvider)
                    //services.Remove(descriptor);
                    services.Remove(descriptor);

                // Adiciona o banco em memória
                services.AddDbContext<Dbcontexto>(options =>
                    options.UseInMemoryDatabase("TestDb"));
            });
        }
    }
}
