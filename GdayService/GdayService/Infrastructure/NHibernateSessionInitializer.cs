using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;
using NHibernate;
using NHibernate.Context;
using StructureMap;

namespace Gday.Infrastructure
{
	public class NHibernateSessionInitializer : IDispatchMessageInspector
	{
		private static ISessionFactory SessionFactory
		{
			get { return  ObjectFactory.GetInstance<ISessionFactory>(); }
		}

		public object AfterReceiveRequest(ref Message request, IClientChannel channel, InstanceContext instanceContext)
		{
			CurrentSessionContext.Bind(SessionFactory.OpenSession());
			return null;
		}

		public void BeforeSendReply(ref Message reply, object correlationState)
		{
			var session = CurrentSessionContext.Unbind(SessionFactory);
			session.Dispose();
		}
	}
}