using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour 
{
	private OnScreenDebugMenu menu;
	private EventListenerForAchievements listener;
	private Achieve achieve;

	private void Awake ()
	{
		menu = new OnScreenDebugMenu ();
		
		listener = Locator.Instance.GetService <EventListenerForAchievements> ();
		achieve = Locator.Instance.GetService <Achieve> ();

		GameCenterAdapter gc = new GameCenterAdapter ();
		GamingNetwork gamingNetwork =new GamingNetwork (achieve, gc);
		gamingNetwork.Init ();

		Invoke ("OnGameLoaded", 3F);
	}

	private void OnGameLoaded ()
	{
		IAchievementReward a1Reward = new AchievementReward (AchievementRewardType.Game, 12);
		IAchievementReward a2Reward = new AchievementReward (AchievementRewardType.Game, 10);

		IAchievement a1 = new Achievement ("a123", "kill", 2, 4, a1Reward, a1Reward);
		IAchievement a2 = new Achievement ("b456", "grind", 0, 1, a2Reward, a2Reward);

		achieve.Register (a1);
		achieve.Register (a2);

		Debug.Log ("Achievements registered");
	}

	private void OnGUI ()
	{
		menu.Reset ();

		if (menu.DrawButton ("I'm kill"))
		{
			listener.OnKill ();
		}

		if (menu.DrawButton ("I'm grind"))
		{
			listener.OnGrind ();
		}
	}
}
