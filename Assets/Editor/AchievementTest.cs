using NUnit.Framework;
using NSubstitute;

namespace UnityTest
{
	internal class AchievementTest
	{
		private Achievement achievement;

		[Test]
		public void UnlockedWhenMeetsGoalCondition ()
		{
			Achievement.Milestone m = CreateFakeMilestone (1, 10, 11, 12);
			achievement = new Achievement ("a123", "kill", 0, m);
			achievement.Progress++;

			Assert.IsTrue (achievement.IsUnlocked);
		}

		[Test]
		public void GrantsRewardsAccordingToAchievedMilestone ()
		{
			Achievement.Milestone m1 = CreateFakeMilestone (1, 10, 11, 12);
			Achievement.Milestone m2 = CreateFakeMilestone (5, 15, 16, 17);
			
			achievement = new Achievement ("a123", "kill", 4, m1, m2);
		}

		private Achievement.Milestone CreateFakeMilestone (int goal, int gameReward, int gcReward, int gpReward)
		{
			return Substitute.For <Achievement.Milestone> (goal, gameReward, gcReward, gpReward);
		}
	}
}
