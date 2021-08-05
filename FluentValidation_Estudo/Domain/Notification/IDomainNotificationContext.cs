using System.Collections.Generic;

namespace FluentValidation_Estudo.Domain.Notification
{
	public interface IDomainNotificationContext
	{
		bool HasErrorNotifications { get; }
		void NotifyError(string message);
		void NotifySuccess(string message);

		List<DomainNotification> GetErrorNotifications();
	}
}
