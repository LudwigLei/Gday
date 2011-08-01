
using NHibernate;

namespace Gday.Domain
{
	public interface ILikeEventOperation
	{
		void Execute(int id);
	}

	public class LikeEventOperation : ILikeEventOperation
	{
		readonly ISession session;
		readonly IEventRepository repository;

		public LikeEventOperation(ISession session, IEventRepository repository)
		{
			this.session = session;
			this.repository = repository;
		}

		public void Execute(int id)
		{
			using (var t = session.BeginTransaction())
			{
				var value = repository.GetEvent(id);
				if (value != null)
				{
					value.Rank++;
					repository.Save(value);
				}
				t.Commit();
			}
		}
	}
}