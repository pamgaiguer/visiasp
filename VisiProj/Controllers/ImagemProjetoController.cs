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
    public class ImagemProjetoController : Controller
    {
        private VisiContext db = new VisiContext();

        // GET: ImagemProjeto
        public ActionResult Index(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            ViewBag.ProjetoId = id;

            return View(db.ImagemProjetos.Where(t => t.Projeto.Id == id).ToList());
        }

        // GET: ImagemProjeto/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ImagemProjetoModel imagemProjetoModel = db.ImagemProjetos.Find(id);
            if (imagemProjetoModel == null)
            {
                return HttpNotFound();
            }
            return View(imagemProjetoModel);
        }

        // GET: ImagemProjeto/Create
        public ActionResult Create(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            ImagemProjetoModel m = new ImagemProjetoModel();
            m.Projeto = db.Projetos.Find(id);

            if (m.Projeto == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            return View(m);
        }

        // POST: ImagemProjeto/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Projeto,UrlNormal,UrlMiniatura,TipoImagem")] ImagemProjetoModel imagemProjetoModel)
        {
            if (ModelState.IsValid)
            {
                imagemProjetoModel.Projeto = db.Projetos.Find(imagemProjetoModel.Projeto.Id);
                db.ImagemProjetos.Add(imagemProjetoModel);
                db.SaveChanges();
                return RedirectToAction("Index", new { id = imagemProjetoModel.Projeto.Id });
            }

            return View(imagemProjetoModel);
        }

        // GET: ImagemProjeto/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ImagemProjetoModel imagemProjetoModel = db.ImagemProjetos.Find(id);
            if (imagemProjetoModel == null)
            {
                return HttpNotFound();
            }
            return View(imagemProjetoModel);
        }

        // POST: ImagemProjeto/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Projeto,UrlNormal,UrlMiniatura,TipoImagem")] ImagemProjetoModel imagemProjetoModel)
        {
            if (ModelState.IsValid)
            {
                imagemProjetoModel.Projeto = db.Projetos.Find(imagemProjetoModel.Projeto.Id);
                db.Entry(imagemProjetoModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", new { id = imagemProjetoModel.Projeto.Id });
            }
            return View(imagemProjetoModel);
        }

        // GET: ImagemProjeto/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ImagemProjetoModel imagemProjetoModel = db.ImagemProjetos.Find(id);
            if (imagemProjetoModel == null)
            {
                return HttpNotFound();
            }
            return View(imagemProjetoModel);
        }

        // POST: ImagemProjeto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ImagemProjetoModel imagemProjetoModel = db.ImagemProjetos.Find(id);
            db.ImagemProjetos.Remove(imagemProjetoModel);
            db.SaveChanges();
            return RedirectToAction("Index", new { id = imagemProjetoModel.Projeto.Id });
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
