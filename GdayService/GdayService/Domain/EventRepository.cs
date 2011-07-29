using System.Collections.Generic;
using NHibernate;
using NHibernate.Criterion;

namespace Gday.Domain
{
	public interface IEventRepository
	{
		Event GetEvent(int id);
		IEnumerable<Event> GetEvents(Date date);
		void Save(Event @event);
	}

	public class EventRepository : IEventRepository
	{
		readonly ISession session;

		public EventRepository(ISession session)
		{
			this.session = session;
		}

		public Event GetEvent(int id)
		{
			return session.Get<Event>(id);
		}

		public IEnumerable<Event> GetEvents(Date date)
		{
			return session
				.CreateCriteria(typeof (Event))
				.AddOrder(Order.Desc("Rank"))
				.List<Event>();
		}

		public void Save(Event value)
		{
			session.Save(value);
		}
	}
}