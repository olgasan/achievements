using Brainz;

public class EventListenerForAchievements
{
	private Achieve achieve;

	public EventListenerForAchievements (Achieve achieve)
	{
		this.achieve = achieve;
	}

	public void OnKill ()
	{
		achieve.OnEvent ("kill");
	}
	
	public void OnGrind ()
	{
		achieve.OnEvent ("grind");
	}
}
