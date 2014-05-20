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

		IGamingNetworkAdapter adapter = GetGamingNetworkAdapter();
		gamingNetwork = new GamingNetwork (achieve, adapter);
		gamingNetwork.Init ();

		Invoke ("OnGameLoaded", 3F);
	}

	private IGamingNetworkAdapter GetGamingNetworkAdapter()
	{
#if UNITY_ANDROID
		if (Application.platform == RuntimePlatform.Android)
			return new GooglePlayGamesAdapter();
		else
			return new GameCenterAdapter ();
#else
		return new GameCenterAdapter ();
#endif
	}

	private void OnGameLoaded ()
	{
		IAchievementReward a1Reward = new AchievementReward (AchievementRewardType.Game, 12);
		IAchievementReward a2Reward = new AchievementReward (AchievementRewardType.Game, 10);

#if UNITY_ANDROID
		IAchievement a1 = new Achievement ("CgkIrOKywqEDEAIQAw", "kill", 2, 4, a1Reward, a1Reward);
		IAchievement a2 = new Achievement ("CgkIrOKywqEDEAIQAA", "grind", 0, 1, a2Reward, a2Reward);
#else
		IAchievement a1 = new Achievement ("motd_breakAFew1", "kill", 2, 10, a1Reward, a1Reward);
		IAchievement a2 = new Achievement ("motd_breakAFew2", "grind", 0, 15, a2Reward, a2Reward);
#endif

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
