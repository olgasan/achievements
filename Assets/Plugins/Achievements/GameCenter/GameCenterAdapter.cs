using UnityEngine;
using System.Collections.Generic;
using Brainz;

public class GameCenterAdapter : IGamingNetworkAdapter
{
	public List<IAchievement> Achievements 
	{ 
		get; 
		private set;
	}

	public GameCenterAdapter ()
	{
		Achievements = new List<IAchievement> ();
	}

	public void Init ()
	{
		Social.localUser.Authenticate (OnAuthenticate);
	}

	public void ShowUI ()
	{
		Social.ShowAchievementsUI ();
	}

	public void Unlocked (IAchievement achievement)
	{
		Debug.Log ("achievement unlocked " + achievement.Id);
	}

	public void Register (IAchievement achievement)
	{
		//..
	}

	private void OnAuthenticate (bool success)
	{
		if (success)
		{
			Debug.Log ("Authentication successful");
			string userInfo = string.Format ("Username: {0}\nUser ID: {1}", Social.localUser.userName, Social.localUser.id);
			Debug.Log (userInfo);
		}
		else
		{
			Debug.Log ("Authentication failed");
		}
	}
}
