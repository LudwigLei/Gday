using System.Collections.ObjectModel;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;

namespace GdayService.Infrastructure
{
	class DependencyInjectionServiceBehavior : IServiceBehavior
	{
		public void ApplyDispatchBehavior(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
		{
			foreach (var ed in serviceHostBase.ChannelDispatchers
				.OfType<ChannelDispatcher>().SelectMany(cd => cd.Endpoints))
			{
				ed.DispatchRuntime.InstanceProvider = new DependencyInjectionInstanceProvider(
					serviceDescription.ServiceType);
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