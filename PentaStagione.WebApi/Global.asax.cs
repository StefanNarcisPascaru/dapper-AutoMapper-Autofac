using System.Web.Http;

namespace PentaStagione.WebApi
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AutofacConfig.Configure();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            
        }
    }
}
