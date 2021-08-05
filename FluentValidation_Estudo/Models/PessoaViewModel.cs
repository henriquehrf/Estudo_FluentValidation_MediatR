using System;

namespace FluentValidation_Estudo.Models
{
	public class PessoaViewModel
	{
		public Guid Id { get; set; }
		public string Nome { get; set; }
		public string Sexo { get; set; }
		public string Email { get; set; }
		public DateTime DataNascimento { get; set; }
		public string Endereco { get; set; }
	}
}
