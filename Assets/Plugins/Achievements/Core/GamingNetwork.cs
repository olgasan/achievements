using System.Collections.Generic;

public class GamingNetwork
{
	private Achieve achieve;

	public List<IAchievement> Achievements 
	{
		get;
		private set;
	}

	public GamingNetwork (Achieve achieve)
	{
		Achievements = new List<IAchievement> ();
		this.achieve = achieve;

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
