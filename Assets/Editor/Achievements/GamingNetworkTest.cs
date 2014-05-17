using NUnit.Framework;
using System;
using NSubstitute;
using Brainz;

namespace UnityTest
{
	internal class GamingNetworkTest
	{
		private AchievementFaker faker = new AchievementFaker ();
		private Achieve achieve;
		private IGamingNetworkAdapter adapter;
		private GamingNetwork network;
		
		[SetUp]
		public void SetUp ()
		{
			achieve = new Achieve ();
			adapter = faker.CreateFakeGamingNetworkAdapter ();
			network = new GamingNetwork (achieve, adapter);
		}
		
		[Test]
		public void RegisterAchievementToAdapter ()
		{
			IAchievement registered = faker.CreateFakeAchievement ("a123", "kill", 1, 100);
			achieve.Register (registered);
			
			Assert.IsTrue (network.Achievements.Contains (registered));

			//Assert Register was called
			adapter.Received ().Register (Arg.Any<IAchievement>());
		}
		
		[Test]
		public void ReportUnlockToAdapter ()
		{
			IAchievement registered = faker.CreateFakeAchievement ("a123", "kill", 0, 1);
			network.OnAchievementUnlocked (registered);
			
			//Assert Unlocked was called
			adapter.Received ().Unlocked (Arg.Any<IAchievement>());
		}
		
		[Test]
		public void InitializeAdapter ()
		{
			network.Init ();
			
			//Assert Init was called
			adapter.Received ().Init ();
		}

		[Test]
		public void ReportProgress ()
		{
			IAchievement registered = faker.CreateFakeAchievement ("a123", "kill", 0, 1);
			network.OnAchievementProgressIncreased (registered, 1);

			//Assert Register was called
			adapter.Received ().Progressed (Arg.Any<IAchievement>());
		}

		[Test]
		public void DisplayAdapterAchievements ()
		{
			network.ShowUI ();
			adapter.Received ().ShowUI ();
		}
		
		[Test]
		public void ResetProgress ()
		{
			network.ResetProgress ();
			adapter.Received ().ResetAllAchievements ();
		}
	}
}