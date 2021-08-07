using FluentValidation;
using FluentValidation_Estudo.Domain.Commands;
using FluentValidation_Estudo.Domain.Validations.Custom;
using FluentValidation_Estudo.Infra.Data;
using System.Linq;

namespace FluentValidation_Estudo.Domain.Validations
{
	public class CreatePersonCommandValidation : AbstractValidator<CreatePersonCommand>
	{

		public CreatePersonCommandValidation(IPersonRepository personRepository)
		{
			RuleFor(x => x.Nome).NotNull().NotEmpty().WithMessage("Nome é obrigatório.");
			RuleFor(x => x.DataNascimento).NotNull().WithMessage("Data Nascimento é obrigatório.");

			RuleFor(x => x.Email).EmailAddress().WithMessage("Email inválido.");
			RuleFor(x => x.Email).UniqueEmailPersonAsync(personRepository).WithMessage("Email já cadastrado.");

			RuleFor(x => x.Nome).MustAsync(async (nome, cancellation) =>
			{
				var result = await personRepository.Filter(e => e.Nome == nome);
				return !result.Any();
			}).WithMessage("Nome já foi cadastrado.");
		}
	}
}
