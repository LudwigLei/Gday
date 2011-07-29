using System;

namespace GdayService.Infrastructure
{
	class ServiceHost : System.ServiceModel.ServiceHost
	{
		public ServiceHost(Type serviceType, params Uri[] baseAddresses)
			: base(serviceType, baseAddresses)
		{
		}

		protected override void OnOpening()
		{
			Description.Behaviors.Add(new DependencyInjectionServiceBehavior());
			base.OnOpening();
		}	}
}