using NUnit.Framework;
using System;

namespace UnityTest
{
	internal class GamingNetworkTest
	{
		[Test]
		public void NotifyNetworkWhenAchievementIsRegistered ()
		{
			AchievementFaker faker = new AchievementFaker ();
			Achieve achieve = new Achieve ();
			GamingNetwork network = new GamingNetwork (achieve);
			IAchievement registered = faker.CreateFakeAchievement ("a123", "kill", 1, 100);

			achieve.Register (registered);
			Assert.IsTrue (network.Achievements.Contains (registered));
		}
	}
}