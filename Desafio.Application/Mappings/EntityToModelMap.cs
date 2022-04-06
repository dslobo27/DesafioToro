using AutoMapper;
using Desafio.Application.Models.Ativos;
using Desafio.Domain.Entities;

namespace Desafio.Application.Mappings
{
    public class EntityToModelMap : Profile
    {
        public EntityToModelMap()
        {
            CreateMap<Ativo, AtivoModel>();
        }
    }
}