using FluentValidation_Estudo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FluentValidation_Estudo.Infra.Data
{
	public interface IPersonRepository
	{
		Task CreateAsync(Person person);
		Task<IEnumerable<Person>> GetAsync(int page, int pageSize);

		Task<IEnumerable<Person>> Filter(Expression<Func<Person, bool>> predicate);
	}
}
