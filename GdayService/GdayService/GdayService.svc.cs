using System.Linq;
using System.ServiceModel;
using GdayService.Operations;

namespace Gday
{
	[ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
	public class GdayService : IGdayService
	{
		readonly IGetEventOperation getEventOperation;
		readonly IGetEventsOperation getEventsOperation;
		readonly ILikeEventOperation likeEventOperation;

		public GdayService(
			IGetEventOperation getEventOperation,
			IGetEventsOperation getEventsOperation,
			ILikeEventOperation likeEventOperation)
		{
			this.getEventOperation = getEventOperation;
			this.getEventsOperation = getEventsOperation;
			this.likeEventOperation = likeEventOperation;
		}

		public void LikeEvent(int id)
		{
			likeEventOperation.Execute(id);
		}

		public Event GetEvent(int id)
		{
			var value = getEventOperation.Execute(id);
			return value == null ? null : MapEvent(value);
		}

		public Event[] GetEvents(Date date)
		{
			var when = new Domain.Date {
				Day = date.Day,
				Month = date.Month,
				Year = date.Year
			};

			var events = getEventsOperation
				.Execute(when)
				.Select(MapEvent);
			return events.ToArray();
		}

		static Event MapEvent(Domain.Event e)
		{
			return new Event {
				Id = e.Id,
				Name = e.Name,
				Description = e.Description,
				Date = new Date {
					Day = e.Date.Day,
					Month = e.Date.Month,
					Year = e.Date.Year
				}
			};
		}
	}
}
