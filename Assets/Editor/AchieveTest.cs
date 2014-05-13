using NUnit.Framework;
using NSubstitute;

namespace UnityTest
{
	internal class AchieveTest 
	{
		private Achieve achieve;

		[SetUp]
		public void SetUp ()
		{
			achieve = new Achieve ();
		}

		[Test]
		[ExpectedException]
		public void CannotRegisterNullAchievements ()
		{
			achieve.Register (null);
		}

		[Test]
		[ExpectedException]
		public void CannotRegisterDuplicatedAchievements ()
		{
			RegisterFakeAchievement ("a123", "kill");
			RegisterFakeAchievement ("a123", "grind");
		}

		[Test]
		[ExpectedException]
		public void CannotRegisterNullOrEmptyIdIdAchievement ()
		{
			RegisterFakeAchievement (string.Empty, "kill");
		}

		[Test]
		public void IncreaseAchievementCountAccordingToItsType ()
		{
			IAchievement achievementA = RegisterFakeAchievement ("a123", "grind");
			IAchievement achievementB = RegisterFakeAchievement ("b456", "kill");

			achieve.OnEvent ("grind");
			achieve.OnEvent ("kill");
			achieve.OnEvent ("kill");

			Assert.AreEqual (1, achievementA.Progress);
			Assert.AreEqual (2, achievementB.Progress);
		}
		
		private IAchievement RegisterFakeAchievement (string id, string type)
		{
			return RegisterFakeAchievement (id, type, 0, int.MaxValue);
		}

		private IAchievement RegisterFakeAchievement (string id, string type, int currentProgress, int goal)
		{
			var achievement = CreateFakeAchievement (id, type, currentProgress, goal);
			achieve.Register (achievement);
			
			return achievement;
		}

		private IAchievement CreateFakeAchievement (string id, string type, int currentProgress, int goal)
		{
			var achievement = Substitute.For <IAchievement> ();
			achievement.Id.Returns (id);
			achievement.Type.Returns (type);
			achievement.Progress.Returns (currentProgress);
			achievement.NextGoal.Returns (goal);
			return achievement;
		}
	}
}
