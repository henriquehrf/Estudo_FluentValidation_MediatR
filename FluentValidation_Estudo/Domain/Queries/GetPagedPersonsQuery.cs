using FluentValidation_Estudo.Domain.Queries.Result;
using MediatR;
using System.Collections.Generic;

namespace FluentValidation_Estudo.Domain.Queries
{
	public class GetPagedPersonsQuery : IRequest<IEnumerable<GetPagedPersonsQueryResult>>
	{
		public GetPagedPersonsQuery(int page, int pageSize)
		{
			Page = page;
			PageSize = pageSize;
		}

		public int Page { get; protected set; }
		public int PageSize { get; protected set; }

		public static GetPagedPersonsQuery Create(int page, int pageSize)
			=> new GetPagedPersonsQuery(page, pageSize);

	}
}
