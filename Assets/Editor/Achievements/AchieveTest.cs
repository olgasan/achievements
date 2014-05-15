using NUnit.Framework;
using NSubstitute;
using System;

namespace UnityTest
{
	internal class AchieveTest 
	{
		private Achieve achieve;
		private IAchievement unlockedAchievement;
		private IAchievement registeredAchievement;

		[SetUp]
		public void SetUp ()
		{
			unlockedAchievement = null;
			registeredAchievement = null;
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
		public void NotifyWhenAchievementIsUnlocked ()
		{
			IAchievement triggeredAchievement = null;
			achieve.AchievementUnlocked += OnAchievementUnlocked;

			var achievement = RegisterFakeAchievement ("a123", "grind");

			triggeredAchievement = TriggerUnlockedEventForAchievement (ref achievement);
			Assert.AreEqual (triggeredAchievement, unlockedAchievement);
		}

		[Test]
		[ExpectedException]
		public void WithoutAchievementsEventsCannotBeCalled ()
		{
			achieve.OnEvent ("kill");
		}

		[Test]
		public void NotifyWhenAchievementIsRegistered ()
		{
			achieve.AchievementRegistered += OnAchievementRegistered;
			IAchievement achievement = RegisterFakeAchievement ("a123", "grind");
			
			Assert.AreEqual (achievement, registeredAchievement);
		}

		private void OnAchievementUnlocked (IAchievement achievement)
		{
			unlockedAchievement = achievement;
		}

		private void OnAchievementRegistered (IAchievement achievement)
		{
			registeredAchievement = achievement;
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
