using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Visi.Controllers
{
    public class WelcomeController : Controller
    {
        public ActionResult Index()
        {
            return View ();
        }
    }
}
