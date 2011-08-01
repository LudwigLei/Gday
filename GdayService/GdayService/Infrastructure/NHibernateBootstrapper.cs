using NHibernate;
using NHibernate.Context;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using StructureMap;
using Gday.Data;

namespace GdayService.Infrastructure
{
	public class NHibernateBootstrapper
	{
		public void Initialize()
		{
			var sessionFactory = Configure().BuildSessionFactory();
			ObjectFactory.Configure(config => {
				config.For<ISessionFactory>().Use(sessionFactory);
				config.For<ISession>().Use(sessionFactory.GetCurrentSession);
			});
		}

		static FluentConfiguration Configure()
		{
			return Fluently.Configure()
				.Database(
					MsSqlConfiguration.MsSql2008.ConnectionString(
						x => x.FromConnectionStringWithKey("Gday")))
				.ExposeConfiguration(c => c
					.SetProperty("proxyfactory.factory_class", "NHibernate.ByteCode.Castle.ProxyFactoryFactory, NHibernate.ByteCode.Castle")
					.SetProperty("current_session_context_class", typeof(WcfOperationSessionContext).FullName))
				.Mappings(m => m.FluentMappings.AddFromAssemblyOf<EventMap>());
		}
	}
}