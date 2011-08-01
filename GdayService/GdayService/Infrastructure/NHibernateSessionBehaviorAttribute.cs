using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;

namespace Gday.Infrastructure
{
	public class NHibernateSessionBehaviorAttribute : Attribute, IServiceBehavior
	{
		public void ApplyDispatchBehavior(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
		{
			var dispatchers = serviceHostBase.ChannelDispatchers.Cast<ChannelDispatcher>();
			foreach (var endpoint in dispatchers.SelectMany(dispatcher => dispatcher.Endpoints))
			{
				endpoint.DispatchRuntime.MessageInspectors.Add(
					new NHibernateSessionInitializer());
			}
		}

		public void AddBindingParameters(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase, Collection<ServiceEndpoint> endpoints, BindingParameterCollection bindingParameters)
		{
		}

		public void Validate(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
		{
		}
	}
}