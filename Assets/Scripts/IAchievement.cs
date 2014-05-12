public interface IAchievement  
{
	string Id { get; }
	string Type { get; }
	int Progress { get; set; }
	int Goal { get; }

	bool IsUnlocked { get; }
}
