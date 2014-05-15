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
		}
	}
}