using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using VisiProj.Models;

namespace VisiProj.Controllers
{
	public class HomeController : Controller
	{
        private VisiContext db = new VisiContext();
		public ActionResult Index ()
		{
            List<ImagemProjetoModel> imagens = db.ImagemProjetos
                .Where(t => t.Projeto != null && t.Projeto.CategoriaId > 0 && !t.Projeto.Deleted && t.TipoImagem == TipoImagem.FotoCapa)
                .ToList();
                //.GroupBy(t => t.Projeto.Id, (key, g) => g.OrderBy(e => e.Id).FirstOrDefault()).ToList();

			return View(imagens);
		}
	}
}

