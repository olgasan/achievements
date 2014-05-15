using System.Collections.Generic;
using System;

public class Achieve 
{
	public event Action<IAchievement> AchievementUnlocked;
	public event Action<IAchievement> AchievementRegistered;
	public event Action<IAchievement, int> AchievementProgressIncreased;

	private List<IAchievement> achievements;

	public Achieve ()
	{
		achievements = new List<IAchievement> ();
	}

	public void Register (IAchievement achievement)
	{
		if (ValidateAchievement (achievement))
		{
			achievements.Add (achievement);
			achievement.Unlocked += OnAchievementUnlocked;

			if (AchievementRegistered != null)
			{
				AchievementRegistered (achievement);
			}
		}
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
					IncreaseAchievementProgress (achievement, 1);
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

	private void IncreaseAchievementProgress (IAchievement achievement, int increaseAmount)
	{
		achievement.Progress += increaseAmount;

		if (AchievementProgressIncreased != null)
		{
			AchievementProgressIncreased (achievement, increaseAmount);
		}
	}

	private bool ValidateAchievement (IAchievement achievement)
	{
		bool isValid = true;

		if (achievement == null)
		{
			isValid = false;
			throw new System.ArgumentException ("Cannot register null achievements");
		}
		else if (string.IsNullOrEmpty (achievement.Id))
		{
			isValid = false;
			throw new System.ArgumentException ("Cannot register achievements with null or empty Id");
		}
		else if (Find (achievement.Id) != null)
		{
			isValid = false;
			throw new System.ArgumentException ("Cannot register achievements with the same Id");
		}

		return isValid;
	}

	IAchievement Find (string id)
	{
		return achievements.Find (a => a.Id == id);
	}
}
