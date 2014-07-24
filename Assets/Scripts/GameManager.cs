using UnityEngine;
using System.Collections;
using Brainz;

public class GameManager : MonoBehaviour 
{
	private OnScreenDebugMenu menu;
	private Achieve achieve;
	private GamingNetwork gamingNetwork;

	private void Awake ()
	{
		menu = new OnScreenDebugMenu ();
		
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
		IAchievementReward a1Reward = new AchievementReward (AchievementRewardType.Game, 10);
		IAchievementReward a2Reward = new AchievementReward (AchievementRewardType.Game, 15);
		IAchievementReward a3Reward = new AchievementReward (AchievementRewardType.Game, 20);

#if UNITY_ANDROID
		IAchievement a1 = new Achievement ("CgkIrOKywqEDEAIQAA", "a1", 0, 1, a1Reward, a1Reward);
		IAchievement a2 = new Achievement ("CgkIrOKywqEDEAIQAQ", "a2", 0, 5, a2Reward, a2Reward);
		IAchievement a3 = new Achievement ("CgkIrOKywqEDEAIQAg", "a3", 0, 15, a3Reward, a3Reward);
#else
		IAchievement a1 = new Achievement ("motd_breakAFew1", "a1", 0, 1, a1Reward, a1Reward);
		IAchievement a2 = new Achievement ("motd_breakAFew2", "a2", 0, 5, a2Reward, a2Reward);
		IAchievement a3 = new Achievement ("motd_breakAFew3", "a3", 0, 15, a3Reward, a3Reward);
#endif

		achieve.Register (a1);
		achieve.Register (a2);
		achieve.Register (a3);
	}

	private void OnGUI ()
	{
		menu.Reset ();

		if (menu.DrawButton ("1"))
		{
			achieve.OnEvent ("a1");
		}

		if (menu.DrawButton ("2"))
		{
			achieve.OnEvent ("a2");
		}

		if (menu.DrawButton ("3"))
		{
			achieve.OnEvent ("a3");
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
