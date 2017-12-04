using System.Data.Entity;
using Autofac;
using PentaStagione.Repository.EntityFramwork.Context;

namespace PentaStagione.Repository.EntityFramwork.Configurations
{
    public class AutofacEf :Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<PizzaContext>().As<DbContext>().InstancePerRequest();
        }
    }
}
