using System.Collections.Generic;

public class GamingNetwork
{
	private Achieve achieve;
	private IGamingNetworkAdapter adapter;

	public List<IAchievement> Achievements 
	{
		get { return adapter.Achievements; }
	}

	public GamingNetwork (Achieve achieve, IGamingNetworkAdapter adapter)
	{
		this.achieve = achieve;

		this.adapter = adapter;
		this.adapter.Init ();

		SetUpListenters ();
	}

	private void SetUpListenters ()
	{
		achieve.AchievementRegistered += OnAchievementRegistered;
	}

	private void OnAchievementRegistered (IAchievement newAchievement)
	{
		Achievements.Add (newAchievement);
	}
}
