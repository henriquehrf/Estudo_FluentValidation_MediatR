using FluentValidation_Estudo.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FluentValidation_Estudo.Infra.Data
{
	public class PersonRepository : IPersonRepository
	{
		private static readonly List<Person> _person = new List<Person>();

		public async Task CreateAsync(Person user)
			=> await Task.Run(() => _person.Add(user));

		public async Task<IEnumerable<Person>> GetAsync(int page, int pageSize)
			=> await Task.Run(() => _person.Skip((page - 1) * pageSize).Take(pageSize));
	}
}
