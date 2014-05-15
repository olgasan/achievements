using System;

public class Achievement : IAchievement
{
	public event Action<IAchievement> Unlocked;

	private int progress;

	public string Id 
	{ 
		get;
		private set;
	}

	public string Type 
	{ 
		get;
		private set;
	}

	public int Progress
	{ 
		get { return progress; }
		set
		{
			if (!IsUnlocked)
			{
				bool wasUnlocked = IsUnlocked;
				progress = value;
				
				if (!wasUnlocked && IsUnlocked && Unlocked != null)
				{
					Unlocked (this);
				}
			}
			else
			{
				throw new InvalidOperationException ("Cannot increase an already unlocked achievement");
			}
		}
	}

	public int Goal
	{ 
		get;
		private set;
	}
	
	public bool IsUnlocked
	{ 
		get { return Progress == Goal; }
	}

	public IAchievementReward GameReward
	{
		get;
		private set;
	}

	public IAchievementReward GamingNetworkReward
	{
		get;
		private set;
	}

	public Achievement (string id, string type, int initial, int goal, IAchievementReward gameReward, IAchievementReward gamingNetworkReward)
	{
		Id = id;
		Type = type;
		progress = initial;
		Goal = goal;
		GameReward = gameReward;
		GamingNetworkReward = gamingNetworkReward;
	}
}
