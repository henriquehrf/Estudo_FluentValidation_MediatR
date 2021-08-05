using FluentValidation;
using FluentValidation_Estudo.Domain.Commands;
using System;

namespace FluentValidation_Estudo.Domain.Validations
{
	public class CreatePersonCommandValidation : AbstractValidator<CreatePersonCommand>
	{
		public CreatePersonCommandValidation()
		{
			RuleFor(x => x.Nome).NotNull().NotEmpty().WithMessage("Nome é obrigatório.");
			RuleFor(x => x.DataNascimento).NotNull().WithMessage("Data Nascimento é obrigatório.");
		//	RuleFor(x => x.DataNascimento).Must(birthDay => new DateTime(birthDay.Year - 18, birthDay.Month, birthDay.Day) >= birthDay).WithMessage("Menor de 18 anos não permitido.");
		}
	}
}
