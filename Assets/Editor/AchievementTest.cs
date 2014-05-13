using NUnit.Framework;

namespace UnityTest
{
	internal class AchievementTest
	{
		private Achievement achievement;

		[Test]
		public void UnlockedWhenMeetsGoalCondition ()
		{
			achievement = new Achievement ("a123", "kill", 4, 5);
			achievement.Progress++;

			Assert.IsTrue (achievement.IsUnlocked);
		}
	}
}
