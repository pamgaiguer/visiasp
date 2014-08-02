using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace VisiProj.Filters
{
    public class FormsAuthenticationService
    {
        public void SignIn(string userName, bool createPersistentCookie, string UserData)
        {
            if (String.IsNullOrEmpty(userName)) throw new ArgumentException("Value cannot be null or empty.", "userName");

            // Create and tuck away the cookie
            FormsAuthenticationTicket authTicket = new FormsAuthenticationTicket(1, userName, DateTime.Now, DateTime.Now.AddDays(15), createPersistentCookie, UserData);
            // Encrypt the ticket.
            string encTicket = FormsAuthentication.Encrypt(authTicket);

            //// Create the cookie.
            HttpCookie faCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encTicket);
            HttpContext.Current.Response.Cookies.Add(faCookie);
        }

        public void SignOut()
        {
            FormsAuthenticationTicket authTicket = new FormsAuthenticationTicket(1, String.Empty, DateTime.Now, DateTime.Now.AddDays(-1), false, String.Empty);
            // Encrypt the ticket.
            string encTicket = FormsAuthentication.Encrypt(authTicket);

            //// Create the cookie.
            HttpCookie faCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encTicket);
            HttpContext.Current.Response.Cookies.Add(faCookie);
        }
    }
}