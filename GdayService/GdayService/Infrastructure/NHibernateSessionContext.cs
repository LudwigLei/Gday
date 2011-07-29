using System;
using System.ServiceModel;
using NHibernate;
using NHibernate.Context;

namespace GdayService.Infrastructure
{
	public class NHibernateSessionContext : ICurrentSessionContext
	{
		readonly ISessionFactory factory;

		public NHibernateSessionContext(ISessionFactory factory)
		{
			this.factory = factory;
		}

		public ISession CurrentSession()
		{
			var contextExtension = OperationContext.Current
				.InstanceContext.Extensions.Find<NHibernateContextExtension>();
			if (contextExtension == null)
				throw new InvalidOperationException("NHibernate support requires an InstanceContext extension.");

			return EnsureSession(contextExtension);
		}

		ISession EnsureSession(NHibernateContextExtension contextExtension)
		{
			var session = contextExtension.Session;
			if (session == null)
			{
				session = factory.OpenSession();
				contextExtension.Session = session;
			}

			return session;
		}
	}
}