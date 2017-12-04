using AutoMapper.Configuration;
using PentaStagione.Domain.Models;
using PentaStagione.Repository.Contracts.ReadModel.DTOs;

namespace PentaStagione.Repository.Dapper.Configurations.Mapings
{
    public class PizzaIngredientAutoMapper
    {
        public static void Configuration(MapperConfigurationExpression config)
        {
            config.CreateMap<PizzaIngredientDto, PizzaIngredient>().ForMember(dest => dest.Id, src => src.Ignore());
            config.CreateMap<PizzaIngredient, PizzaIngredientDto>();
        }
    }
}
