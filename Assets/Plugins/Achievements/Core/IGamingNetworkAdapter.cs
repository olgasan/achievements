using System.Collections.Generic;

public interface IGamingNetworkAdapter
{
	List<IAchievement> Achievements { get; }
	void Init ();
	void ShowUI ();
	void Unlocked (IAchievement achievement);
	void Register (IAchievement achievement);
}
