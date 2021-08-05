using FluentValidation;

namespace FluentValidation_Estudo.Validators.Custom
{
	public static class EnderecoValidator
	{
		public static IRuleBuilderOptions<T, string> EnderecoDeveConterInformacoesBasicas<T>(this IRuleBuilder<T, string> ruleBuilder)
		{
			return ruleBuilder.Must(endereco => endereco.Contains("Rua"));
		}
	}
}
