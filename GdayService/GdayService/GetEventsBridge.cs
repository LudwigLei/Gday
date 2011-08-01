using System.Linq;
using Gday.Domain;
using GdayService.Infrastructure;

namespace GdayService
{
	public class GetEventsBridge
	{
		readonly IGetEventsOperation operation;

		public GetEventsBridge(IGetEventsOperation operation)
		{
			this.operation = operation;
		}

		public Event[] Execute(Date date)
		{
			var result = operation.Execute(DomainMapper.ToDate(date));
			return result.Select(DomainMapper.FromEvent).ToArray();
		}
	}
}