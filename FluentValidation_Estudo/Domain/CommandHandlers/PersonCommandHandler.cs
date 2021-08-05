using FluentValidation_Estudo.Domain.Commands;
using FluentValidation_Estudo.Domain.Entities;
using FluentValidation_Estudo.Infra.Data;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace FluentValidation_Estudo.Domain.CommandHandlers
{
	public class PersonCommandHandler : AsyncRequestHandler<CreatePersonCommand>
	{
		private readonly IPersonRepository _personRepository;

		public PersonCommandHandler(IPersonRepository personRepository)
		{
			_personRepository = personRepository;
		}

		protected override async Task Handle(CreatePersonCommand request, CancellationToken cancellationToken)
		{
			var user = Person.Create(request);

			await _personRepository.CreateAsync(user);
		}
	}
}
