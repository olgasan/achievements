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
			var achievementA = Substitute.For <IAchievement> ();
			var achievementB = Substitute.For <IAchievement> ();

			achievementA.Id.Returns ("id_one");
			achievementB.Id.Returns ("id_one");

			achieve.Register (achievementA);
			achieve.Register (achievementB);
		}

		[Test]
		[ExpectedException]
		public void CannotRegisterNullOrEmptyIdIdAchievement ()
		{
			var achievement = Substitute.For <IAchievement> ();
			
			achievement.Id.Returns (string.Empty);
			achieve.Register (achievement);
		}

		[Test]
		[Ignore]
		public void IncreaseAchievementCountAccordingToItsType ()
		{
//			var achievementA = Substitute.For <IAchievement> ();
//			achievementA.Id.Returns ("id_one");
			
		}
	}
}
