using FluentValidation_Estudo.Domain.Commands;
using FluentValidation_Estudo.Domain.Notification;
using FluentValidation_Estudo.Domain.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace FluentValidation_Estudo.Controllers
{
	[ApiController]
	[Route("/api/persons")]
	public class PersonController : Controller
	{
		private readonly IMediator _bus;
		private readonly IDomainNotificationContext _notificationContext;

		public PersonController(IMediator bus, IDomainNotificationContext notificationContext)
		{
			_bus = bus;
			_notificationContext = notificationContext;
		}

		[HttpPost]
		public async Task<IActionResult> CreatePersonAsync([FromBody] CreatePersonCommand command)
		{
			await _bus.Send(command);

			if (_notificationContext.HasErrorNotifications)
			{
				var notifications = _notificationContext.GetErrorNotifications();
				var message = string.Join(", ", notifications.Select(x => x.Value));
				return BadRequest(message);
			}

			return Ok();
		}

		[HttpGet]
		public async Task<IActionResult> GetPagedAsync([FromQuery] int page = 1, [FromQuery] int pageSize = 10)
		{
			var query = GetPagedPersonsQuery.Create(page, pageSize);
			var pagedPersons = await _bus.Send(query);
			return Ok(pagedPersons);
		}
	}

}
