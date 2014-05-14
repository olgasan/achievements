public class Locator : ServiceLocator 
{
	private static IServiceLocator instance;
	private EventListenerForAchievements eventListenerForAchievements;
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
		eventListenerForAchievements = new EventListenerForAchievements (achieve);

		AddService (typeof (EventListenerForAchievements), eventListenerForAchievements);
		AddService (typeof (Achieve), achieve);
	}
}
