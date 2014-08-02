using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VisiProj.Filters;
using VisiProj.Models;

namespace VisiProj.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            List<ProjetoModel> p = new List<ProjetoModel>();
            return View(p);
        }

        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(LoginModel login)
        {
            if (login.Username == "admin" && login.Password == "1q2w3e4r")
            {
                new FormsAuthenticationService().SignIn("admin", false, String.Empty);
                return Index();
            } else
            {
                ViewBag.ErrorMessage = "User ou pass incorreto(s).";
                return View();
            }
        }

        public ActionResult Logout()
        {
            new FormsAuthenticationService().SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}