using System.Collections.Generic;

namespace Gday.Domain
{
	public interface IGetEventsOperation
	{
		IEnumerable<Event> Execute(Date date);
	}

	public class GetEventsOperation : IGetEventsOperation
	{
		readonly IEventRepository repository;

		public GetEventsOperation(IEventRepository repository)
		{
			this.repository = repository;
		}

		public IEnumerable<Event> Execute(Date date)
		{
			return repository.GetEvents(date);
		}
	}
}