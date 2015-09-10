using Microsoft.Owin;
using Owin;


[assembly: OwinStartup(typeof(ChatDE602.Startup))]
namespace ChatDE602
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {   
            app.MapSignalR();
        }
    }
}
