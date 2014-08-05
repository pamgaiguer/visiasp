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
		public ActionResult Index ()
		{
            List<ImagemProjetoModel> imagens = new List<ImagemProjetoModel>();
			string ext = "jpg";

			for (int i = 1; i <= 11; i++) {
				if ("2,5,7".Contains (i.ToString ()))
					ext = "png";
				else
					ext = "jpg";

                imagens.Add(new ImagemProjetoModel()
                {
					UrlNormal = String.Format("/images/projetos/miniatura{0}.{1}", i.ToString().PadLeft(3, '0'), ext),
					Id = i,
					UrlPequena = String.Format("miniatura{0}.{1}", i.ToString().PadLeft(3, '0'), ext),
					Nome = "nomex1",
					Classificadores = "residencial 2010-2014 completo"
				});
			}

			return View (imagens);
		}
	}
}

