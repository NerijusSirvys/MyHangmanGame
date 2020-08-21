using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using MyHangman.Data;
using MyHangman.Managers;
using Owin;

[assembly: OwinStartup(typeof(MyHangman.App_Start.Startup))]

namespace MyHangman.App_Start
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.CreatePerOwinContext<GameDbContext>(GameDbContext.Create);
            app.CreatePerOwinContext<UserManager>(UserManager.Create);

            app.UseCookieAuthentication(new Microsoft.Owin.Security.Cookies.CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Welcome")
            });
        }
    }
}