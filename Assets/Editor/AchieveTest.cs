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
			IAchievement achievementA = CreateFakeAchievement ("id_one");
			IAchievement achievementB = CreateFakeAchievement ("id_one");

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
		[Ignore]
		public void IncreaseAchievementCountAccordingToItsType ()
		{
//			var achievementA = Substitute.For <IAchievement> ();
//			achievementA.Id.Returns ("id_one");
			
		}

		private IAchievement CreateFakeAchievement (string id)
		{
			var achievement = Substitute.For <IAchievement> ();
			achievement.Id.Returns (id);
			return achievement;
		}
	}
}
