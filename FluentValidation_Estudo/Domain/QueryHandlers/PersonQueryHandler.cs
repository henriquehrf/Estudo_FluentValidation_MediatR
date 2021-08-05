using FluentValidation_Estudo.Domain.Queries;
using FluentValidation_Estudo.Domain.Queries.Result;
using FluentValidation_Estudo.Infra.Data;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace FluentValidation_Estudo.Domain.QueryHandlers
{
	public class PersonQueryHandler : IRequestHandler<GetPagedPersonsQuery, IEnumerable<GetPagedPersonsQueryResult>>
	{
		private readonly IPersonRepository _personRepository;

		public PersonQueryHandler(IPersonRepository personRepository)
		{
			_personRepository = personRepository;
		}

		public async Task<IEnumerable<GetPagedPersonsQueryResult>> Handle(GetPagedPersonsQuery request, CancellationToken cancellationToken)
		{
			var users = await _personRepository.GetAsync(request.Page, request.PageSize);

			return users.Select(x => new GetPagedPersonsQueryResult
			{
				Id = x.Id,
				Nome = x.Nome,
				DataNascimento = x.DataNascimento,
				Email = x.Email,
				Sexo = x.Sexo,
				Endereco = x.Endereco,
			});
		}
	}
}
