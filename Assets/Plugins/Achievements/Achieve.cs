using System.Collections.Generic;
using System;
using UnityEngine;

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
		if (achievements.Count == 0)
		{
			throw new System.OperationCanceledException ("Trigger an event has no effects if there are no achievements registered.");
		}
		else
		{
			foreach (IAchievement achievement in achievements)
			{
				if (achievement.Type == eventType)
				{
					Debug.Log (achievement.Progress + " of " + achievement.Goal);
					achievement.Progress ++;
				}
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
