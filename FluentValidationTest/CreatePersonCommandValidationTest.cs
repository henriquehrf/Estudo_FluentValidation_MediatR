using FluentValidation.TestHelper;
using FluentValidation_Estudo.Domain.Commands;
using FluentValidation_Estudo.Domain.Entities;
using FluentValidation_Estudo.Domain.Validations;
using FluentValidation_Estudo.Infra.Data;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Xunit;

namespace FluentValidationTest
{
	public class CreatePersonCommandValidationTest
	{
		private CreatePersonCommandValidation _validation;

		public CreatePersonCommandValidationTest()
		{
			var mockRepository = new Mock<IPersonRepository>();

			mockRepository.Setup(e => e.Filter(It.IsAny<Expression<Func<Person, bool>>>()))
					.Returns<Expression<Func<Person, bool>>>(predicate => MockPerson(predicate));

			_validation = new CreatePersonCommandValidation(mockRepository.Object);
		}


		[Fact]
		public void ShouldErrorWhenNameIsNull()
		{
			var personCommand = new CreatePersonCommand()
			{
				DataNascimento = DateTime.Now,
				Email = "henrique_rfirmino@hotmail.com",
				Endereco = "Rua teste",
				Sexo = "M"
			};

			var result = _validation.TestValidate(personCommand);
			result.ShouldHaveValidationErrorFor(person => person.Nome);
		}

		[Fact]
		public void DontShouldError()
		{
			var personCommand = new CreatePersonCommand()
			{
				DataNascimento = DateTime.Now,
				Email = "henrique_rfirmino@hotmail.com",
				Endereco = "Rua teste",
				Sexo = "M",
				Nome = "Henrique Firmino"
			};

			var result = _validation.TestValidate(personCommand);
			result.ShouldNotHaveValidationErrorFor(person => person.Nome);
		}


		[Theory]
		[MemberData(nameof(Parameters))]
		public void ShouldErrorWhenBreakAnyRule<T>(CreatePersonCommand command,
												Expression<Func<CreatePersonCommand, T>> expression)
		{


			var result = _validation.TestValidate(command);
			result.ShouldHaveValidationErrorFor(expression);
		}


		public static IEnumerable<object[]> Parameters()
		{
			yield return new object[]
			{
					new CreatePersonCommand()
					{
						DataNascimento = DateTime.Now,
						Email = "henrique_rfirmino@hotmail.com",
						Endereco = "Rua teste",
						Sexo = "M",
						Nome = ""
					},
					GetParameterFromExpression(e=> e.Nome)
			};

			yield return new object[]
			{
					new CreatePersonCommand()
					{
						Email = "teste",
						Endereco = "Rua teste",
						Sexo = "M",
						Nome = "Henrique"
					},
					GetParameterFromExpression(e=> e.Email)
			};

			yield return new object[]
			{
					new CreatePersonCommand()
					{
						Email = "henrique_rfirmino2@hotmail.com",
						Endereco = "Rua teste",
						Sexo = "M",
						Nome = "Henrique"
					},
					GetParameterFromExpression(e=> e.Email)
			};

			yield return new object[]
			{
					new CreatePersonCommand()
					{
						Email = "henrique_rfirmino23@hotmail.com",
						Endereco = "Rua teste",
						Sexo = "M",
						Nome = "Henrique R. Firmino"
					},
					GetParameterFromExpression(e=> e.Nome)
			};
		}

		private static Expression<Func<CreatePersonCommand, T>> GetParameterFromExpression<T>(Expression<Func<CreatePersonCommand, T>> expression) => expression;

		private Task<IEnumerable<Person>> MockPerson(Expression<Func<Person, bool>> predicate)
		{
			var persons = new List<Person>()
			{
				new Person(nome: "Henrique R. Firmino",
						   sexo: "M",
						   email: "henrique_rfirmino2@hotmail.com",
						   dataNascimento: new DateTime(year: 1995, month: 12, day: 8),
						   endereco: "Rua dos testes")
			};

			return Task.Run(() => persons.Where(predicate.Compile()));
		}
	}
}
