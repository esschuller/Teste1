using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace MvcApplication1.Models {
	public class Pessoa {
		public int PessoaID { get; set; }

		[Required(ErrorMessage="Informe o nome")]
		public string Nome { get; set; }
		
		public string Twitter { get; set; }
		
		[StringLength(50, MinimumLength = 5, ErrorMessage = "Observação deve ter entre 5 e 50 caracteres")]
		[Required(ErrorMessage = "Informe a observação")]
		public string Observacao { get; set; }

		[Range(18,50, ErrorMessage = "A idade deve ser entre 18 e 50 anos")]
		[Required(ErrorMessage = "Informe a idade")]
		public int Idade { get; set; }

		[RegularExpression(@"^[A-Za-z0-9](([_\.\-]?[a-zA-Z0-9]+)*)@([A-Za-z0-9]+)(([\.\-]?[a-zA-Z0-9]+)*)\.([A-Za-z]{2,})$", ErrorMessage = "E-mail inválido")]
		public string Email { get; set; }
		
		[RegularExpression(@"[a-zA-Z]{5,15}", ErrorMessage = "Formato de Login inválido")]
		[Required(ErrorMessage = "Informe o Login")]
		[Remote("LoginUnico","Pessoa", ErrorMessage = "Este login já existe")]
		public string Login { get; set; }
		
		[Required(ErrorMessage = "Informe a senha")]
		public string Senha { get; set; }
		
		[Compare("Senha", ErrorMessage = "As senhas não conferem")]
		public string ConfirmarSenha { get; set; }
		
	}
}