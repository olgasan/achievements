using UnityEngine;
using System.Collections.Generic;

public abstract class ServiceLocator : IServiceLocator
{
	private IDictionary<object, object> services;
	
	public ServiceLocator ()
	{
		services = new Dictionary<object, object> ();
	}
	
	public T GetService<T> ()
	{
		try
		{
			return (T)services [typeof(T)];
		}
		catch (KeyNotFoundException)
		{
			throw new UnityException ("The requested service is not registered");
		}
	}

	protected void AddService (object type, object service)
	{
		services.Add (type, service);
	}
}