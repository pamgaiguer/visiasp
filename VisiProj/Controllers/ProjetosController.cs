using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VisiProj.Models;

namespace VisiProj.Controllers
{
    public class ProjetosController : Controller
    {
        private VisiContext db = new VisiContext();

        /// <summary>
        /// Get projects by id project
        /// 
        /// If id is null, return all
        /// </summary>
        /// <param name="id">Project id</param>
        /// <returns>Html page with projects</returns>
        public ActionResult Index(int? id)
        {
            List<ProjetoModel> p = db.Projetos.Where(t => !t.Deleted).ToList();
            List<ImagemProjetoModel> img = new List<ImagemProjetoModel>();

            if (id != null || id == 0)
                img = p.Where(t => t.Id == id).FirstOrDefault().Imagens.ToList();
            else
                p.ForEach(i =>
                {
                    img.AddRange(i.Imagens);
                });

            ViewBag.ActiveId = id;
            ViewBag.Imagens = img;

            return View (p);
        }
    }
}
