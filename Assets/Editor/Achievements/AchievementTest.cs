﻿using NUnit.Framework;
using NSubstitute;
using Brainz;

namespace UnityTest
{
	internal class AchievementTest
	{
		private Achievement achievement;
		private IAchievementReward gameReward;
		private IAchievementReward gamingNetworkReward;
		private IAchievement unlockedEventAchivement;

		[SetUp]
		public void SetUp ()
		{
			gameReward = CreateReward (AchievementRewardType.Game, 100);
			gamingNetworkReward = CreateReward (AchievementRewardType.GamingNetwork, 4);
		}

		[Test]
		public void UnlockedWhenReachGoal ()
		{

			achievement = new Achievement ("a123", "kill", 4, 5, gameReward, gamingNetworkReward);
			achievement.Progress++;

			Assert.IsTrue (achievement.IsUnlocked);
		}

		[Test]
		public void GrantRewards ()
		{
			achievement = new Achievement ("a123", "kill", 4, 5, gameReward, gamingNetworkReward);
			achievement.Unlocked += OnUnlocked;
			achievement.Progress++;

			Assert.AreEqual (gameReward.Amount, unlockedEventAchivement.GameReward.Amount);
			Assert.AreEqual (gamingNetworkReward.Amount, unlockedEventAchivement.GamingNetworkReward.Amount);
		}

		[Test]
		[ExpectedException]
		public void DoNoIncreaseWhenIsUnlocked ()
		{
			achievement = new Achievement ("a123", "kill", 5, 5, gameReward, gamingNetworkReward);
			Assert.IsTrue (achievement.IsUnlocked);

			achievement.Progress++;
			Assert.AreEqual (5, achievement.Progress);
		}

		private void OnUnlocked (IAchievement achievement)
		{
			unlockedEventAchivement = achievement;
		}

		private IAchievementReward CreateReward (AchievementRewardType type, int amount)
		{
			var reward = Substitute.For <IAchievementReward> ();
			reward.Type.Returns (type);
			reward.Amount.Returns (amount);

			return reward;
		}
	}
}
