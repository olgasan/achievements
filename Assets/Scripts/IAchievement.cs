public interface IAchievement  
{
	string Id { get; }
	string Type { get; }
	int Progress { get; set; }
	int NextGoal { get; }

	bool IsUnlocked { get; }
}
