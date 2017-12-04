using AutoMapper.Configuration;
using PentaStagione.Domain.Models;
using PentaStagione.Repository.Contracts.ReadModel.DTOs;

namespace PentaStagione.Repository.EntityFramwork.Configurations.Mapings
{
    public class PizzaAutoMapper
    {
        public static void Configuration(MapperConfigurationExpression config)
        {
            config.CreateMap<PizzaDto, Pizza>().ForMember(dest => dest.Id, src => src.Ignore());
            config.CreateMap<Pizza, PizzaDto>();
        }
    }
}
