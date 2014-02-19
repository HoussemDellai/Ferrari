using System;
using System.Collections.Generic;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;

namespace Ferrari.Configurations
{
	public class UnityServiceLocator : IServiceLocator
	{
		private readonly IUnityContainer _container;

		public UnityServiceLocator(IUnityContainer container)
		{
			_container = container;
		}

		public object GetInstance(Type serviceType)
		{
			return _container.Resolve(serviceType);
		}

		public object GetInstance(Type serviceType, string key)
		{
			return _container.Resolve(serviceType, key);
		}

		public IEnumerable<object> GetAllInstances(Type serviceType)
		{
			return _container.ResolveAll(serviceType);
		}

		public TService GetInstance<TService>()
		{
			return _container.Resolve<TService>();
		}

		public TService GetInstance<TService>(string key)
		{
			return _container.Resolve<TService>(key);
		}

		public IEnumerable<TService> GetAllInstances<TService>()
		{
			return _container.ResolveAll<TService>();
		}

		public object GetService(Type serviceType)
		{
			return GetInstance(serviceType);
		}
	}
}
