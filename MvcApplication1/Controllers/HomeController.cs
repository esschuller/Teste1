using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApplication1.Models;

namespace MvcApplication1.Controllers {
	public class HomeController : Controller {
		
		private readonly IEnumerable<Noticia> noticias;

		public HomeController() {
			noticias = new Noticia().TodasNoticias().OrderByDescending(x => x.Data);

		}

		public ActionResult Index() {
			
			var ultimasNoticias = noticias.Take(3);
			var categorias = noticias.Select(x => x.Categoria).Distinct().ToList();
			
			ViewBag.Categorias = categorias;

			return View(ultimasNoticias);
		}

		public ActionResult Sobre(){
			return View();
		}

		public ActionResult TodasNoticias (){
			return View(noticias);
		}

		public ActionResult MostraNoticia(int noticiaId, string categoria, string titulo) {
			return View(noticias.FirstOrDefault(x => x.NoticiaId == noticiaId));

		}

		public ActionResult MostraCategoria(string categoria){
			var not = noticias.Where(x => x.Categoria.ToLower() == categoria.ToLower()).ToList();
			
			ViewBag.Categoria = categoria;
			return View(not);
		}

	}
}
