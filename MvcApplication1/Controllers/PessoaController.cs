using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApplication1.Models;

namespace MvcApplication1.Controllers {
	public class PessoaController : Controller {
		//
		// GET: /Pessoa/

		public ActionResult Index() {

			//var pessoa = new Pessoa() { PessoaID = 1, Nome = "Emerson", Twitter = "@emerson" };
			var pessoa = new Pessoa();

			/*ViewBag.PessoaID = pessoa.PessoaID;
			ViewBag.Nome = pessoa.Nome;
			ViewBag.Twitter = pessoa.Twitter;*/

			/*ViewData["PessoaID"] = pessoa.PessoaID;
			ViewData["Nome"] = pessoa.Nome;
			ViewData["Twitter"] = pessoa.Twitter;*/

			return View(pessoa);
		}

		[HttpPost]
		public ActionResult Index(Pessoa pessoa) {

			if (String.IsNullOrEmpty(pessoa.Twitter)) {
				ModelState.AddModelError("", "Informe o Twitter");
			}




			if (ModelState.IsValid) {
				return View("Resultado", pessoa);
			}

			return View(pessoa);
		}

		public ActionResult Resultado(Pessoa pessoa) {
			return View(pessoa);
		}



		[HttpPost]
		public ActionResult Lista(Pessoa p) {
			/*ViewData["PessoaID"] = p.PessoaID;
			ViewData["Nome"] = p.Nome;
			ViewData["Twitter"] = p.Twitter;*/

			return View(p);
		}

		public ActionResult LoginUnico(String login) {
			var bdNome = new List<String>();
			bdNome.Add("Ze");
			bdNome.Add("Joao");
			bdNome.Add("Emerson");

			return Json(bdNome.All(x => x.ToLower() != login.ToLower()), JsonRequestBehavior.AllowGet);
		}

	}
}
