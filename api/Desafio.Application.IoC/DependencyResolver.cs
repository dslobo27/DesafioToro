using Desafio.Application.Contracts;
using Desafio.Application.Services;
using Desafio.Domain.Contracts.Repositories;
using Desafio.Domain.Contracts.Services;
using Desafio.Domain.Services;
using Desafio.InfraStructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Desafio.Application.IoC
{
    public class DependencyResolver
    {
        public static void Register(IServiceCollection services)
        {
            services.AddTransient<IAtivoApplicationService, AtivoApplicationService>();
            services.AddTransient<IAtivoDomainService, AtivoDomainService>();
            services.AddTransient<IAtivoRepository, AtivoRepository>();

            services.AddTransient<IContaCorrenteRepository, ContaCorrenteRepository>();

            services.AddTransient<IUsuarioApplicationService, UsuarioApplicationService>();
            services.AddTransient<IUsuarioDomainService, UsuarioDomainService>();
            services.AddTransient<IUsuarioRepository, UsuarioRepository>();

            services.AddTransient<IAtivoUsuarioDomainService, AtivoUsuarioDomainService>();
            services.AddTransient<IAtivoUsuarioRepository, AtivoUsuarioRepository>();

            services.AddTransient<IUnitOfWork, UnitOfWork>();
        }
    }
}