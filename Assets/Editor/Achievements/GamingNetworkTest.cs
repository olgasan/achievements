using NUnit.Framework;
using System;
using NSubstitute;

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
		public void NotifyNetworkWhenAchievementIsRegistered ()
		{
			IAchievement registered = faker.CreateFakeAchievement ("a123", "kill", 1, 100);
			achieve.Register (registered);
			
			Assert.IsTrue (network.Achievements.Contains (registered));
			adapter.Received ().Register (Arg.Any<IAchievement>());
		}
		
		[Test]
		[Ignore]
		public void NotifyNetworkWhenAchievementIsUnlocked ()
		{
			IAchievement registered = faker.CreateFakeAchievement ("a123", "kill", 0, 1);
			achieve.Register (registered);
			achieve.OnEvent ("kill");
			
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
	}
}