using System.Collections.Generic;

public class Achieve 
{
	private List<IAchievement> achievements;

	public Achieve ()
	{
		achievements = new List<IAchievement> ();
	}

	public void Register (IAchievement achievement)
	{
		ValidateAchievement (achievement);
		achievements.Add (achievement);
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
