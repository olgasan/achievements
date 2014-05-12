using NUnit.Framework;

namespace UnityTest
{
	internal class AchievementTest
	{
		private Achievement achievement;
		private int unlockEventCount;

		[SetUp]
		public void SetUp ()
		{
			unlockEventCount = 0;
		}

		[Test]
		public void UnlockedWhenMeetsGoalCondition ()
		{
			achievement = new Achievement ("a123", "kill", 4, 5);
			achievement.SetUnlockedDelegate (OnAchievementUnlocked);
			achievement.Progress++;

			Assert.IsTrue (achievement.IsUnlocked);
			Assert.AreEqual (1, unlockEventCount);
		}

		private void OnAchievementUnlocked (IAchievement achievement)
		{
			unlockEventCount++;
		}
	}
}
