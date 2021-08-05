using FluentValidation_Estudo.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FluentValidation_Estudo.Infra.Data
{
	public interface IPersonRepository
	{
		Task CreateAsync(Person person);
		Task<IEnumerable<Person>> GetAsync(int page, int pageSize);
	}
}
