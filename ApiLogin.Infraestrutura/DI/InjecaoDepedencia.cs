using ApiLogin.Domain.Repository;
using ApiLogin.Infraestrutura.Data;
using ApiLogin.Infraestrutura.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ApiLogin.Infraestrutura.DI
{
    public static class InjecaoDepedencia
    {
        public static void InjectInfra(this IServiceCollection services,IConfiguration configuration)
        {
            Dbcontexto(services, configuration);
            RepositoryInjection(services);
        }
        public static void Dbcontexto(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<Dbcontexto>(u => u.UseSqlServer(configuration.GetConnectionString("Conection")));
        }
        public static void RepositoryInjection(IServiceCollection services)
        {
            services.AddScoped<IUSerRepository, Usuario>();
            services.AddScoped<IUnitiOfWork, Unity>();
            services.AddScoped<ITokenGerado, TokenJwt>();
            services.AddScoped<ILoginEntry, Login>();
        }
    }
}
