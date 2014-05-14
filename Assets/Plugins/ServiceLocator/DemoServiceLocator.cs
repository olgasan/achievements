using UnityEngine;

public class DemoServiceLocator : ServiceLocator
{
	private static DemoServiceLocator _instance;

	public static DemoServiceLocator Instance
	{
		get
		{
			if (_instance == null)
				_instance = new DemoServiceLocator ();

			return _instance;
		}
	}

	internal DemoServiceLocator () : base ()
	{
		AddService (typeof(IServiceA), new ServiceA ());
		AddService (typeof(IServiceB), new ServiceB ());
	}
}

public interface IServiceA
{
	int a { get; }
}

public interface IServiceB
{
	string b { get; }
}

public class ServiceA : IServiceA
{
	public int a { get; private set; }
}

public class ServiceB : IServiceB
{
	public string b { get; private set; }
}