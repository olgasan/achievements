using NUnit.Framework;
using NSubstitute;
using System;

namespace UnityTest
{
	internal class AchieveTest 
	{
		private Achieve achieve;
		private IAchievement unlockedAchievement;

		[SetUp]
		public void SetUp ()
		{
			unlockedAchievement = null;
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

		[Test]
		public void TriggerEventWhenAchievementIsUnlocked ()
		{
			IAchievement triggeredAchievement = null;
			achieve.AchievementUnlocked += OnAchievementUnlocked;

			var achievementA = RegisterFakeAchievement ("a123", "grind");
			var achievementB = RegisterFakeAchievement ("b456", "kill");

			triggeredAchievement = TriggerUnlockedEventForAchievement (ref achievementA);
			Assert.AreEqual (triggeredAchievement, unlockedAchievement);

			triggeredAchievement = TriggerUnlockedEventForAchievement (ref achievementB);
			Assert.AreEqual (triggeredAchievement, achievementB);
		}

		[Test]
		[ExpectedException]
		public void WithoutAchievementsEventsCannotBeCalled ()
		{
			achieve.OnEvent ("kill");
		}

		private void OnAchievementUnlocked (IAchievement achievement)
		{
			unlockedAchievement = achievement;
		}

		private IAchievement TriggerUnlockedEventForAchievement (ref IAchievement achievement)
		{
			IAchievement triggered = null;

			achievement.Unlocked += a => triggered = a;
			achievement.Unlocked += Raise.Event<Action<IAchievement>>(achievement);

			return triggered;
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
			achievement.Goal.Returns (goal);
			return achievement;
		}
	}
}
