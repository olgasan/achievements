using UnityEngine;
using System.Collections;
using Brainz;

public class GameManager : MonoBehaviour 
{
	private OnScreenDebugMenu menu;
	private EventListenerForAchievements listener;
	private Achieve achieve;
	private GamingNetwork gamingNetwork;

	private void Awake ()
	{
		menu = new OnScreenDebugMenu ();
		
		listener = Locator.Instance.GetService <EventListenerForAchievements> ();
		achieve = Locator.Instance.GetService <Achieve> ();

		GameCenterAdapter gc = new GameCenterAdapter ();
		gamingNetwork = new GamingNetwork (achieve, gc);
		gamingNetwork.Init ();

		Invoke ("OnGameLoaded", 3F);
	}

	private void OnGameLoaded ()
	{
		IAchievementReward a1Reward = new AchievementReward (AchievementRewardType.Game, 12);
		IAchievementReward a2Reward = new AchievementReward (AchievementRewardType.Game, 10);

		IAchievement a1 = new Achievement ("motd_breakAFew1", "kill", 2, 10, a1Reward, a1Reward);
		IAchievement a2 = new Achievement ("motd_breakAFew2", "grind", 0, 15, a2Reward, a2Reward);

		achieve.Register (a1);
		achieve.Register (a2);
	}

	private void OnGUI ()
	{
		menu.Reset ();

		if (menu.DrawButton ("A"))
		{
			listener.OnKill ();
		}

		if (menu.DrawButton ("B"))
		{
			listener.OnGrind ();
		}

		if (menu.DrawButton ("Show UI"))
		{
			gamingNetwork.ShowUI ();
		}

		if (menu.DrawButton ("Reset"))
		{
			gamingNetwork.ResetProgress ();
		}
	}
}
