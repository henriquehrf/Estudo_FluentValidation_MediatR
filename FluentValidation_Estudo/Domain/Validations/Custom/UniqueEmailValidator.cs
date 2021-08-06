using FluentValidation;
using FluentValidation_Estudo.Infra.Data;
using System.Linq;

namespace FluentValidation_Estudo.Domain.Validations.Custom
{
	public static class UniqueEmailValidator
	{
		public static IRuleBuilderOptions<T, string> UniqueEmailPersonAsync<T>(this IRuleBuilder<T, string> rule, IPersonRepository personRepository)
		{
			return rule.MustAsync(async (email, cancellation) =>
			{
				var result = await personRepository.Filter(e => e.Email == email);

				return !result.Any();
			});
		}
	}
}
