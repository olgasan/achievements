using Brainz;

public class Locator : ServiceLocator 
{
	private static IServiceLocator instance;
	private Achieve achieve;

	public static IServiceLocator Instance
	{
		get
		{
			if (instance == null)
				instance = new Locator ();

			return instance;
		}
	}

	private Locator () : base ()
	{
		achieve = new Achieve ();
		AddService (typeof (Achieve), achieve);
	}
}
