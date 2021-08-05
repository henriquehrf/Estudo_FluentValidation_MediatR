using MediatR;
using System;

namespace FluentValidation_Estudo.Domain.Commands
{
	public class CreatePersonCommand : IRequest
	{
		public string Nome { get; set; }
		public string Sexo { get; set; }
		public string Email { get; set; }
		public DateTime DataNascimento { get; set; }
		public string Endereco { get; set; }
	}
}
