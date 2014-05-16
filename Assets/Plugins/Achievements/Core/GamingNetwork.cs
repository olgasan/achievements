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

		SetUpListenters ();
	}

	public void Init ()
	{
		this.adapter.Init ();
	}
	
	private void SetUpListenters ()
	{
		achieve.AchievementRegistered += OnAchievementRegistered;
		achieve.AchievementUnlocked += OnAchievementUnlocked;
	}

	private void OnAchievementRegistered (IAchievement achievement)
	{
		Achievements.Add (achievement);
		adapter.Register (achievement);
	}

	private void OnAchievementUnlocked (IAchievement achievement)
	{
		adapter.Unlocked (achievement);
	}
}
