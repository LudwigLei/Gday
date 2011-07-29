using System;
using System.Web;
using GdayService.Infrastructure;

namespace Gday
{
	public class Global : HttpApplication
	{
		protected void Application_Start(object sender, EventArgs e)
		{
			new DependencyInjection().Initialize();
			new NHibernateBootstrapper().Initialize();
		}
	}
}