using UnityEngine;
using System.Collections;
using NSubstitute;

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
}
