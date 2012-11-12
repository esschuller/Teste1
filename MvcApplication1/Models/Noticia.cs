using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Collections.ObjectModel;

namespace MvcApplication1.Models {
	public class Noticia {
		public int NoticiaId { get; set; }
		public string Titulo { get; set; }
		public string Conteudo { get; set; }
		public string Categoria { get; set; }
		
		[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
		public DateTime Data { get; set; }

		public IEnumerable<Noticia> TodasNoticias(){
			var n = new Collection<Noticia>{
				new Noticia{
					NoticiaId = 1,
					Categoria = "Economia",
					Titulo = "Comprar material escolar mais cedo garante descontos",
					Conteudo = "Algumas lojas oferecem abatimento de até 30% no preço e parcelam em até 5 vezes",
					Data = new DateTime(2012,7,11)
				},

				new Noticia{
					NoticiaId = 2,
					Categoria = "Política",
					Titulo = "Denúncia de fraude na pasta das cidades",
					Conteudo = "Sem apoio do PP, Negromonte é mais um cotado para cair",
					Data = new DateTime(2012,7,10)
				},

				new Noticia{
					NoticiaId = 3,
					Categoria = "Geral",
					Titulo = "Viaduto sobre Anhanguera será erguido em 15 meses",
					Conteudo = "Ponte da Henri Nestlé terá 230 metros; previsão é que 10 mil veículos circulem pelo local por dia",
					Data = new DateTime(2012,7,3)
				},

				new Noticia{
					NoticiaId = 4,
					Categoria = "Economia",
					Titulo = "Ruas do Centro têm só 10% dos imóveis desocupados",
					Conteudo = "Varejo disputa trechos da São Sebastião, General e da Américo em Ribeirão Preto",
					Data = new DateTime(2012,7,2)
				},

				new Noticia{
					NoticiaId = 5,
					Categoria = "Saúde",
					Titulo = "Vigilância cobra notificação imediata de casos de dengue",
					Conteudo = "Secretaria da Saúde pede que hospitais particulares realizem teste rápido para poder agir de forma preventiva contra a doença",
					Data = new DateTime(2012,7,1)
				},

				new Noticia{
					NoticiaId = 6,
					Categoria = "Polícial",
					Titulo = "Trio armado faz mulher refém e leva R$ 300 mil em joias",
					Conteudo = "Vítima é de Barrinha e fazia revenda em loja quando foi abordada por bandidos",
					Data = new DateTime(2012,7,5)
				},

				new Noticia{
					NoticiaId = 7,
					Categoria = "Economia",
					Titulo = "Ribeirão Preto tem versão do Black Friday",
					Conteudo = "Estabelecimentos comerciais prometem produtos com descontos de até 80% em ofertas válidas apenas para esta sexta-feira",
					Data = new DateTime(2012,7,7)
				},

				new Noticia{
					NoticiaId = 8,
					Categoria = "Saúde",
					Titulo = "Fumar, agora, só em casa e na rua",
					Conteudo = "Lei federal proíbe os fumódromos em locais fechados",
					Data = new DateTime(2012,7,9)
				},

				new Noticia{
					NoticiaId = 9,
					Categoria = "Geral",
					Titulo = "Ziraldo perde processo por registro indevido de marca no Paraná",
					Conteudo = "Cartunista foi condenado, em Foz do Iguaçu, a dois anos de prisão. Cabe recurso",
					Data = new DateTime(2012,6,8)
				},

				new Noticia{
					NoticiaId = 10,
					Categoria = "Esportes",
					Titulo = "Botafogo segue na busca por último lateral",
					Conteudo = "Lateral-esquerdo Jadílson é discutido pelos diretores, mas diz que deve ir para outro time",
					Data = new DateTime(2012,6,6)
				}
			};

			return n;
		}
	}
}