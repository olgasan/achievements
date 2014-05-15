public class AchievementReward : IAchievementReward
{
	public AchievementRewardType Type 
	{ 
		get; 
		private set;
	}

	public int Amount 
	{ 
		get; 
		private set;
	}

	public AchievementReward (AchievementRewardType type, int amount)
	{
		Type = type;
		Amount = amount;
	}
}
