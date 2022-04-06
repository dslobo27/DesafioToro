using Desafio.Application.Contracts;
using Desafio.Application.Services;
using Desafio.Domain.Contracts;
using Desafio.Domain.Contracts.Services;
using Desafio.Domain.Services;
using Desafio.InfraStructure.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Desafio.Application.IoC
{
    public class DependencyResolver
    {
        public static void Register(IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IAtivoApplicationService, AtivoApplicationService>();
            services.AddTransient<IAtivoDomainService, AtivoDomainService>();
            services.AddTransient<IAtivoRepository, AtivoRepository>();

            //services.AddTransient<IContaCorrenteApplicationService, ContaCorrenteApplicationService>();
            //services.AddTransient<IContaCorrenteDomainService, ContaCorrenteDomainService>();
            //services.AddTransient<IContaCorrenteRepository, ContaCorrenteRepository>();

            //services.AddTransient<IUsuarioApplicationService, UsuarioApplicationService>();
            //services.AddTransient<IUsuarioDomainService, UsuarioDomainService>();
            //services.AddTransient<IUsuarioRepository, UsuarioRepository>();
        }
    }
}