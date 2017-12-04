using System.Web.Http;
using PentaStagione.WebApi;

namespace PentaStagione.WebApi1
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
