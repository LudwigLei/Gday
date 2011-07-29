using System.Collections.Generic;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using Gday.Data;
using NHibernate;
using StructureMap;

namespace GdayService.Infrastructure
{
	public class NHibernateBootstrapper
	{
		public void Initialize()
		{
			var sessionFactory = Configure().BuildSessionFactory();
			ObjectFactory.Configure(config =>
				config.For<ISession>().Use(sessionFactory.GetCurrentSession));
		}

		static FluentConfiguration Configure()
		{
			return Fluently.Configure()
				.Database(
					MsSqlConfiguration.MsSql2008.ConnectionString(
						x => x.FromConnectionStringWithKey("Gday")))
				.ExposeConfiguration(c => c
					.SetProperty("proxyfactory.factory_class", ProxyFactoryClassKey)
					.SetProperty("current_session_context_class", CurrentSessionContextKey))
				.Mappings(m => m.FluentMappings.AddFromAssemblyOf<EventMap>());
		}

		const string ProxyFactoryClassKey = "NHibernate.ByteCode.Castle.ProxyFactoryFactory, NHibernate.ByteCode.Castle";

		static string CurrentSessionContextKey
		{
			get
			{
				return string.Concat(
					typeof (NHibernateSessionContext).FullName, ", ",
					typeof (NHibernateSessionContext).Assembly.FullName);
			}
		}
	}
}