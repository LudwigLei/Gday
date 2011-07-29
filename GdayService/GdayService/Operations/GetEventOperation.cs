using Gday.Domain;

namespace GdayService.Operations
{
	public interface IGetEventOperation
	{
		Event Execute(int id);
	}

	public class GetEventOperation : IGetEventOperation
	{
		readonly IEventRepository repository;

		public GetEventOperation(IEventRepository repository)
		{
			this.repository = repository;
		}

		public Event Execute(int id)
		{
			return repository.GetEvent(id);
		}
	}
}