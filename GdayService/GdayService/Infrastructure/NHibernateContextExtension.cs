using System;
using System.ServiceModel;
using NHibernate;

namespace GdayService.Infrastructure
{
	class NHibernateContextExtension : IExtension<InstanceContext>
	{
		public ISession Session { get; set; }

		public void Attach(InstanceContext owner)
		{
		}

		public void Detach(InstanceContext owner)
		{
			if (Session == null) return;

			Exception exception;
			if (!TryDisposeSession(Session, out exception))
				LogException(exception);
		}

		static bool TryDisposeSession(ISession session, out Exception exception)
		{
			exception = null;
			try
			{
				session.Flush();
				session.Dispose();
			}
			catch (Exception e)
			{
				exception = e;
			}

			return exception != null;
		}

		static void LogException(Exception exception)
		{
		}
	}
}