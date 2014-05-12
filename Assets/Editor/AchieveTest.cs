using NUnit.Framework;

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
		public void CannotRegisterNullAchievement ()
		{
			achieve.Register (null);
		}
	}
}
