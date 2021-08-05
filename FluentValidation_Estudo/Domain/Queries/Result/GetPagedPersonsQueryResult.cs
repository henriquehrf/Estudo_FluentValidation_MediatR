using System;

namespace FluentValidation_Estudo.Domain.Queries.Result
{
	public class GetPagedPersonsQueryResult
	{
		public Guid Id { get; set; }
		public string Nome { get; set; }
		public string Sexo { get; set; }
		public string Email { get; set; }
		public DateTime DataNascimento { get; set; }
		public string Endereco { get; set; }
	}
}
