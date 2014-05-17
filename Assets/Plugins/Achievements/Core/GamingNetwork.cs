using System.Collections.Generic;

namespace Brainz
{
	public class GamingNetwork
	{
		private Achieve achieve;
		private IGamingNetworkAdapter adapter;
		
		public List<IAchievement> Achievements 
		{
			get { return adapter.Achievements; }
		}
		
		public GamingNetwork (Achieve achieve, IGamingNetworkAdapter adapter)
		{
			this.achieve = achieve;
			this.adapter = adapter;
			
			SetUpListenters ();
		}
		
		public void Init ()
		{
			this.adapter.Init ();
		}
		
		public void ShowUI ()
		{
			adapter.ShowUI ();
		}

		public void ResetProgress ()
		{
			adapter.ResetAllAchievements ();
		}
		
		private void SetUpListenters ()
		{
			achieve.AchievementRegistered += OnAchievementRegistered;
			achieve.AchievementUnlocked += OnAchievementUnlocked;
			achieve.AchievementProgressIncreased += OnAchievementProgressIncreased;
		}
		
		private void OnAchievementRegistered (IAchievement achievement)
		{
			Achievements.Add (achievement);
			adapter.Register (achievement);
		}
		
		public void OnAchievementUnlocked (IAchievement achievement)
		{
			adapter.Unlocked (achievement);
		}

		public void OnAchievementProgressIncreased (IAchievement registered, int amount)
		{
			adapter.Progressed (registered);
		}
	}
}
