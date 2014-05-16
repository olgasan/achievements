using NUnit.Framework;
using System;
using NSubstitute;

namespace UnityTest
{
	internal class GamingNetworkTest
	{
		private AchievementFaker faker = new AchievementFaker ();

		[Test]
		public void NotifyNetworkWhenAchievementIsRegistered ()
		{
			Achieve achieve = new Achieve ();
			IGamingNetworkAdapter adapter = faker.CreateFakeGamingNetworkAdapter ();
			GamingNetwork network = new GamingNetwork (achieve, adapter);

			IAchievement registered = faker.CreateFakeAchievement ("a123", "kill", 1, 100);
			achieve.Register (registered);

			Assert.IsTrue (network.Achievements.Contains (registered));
			adapter.Received ().Register (Arg.Any<IAchievement>());
		}

		[Test]
		[Ignore]
		public void NotifyNetworkWhenAchievementIsUnlocked ()
		{
			Achieve achieve = new Achieve ();
			IGamingNetworkAdapter adapter = faker.CreateFakeGamingNetworkAdapter ();
			new GamingNetwork (achieve, adapter);
			
			IAchievement registered = faker.CreateFakeAchievement ("a123", "kill", 0, 1);
			achieve.Register (registered);
			achieve.OnEvent ("kill");

			//Assert Unlocked was called
			adapter.Received ().Unlocked (Arg.Any<IAchievement>());
		}

		[Test]
		public void InitializeAdapter ()
		{
			Achieve achieve = new Achieve ();
			IGamingNetworkAdapter adapter = faker.CreateFakeGamingNetworkAdapter ();
			GamingNetwork network = new GamingNetwork (achieve, adapter);
			network.Init ();

			//Assert Init was called
			adapter.Received ().Init ();
		}
	}
}