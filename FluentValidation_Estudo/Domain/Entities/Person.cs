using FluentValidation_Estudo.Domain.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FluentValidation_Estudo.Domain.Entities
{
	public class Person
	{
		public Guid Id { get; protected set; }
		public string Nome { get; protected set; }
		public string Sexo { get; protected set; }
		public string Email { get; protected set; }
		public DateTime DataNascimento { get; protected set; }
		public string Endereco { get; protected set; }
		public DateTime DataHoraCriacao { get; protected set; }
		public bool Ativo { get; protected set; }

		public Person()
		{

		}

		public Person(string nome,
						string sexo,
						string email,
						DateTime dataNascimento,
						string endereco)
		{
			Id = Guid.NewGuid();
			Nome = nome;
			Sexo = sexo;
			Email = email;
			DataNascimento = dataNascimento;
			Endereco = endereco;
			DataHoraCriacao = DateTime.Now;
			Ativo = true;
		}

		public static Person Create(CreatePersonCommand command)
		   => new Person(command.Nome,
						command.Sexo,
						command.Email,
						command.DataNascimento,
						command.Endereco);
	}
}
