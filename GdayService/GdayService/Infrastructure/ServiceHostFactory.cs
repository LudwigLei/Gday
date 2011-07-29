using System;

namespace GdayService.Infrastructure
{
	public class ServiceHostFactory
		: System.ServiceModel.Activation.ServiceHostFactory
	{
		protected override System.ServiceModel.ServiceHost CreateServiceHost(Type serviceType, Uri[] baseAddresses)
		{
			return new ServiceHost(serviceType, baseAddresses);
		}
	}
}