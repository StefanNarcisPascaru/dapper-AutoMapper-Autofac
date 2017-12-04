using System.Reflection;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;

namespace PentaStagione.WebSite1
{
    public class AutofacConfig
    {
        public static void Configure()
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(Assembly.GetExecutingAssembly());
            var container=WebApi1.AutofacConfig.Configure(builder);

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}