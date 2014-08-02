using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;

namespace VisiProj
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }

        protected void Application_AuthenticateRequest(Object sender, EventArgs e)
        {

            // Get the authentication cookie
            string cookieName = FormsAuthentication.FormsCookieName;
            HttpCookie authCookie = Context.Request.Cookies[cookieName];

            // If the cookie can't be found, don't issue the ticket
            if (authCookie == null)
            {
                //Context.Response.Redirect("/admin/login");
                return;
            }

            // Get the authentication ticket and rebuild the principal
            // & identity
            FormsAuthenticationTicket authTicket = FormsAuthentication.Decrypt(authCookie.Value);

            string[] UserData = authTicket.UserData.Split(new Char[] { '|' });

            GenericIdentity userIdentity = new GenericIdentity(authTicket.Name);
            GenericPrincipal userPrincipal = new GenericPrincipal(userIdentity, UserData);
            Context.User = userPrincipal;

        }
    }
}
