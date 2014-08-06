using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using VisiProj.Models;

namespace VisiProj.Controllers
{
    [Authorize]
    public class CategoriaController : Controller
    {
        private VisiContext db = new VisiContext();

        // GET: CategoriaModel
        public ActionResult Index()
        {
            return View(db.Categorias.ToList());
        }

        // GET: CategoriaModel/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CategoriaModel categoriaModel = db.Categorias.Find(id);
            if (categoriaModel == null)
            {
                return HttpNotFound();
            }
            return View(categoriaModel);
        }

        // GET: CategoriaModel/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CategoriaModel/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nome")] CategoriaModel categoriaModel)
        {
            if (ModelState.IsValid)
            {
                db.Categorias.Add(categoriaModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(categoriaModel);
        }

        // GET: CategoriaModel/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CategoriaModel categoriaModel = db.Categorias.Find(id);
            if (categoriaModel == null)
            {
                return HttpNotFound();
            }
            return View(categoriaModel);
        }

        // POST: CategoriaModel/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome")] CategoriaModel categoriaModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(categoriaModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(categoriaModel);
        }

        // GET: CategoriaModel/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CategoriaModel categoriaModel = db.Categorias.Find(id);
            if (categoriaModel == null)
            {
                return HttpNotFound();
            }
            return View(categoriaModel);
        }

        // POST: CategoriaModel/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CategoriaModel categoriaModel = db.Categorias.Find(id);
            db.Categorias.Remove(categoriaModel);
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
    }
}
