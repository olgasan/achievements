using System.Collections.Generic;

public interface IGamingNetworkAdapter
{
	List<IAchievement> Achievements { get; }
	void Init ();
	void Unlocked (IAchievement achievement);
	void Register (IAchievement achievement);
}
