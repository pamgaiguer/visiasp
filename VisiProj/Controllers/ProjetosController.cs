﻿using System;
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
        /// Get categories by id category
        /// 
        /// If id is null, return all
        /// </summary>
        /// <param name="id">Category id</param>
        /// <returns>Html page with projects</returns>
        public ActionResult Index(int? catId, int? projId)
        {
            List<CategoriaModel> cats = db.Categorias.ToList();
            List<ProjetoModel> p = new List<ProjetoModel>();
            List<ImagemProjetoModel> img = new List<ImagemProjetoModel>();

            if (catId != null && catId > 0)
            {
                p = db.Projetos.Where(proj => proj.CategoriaId == catId).ToList();

                if (projId != null && projId > 0)
                {
                    img = db.Projetos.Where(proj => proj.Id == projId).FirstOrDefault().Imagens.ToList();
                }
                else
                {
                    foreach (var item in p)
                    {
                        img.AddRange(item.Imagens);
                    }
                }
            }
            else
            {
                img = db.ImagemProjetos.Where(t => t.Projeto != null).ToList();
            }

            ViewBag.CatId = catId;
            ViewBag.ProjId = projId;
            ViewBag.Projects = p;
            ViewBag.Images = img;

            return View (cats);
        }
    }
}
