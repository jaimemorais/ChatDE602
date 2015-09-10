using ChatDE602.App_Start;
using System.Web.Mvc;
using System.Web.Routing;

namespace ChatDE602
{
    public class Global : System.Web.HttpApplication
    {

        // <summary> 
        /// Realiza configurações prévias.
        /// </summary>         
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
                        
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);            
        }

    }
}