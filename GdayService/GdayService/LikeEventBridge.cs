using Gday.Domain;

namespace GdayService
{
	public class LikeEventBridge
	{
		readonly ILikeEventOperation operation;

		public LikeEventBridge(ILikeEventOperation operation)
		{
			this.operation = operation;
		}

		public void Execute(int id)
		{
			operation.Execute(id);
		}
	}
}