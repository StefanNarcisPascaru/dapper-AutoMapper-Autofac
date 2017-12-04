using AutoMapper.Configuration;
using PentaStagione.Repository.Dapper.Configurations.Mapings;

namespace PentaStagione.Services.Configurations
{
    public class AutoMapperConfig
    {
        public static void Configuration(MapperConfigurationExpression config)
        {
            PizzaAutoMapper.Configuration(config);
            PizzaIngredientAutoMapper.Configuration(config);
        }
    }
}
