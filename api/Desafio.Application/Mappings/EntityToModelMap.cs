using AutoMapper;
using Desafio.Application.Models.Ativos;
using Desafio.Application.Models.AtivosUsuario;
using Desafio.Application.Models.ContasCorrentes;
using Desafio.Application.Models.Usuarios;
using Desafio.Domain.Entities;

namespace Desafio.Application.Mappings
{
    public class EntityToModelMap : Profile
    {
        public EntityToModelMap()
        {
            CreateMap<Ativo, AtivoModel>();
            CreateMap<Usuario, UsuarioModel>();
            CreateMap<AtivoUsuario, AtivoUsuarioModel>()
                .ForMember(dest => dest.AtivoModel, opt => opt.MapFrom(src => src.Ativo));
            CreateMap<ContaCorrente, ContaCorrenteModel>();
        }
    }
}