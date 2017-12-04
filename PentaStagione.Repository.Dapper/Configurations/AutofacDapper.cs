using System.Data;
using Autofac;

namespace PentaStagione.Repository.Dapper.Configurations
{
    public class AutofacDapper : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(db => new DbConnection("PizzaDbEf").Connection).As<IDbConnection>().InstancePerLifetimeScope();
        }
    }
}
