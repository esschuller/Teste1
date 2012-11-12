using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MvcApplication1 {
	public class RouteConfig {
		public static void RegisterRoutes(RouteCollection routes) {
			routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

			routes.MapRoute(
				name: "Todas as Notícias",
				url: "Noticias/",
				defaults: new { controller = "Home", action = "TodasNoticias" }
			);
			 
			routes.MapRoute(
				name: "Categoria Específica",
				url: "Noticias/{categoria}",
				defaults: new { controller = "Home", action = "MostraCategoria" }
			);

			routes.MapRoute(
				name: "Mostra Notícia",
				url: "Noticias/{categoria}/{titulo}-{noticiaId}",
				defaults: new { controller = "Home", action = "MostraNoticia" }
			);

			routes.MapRoute(
				name: "Default",
				url: "{controller}/{action}/{id}",
				defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
			);
		}
	}
}