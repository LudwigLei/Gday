using System;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;
using StructureMap;

namespace GdayService.Infrastructure
{
	class DependencyInjectionInstanceProvider : IInstanceProvider
	{
		readonly Type serviceType;

		public DependencyInjectionInstanceProvider(Type serviceType)
		{
			this.serviceType = serviceType;
		}

		public object GetInstance(InstanceContext instanceContext)
		{
			return GetInstance(instanceContext, null);
		}

		public object GetInstance(InstanceContext instanceContext, Message message)
		{
			InstallExtensions(instanceContext);
			return ObjectFactory.GetInstance(serviceType);
		}

		static void InstallExtensions(InstanceContext instanceContext)
		{
			var nhibernateExtension = instanceContext.Extensions.Find<NHibernateContextExtension>();
			if (nhibernateExtension == null)
				instanceContext.Extensions.Add(new NHibernateContextExtension());
		}

		public void ReleaseInstance(InstanceContext instanceContext, object instance)
		{
			UninstallExtensions(instanceContext);
		}

		static void UninstallExtensions(InstanceContext instanceContext)
		{
			var nhibernateExtension = instanceContext.Extensions.Find<NHibernateContextExtension>();
			if (nhibernateExtension != null)
				instanceContext.Extensions.Remove(nhibernateExtension);
		}
	}
}