using Gday.Domain;
using StructureMap;

namespace GdayService.Infrastructure
{
	public class DependencyInjection : IBootstrapper
	{
		public void Initialize()
		{
			ObjectFactory.Initialize(config => {
				config.For<IGetEventOperation>().Use<GetEventOperation>();
				config.For<IGetEventsOperation>().Use<GetEventsOperation>();
				config.For<ILikeEventOperation>().Use<LikeEventOperation>();
				config.For<IEventRepository>().Use<EventRepository>();
			});
		}

		void IBootstrapper.BootstrapStructureMap()
		{
			Initialize();
		}
	}
}