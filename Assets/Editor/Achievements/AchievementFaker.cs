using UnityEngine;
using System.Collections;
using NSubstitute;
using System.Collections.Generic;
using Brainz;

internal class AchievementFaker
{
	public IAchievement CreateFakeAchievement (string id, string type, int currentProgress, int goal)
	{
		var achievement = Substitute.For <IAchievement> ();
		achievement.Id.Returns (id);
		achievement.Type.Returns (type);
		achievement.Progress.Returns (currentProgress);
		achievement.Goal.Returns (goal);
		return achievement;
	}

	public IGamingNetworkAdapter CreateFakeGamingNetworkAdapter ()
	{
		IGamingNetworkAdapter adapter = Substitute.For <IGamingNetworkAdapter> ();
		adapter.Achievements.Returns (new List<IAchievement> ());
		return adapter;
	}
}
