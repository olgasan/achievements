using System.Collections.Generic;
using System;

public class Achieve 
{
	public event Action<IAchievement> AchievementUnlocked;
	private List<IAchievement> achievements;

	public Achieve ()
	{
		achievements = new List<IAchievement> ();
	}

	public void Register (IAchievement achievement)
	{
		ValidateAchievement (achievement);
		achievements.Add (achievement);
		achievement.Unlocked += OnAchievementUnlocked;
	}

	public void OnEvent (string eventType)
	{
		foreach (IAchievement achievement in achievements)
		{
			if (achievement.Type == eventType)
			{
				achievement.Progress ++;
			}
		}
	}

	private void OnAchievementUnlocked (IAchievement achievement)
	{
		if (AchievementUnlocked != null)
		{
			AchievementUnlocked (achievement);
		}
	}

	private void ValidateAchievement (IAchievement achievement)
	{
		if (achievement == null)
		{
			throw new System.ArgumentException ("Cannot register null achievements");
		}
		else if (string.IsNullOrEmpty (achievement.Id))
		{
			throw new System.ArgumentException ("Cannot register achievements with null or empty Id");
		}
		else if (Find (achievement.Id) != null)
		{
			throw new System.ArgumentException ("Cannot register achievements with the same Id");
		}
	}

	IAchievement Find (string id)
	{
		return achievements.Find (a => a.Id == id);
	}
}
