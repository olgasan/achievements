using UnityEngine;
using System.Collections.Generic;

public class GameCenter : IGamingNetworkAdapter
{
	public List<IAchievement> Achievements 
	{ 
		get; 
		private set;
	}

	public GameCenter ()
	{
		Achievements = new List<IAchievement> ();
	}

	public void Init ()
	{
		Social.localUser.Authenticate (OnAuthenticate);
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
