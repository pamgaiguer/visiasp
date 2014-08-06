using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using VisiProj.Filters;
using VisiProj.Models;

namespace VisiProj.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private VisiContext db = new VisiContext();

        // GET: Admin
        public ActionResult Index()
        {
            List<ProjetoModel> p = db.Projetos.Where(t => !t.Deleted).ToList();
            return View(p);
        }

        // GET: ProjetoModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProjetoModel projetoModel = db.Projetos.Find(id);
            if (projetoModel == null)
            {
                return HttpNotFound();
            }
            return View(projetoModel);
        }

        // GET: ProjetoModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProjetoModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nome,Data,Local,Area")] ProjetoModel projetoModel)
        {
            if (ModelState.IsValid)
            {
                projetoModel.Nome = projetoModel.Nome.ToUpper();
                db.Projetos.Add(projetoModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(projetoModel);
        }

        // GET: ProjetoModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProjetoModel projetoModel = db.Projetos.Find(id);
            if (projetoModel == null)
            {
                return HttpNotFound();
            }
            return View(projetoModel);
        }

        // POST: ProjetoModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome,Data,Local,Area")] ProjetoModel projetoModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(projetoModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(projetoModel);
        }

        // GET: ProjetoModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProjetoModel projetoModel = db.Projetos.Find(id);
            if (projetoModel == null)
            {
                return HttpNotFound();
            }
            return View(projetoModel);
        }

        // POST: ProjetoModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProjetoModel projetoModel = db.Projetos.Find(id);
            projetoModel.Deleted = true;
            db.Entry(projetoModel).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
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
                return RedirectToAction("Index");
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