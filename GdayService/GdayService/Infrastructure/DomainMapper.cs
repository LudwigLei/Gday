using Gday;
using Domain = Gday.Domain;

namespace GdayService.Infrastructure
{
	public class DomainMapper
	{
		public static Event FromEvent(Domain.Event @event)
		{
			return new Event {
				Id = @event.Id,
				Name = @event.Name,
				Description = @event.Description,
				Date = FromDate(@event.Date)
			};			
		}

		public static Date FromDate(Domain.Date date)
		{
			return new Date {
				Day = date.Day,
				Month = date.Month,
				Year = date.Year
			};
		}

		public static Domain.Date ToDate(Date date)
		{
			return new Domain.Date {
				Day = date.Day,
				Month = date.Month,
				Year = date.Year
			};			
		}
	}
}