using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;

namespace VisiProj.Controllers
{
	public class HomeController : Controller
	{
		public ActionResult Index ()
		{
			List<ImagemProjeto> imagens = new List<ImagemProjeto> ();
			string ext = "jpg";

			for (int i = 1; i <= 11; i++) {
				if ("2,5,7".Contains (i.ToString ()))
					ext = "png";
				else
					ext = "jpg";

				imagens.Add (new ImagemProjeto(){
					UrlNormal = String.Format("/images/projetos/miniatura{0}.{1}", i.ToString().PadLeft(3, '0'), ext),
					Id = i.ToString().PadLeft(3, '0'),
					UrlPequena = String.Format("miniatura{0}.{1}", i.ToString().PadLeft(3, '0'), ext),
					Nome = "nomex1",
					Classificadores = "residencial 2010-2014 completo"
				});
			}

			return View (imagens);
		}
	}
}

