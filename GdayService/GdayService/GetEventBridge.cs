using Gday.Domain;
using GdayService.Infrastructure;

namespace GdayService
{
	public class GetEventBridge
	{
		readonly IGetEventOperation operation;

		public GetEventBridge(IGetEventOperation operation)
		{
			this.operation = operation;
		}

		public Event Execute(int id)
		{
			var result = operation.Execute(id);
			return result != null
				? DomainMapper.FromEvent(result)
				: null;
		}
	}
}