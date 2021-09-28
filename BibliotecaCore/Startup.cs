using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BibliotecaCore.RegrasNegocio;
using Microsoft.Extensions.DependencyInjection;

namespace BibliotecaCore
{
    public static class Startup
    {
        public static void AddApplicacaoCore(this IServiceCollection services)
        {
            services.AddScoped<AplicacaoLivro>();
            services.AddScoped<AplicacaoAutor>();
;        }
    }
}
