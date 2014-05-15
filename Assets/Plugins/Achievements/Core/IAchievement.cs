using System;

public interface IAchievement  
{
	event Action<IAchievement> Unlocked;
	string Id { get; }
	string Type { get; }
	int Progress { get; set; }
	int Goal { get; }

	IAchievementReward GameReward { get; }
	IAchievementReward GamingNetworkReward { get; }

	bool IsUnlocked { get; }
}
