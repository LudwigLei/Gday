using Gday.Infrastructure;
using StructureMap;

namespace GdayService
{
	[NHibernateSessionBehavior]
	public class Service : IService
	{
		public void LikeEvent(int id)
		{
			Bridge<LikeEventBridge>().Execute(id);
		}

		public Event GetEvent(int id)
		{
			return Bridge<GetEventBridge>().Execute(id);
		}

		public Event[] GetEvents(Date date)
		{
			return Bridge<GetEventsBridge>().Execute(date);
		}

		static T Bridge<T>()
		{
			return ObjectFactory.GetInstance<T>();
		}
	}
}
