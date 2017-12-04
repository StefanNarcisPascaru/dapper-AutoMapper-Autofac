using System.Reflection;
using System.Web.Http;
using Autofac;
using Autofac.Integration.WebApi;
using AutoMapper;
using AutoMapper.Configuration;
using PentaStagione.Services.Configurations;

namespace PentaStagione.WebApi
{
    public class AutofacConfig
    {
        public static IContainer Configure(ContainerBuilder builder=null)
        {
            if(builder==null)
                builder = new ContainerBuilder();
            builder.RegisterModule(new AutofacServiceModule());
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            var mapconfigexp = new MapperConfigurationExpression();
            AutoMapperConfig.Configuration(mapconfigexp);
            var mapper = new MapperConfiguration(mapconfigexp).CreateMapper();
            builder.RegisterInstance(mapper).As<IMapper>();

            
            var container = builder.Build();

            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);
            return container;
        }
    }
}