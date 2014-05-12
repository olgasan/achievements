using NUnit.Framework;
using NSubstitute;

namespace UnityTest
{
	internal class AchievementTest 
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
			IAchievement achievementA = CreateFakeAchievement ("a123");
			IAchievement achievementB = CreateFakeAchievement ("a123");

			achieve.Register (achievementA);
			achieve.Register (achievementB);
		}

		[Test]
		[ExpectedException]
		public void CannotRegisterNullOrEmptyIdIdAchievement ()
		{
			IAchievement achievement = CreateFakeAchievement (string.Empty);
			achieve.Register (achievement);
		}

		[Test]
		public void IncreaseAchievementCountAccordingToItsType ()
		{
			var achievementA = CreateFakeAchievement ("a123", "grind");
			var achievementB = CreateFakeAchievement ("b456", "kill");

			achieve.Register (achievementA);
			achieve.Register (achievementB);

			achieve.OnEvent ("grind");
			achieve.OnEvent ("kill");
			achieve.OnEvent ("kill");

			Assert.AreEqual (1, achievementA.Progress);
			Assert.AreEqual (2, achievementB.Progress);
		}

		private IAchievement CreateFakeAchievement (string id)
		{
			var achievement = Substitute.For <IAchievement> ();
			achievement.Id.Returns (id);
			return achievement;
		}

		private IAchievement CreateFakeAchievement (string id, string type)
		{
			var achievement = CreateFakeAchievement (id);
			achievement.Type.Returns (type);
			return achievement;
		}
	}
}
