using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BibliotecaCore;
using Microsoft.EntityFrameworkCore;
using BibliotecaCore.IRepositorios;
using BibliotecaInfra.EntityFramework.Repositorios;

namespace BibliotecaInfra.EntityFramework
{
    public static class Startup
    {
        public static void AddInfrastructure(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<BancoDeDados>(options => options.UseSqlServer(connectionString));

            services.AddScoped<IRepositorioLivro, RepositorioLivro>();
            services.AddScoped<IRepositorioAutor, RepositorioAutor>();
        }
    }
}
