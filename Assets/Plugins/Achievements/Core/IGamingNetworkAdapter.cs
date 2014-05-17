using System.Collections.Generic;

namespace Brainz
{
	public interface IGamingNetworkAdapter
	{
		List<IAchievement> Achievements { get; }
		void Init ();
		void ShowUI ();
		void ResetAllAchievements ();
		void Unlocked (IAchievement achievement);
		void Register (IAchievement achievement);
		void Progressed (IAchievement achievement);
	}
}
