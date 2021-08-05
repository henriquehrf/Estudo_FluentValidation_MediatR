using FluentValidation;
using FluentValidation_Estudo.Models;
using FluentValidation_Estudo.Validators.Custom;
using System;

namespace FluentValidation_Estudo.Validators
{
	public class AdicionarPessoaValidator : AbstractValidator<PessoaViewModel>
	{
		public AdicionarPessoaValidator()
		{
			RuleFor(p => p.Nome)
				.NotEmpty()
					.WithMessage("É obrigatório informar um nome.");

			RuleFor(p => p.DataNascimento)
					.LessThanOrEqualTo(DateTime.Today.AddYears(-18))
						.WithMessage("É obrigatório idade igual e/ou superior a 18 anos.");

			RuleFor(p => p.Email)
					.EmailAddress()
						.WithMessage("Email inválido!.");

			RuleFor(p => p.Endereco)
					.EnderecoDeveConterInformacoesBasicas()
						.WithMessage("O endereço deve conter informações da rua!");

		}
	}
}
