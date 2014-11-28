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
        /// Get categories by id category
        /// 
        /// If id is null, return all
        /// </summary>
        /// <param name="id">Category id</param>
        /// <returns>Html page with projects</returns>
        public ActionResult Index(int? catId, int? projId)
        {
            IndexViewModel view = new IndexViewModel()
            {
                ProjetoId = projId == null ? 0 : projId,
                CategoriaId = catId == null ? 0 : catId
            };

            view.Categorias = db.Categorias.OrderBy(t => t.Nome).ToList();
            view.Projetos = db.Projetos.Where(proj => proj.CategoriaId > 0 && !proj.Deleted).ToList();

            if (view.CategoriaId == 0)
            {
                view.Imagens = db.ImagemProjetos.Where(t => t.TipoImagem == TipoImagem.Thumb && t.Projeto != null && !t.Projeto.Deleted).ToList();
            }
            else 
            {
                if (view.ProjetoId == 0)
                {
                    view.Imagens = db.ImagemProjetos.Where(t => t.TipoImagem == TipoImagem.Thumb && 
                        t.Projeto != null && !t.Projeto.Deleted && t.Projeto.CategoriaId == view.CategoriaId).ToList();
                }
                else
                {
                    view.Imagens = db.ImagemProjetos.Where(t => t.TipoImagem == TipoImagem.Thumb && 
                        t.Projeto != null && !t.Projeto.Deleted && t.Projeto.Id == view.ProjetoId).ToList();
                }
            }

            return View (view);
        }

        public ActionResult GetThumb(int? categId)
        {
            List<ImagemProjetoModel> img = new List<ImagemProjetoModel>();

            if (categId != null && categId > 0)
            {
                img = db.ImagemProjetos.Where(t => t.Projeto != null && !t.Projeto.Deleted && t.Projeto.CategoriaId == categId &&
                    t.TipoImagem == TipoImagem.Thumb).ToList();
            }
            else
            {
                img = db.ImagemProjetos.Where(t => t.Projeto != null && !t.Projeto.Deleted && t.TipoImagem == TipoImagem.Thumb).ToList();
            }

            return PartialView("_Thumb", img);
        }

        public ActionResult GetSlideShow(int projId)
        {
            List<ImagemProjetoModel> img = new List<ImagemProjetoModel>();

            img = db.ImagemProjetos.Where(t => t.Projeto.Id == projId && 
                t.TipoImagem == TipoImagem.SlideShow).ToList();

            return PartialView("_SlideShow", img);
        }
    }
}
