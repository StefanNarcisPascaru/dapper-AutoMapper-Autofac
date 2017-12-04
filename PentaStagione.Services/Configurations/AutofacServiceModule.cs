using Autofac;
using PentaStagione.Domain.Repository;
using PentaStagione.Repository.Contracts.ReadModel.Repositories;
using PentaStagione.Repository.Dapper.Configurations;
using PentaStagione.Repository.Dapper.ReadModel;
using PentaStagione.Repository.Dapper.WriteRepositories;
//using PentaStagione.Repository.EntityFramwork.Configurations;
//using PentaStagione.Repository.EntityFramwork.ReadModel;
//using PentaStagione.Repository.EntityFramwork.WriteRepositories;
using PentaStagione.Services.Contracts;
using Module = Autofac.Module;

namespace PentaStagione.Services.Configurations
{

    public class AutofacServiceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //builder.RegisterModule(new AutofacEf());
            builder.RegisterModule(new AutofacDapper());
            builder.RegisterType<PizzaService>().As<IPizzaService>();
            builder.RegisterType<PizzaRepository>().As<IPizzaRepository>();
            builder.RegisterType<PizzaReadRepository>().As<IPizzaReadRepository>();

            builder.RegisterType<PizzaIngredientService>().As<IPizzaIngredientsService>();
            builder.RegisterType<PizzaIngredientRepository>().As<IPizzaIngredientRepository>();
            builder.RegisterType<PizzaIngredientReadRepository>().As<IPizzaIngredientReadRepository>();
           
        }
    }
}
