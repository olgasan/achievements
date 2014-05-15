using UnityEngine;
using System;

public class GameCenter
{
	public Action<bool> OnSucceedInit
	{
		set;
		private get;
	}

	public GameCenter ()
	{
	}

	public void Init ()
	{
		Social.localUser.Authenticate (success => {
			if (success)
			{
				Debug.Log ("Authentication successful");

				string userInfo = "Username: " + Social.localUser.userName + 
					"\nUser ID: " + Social.localUser.id + 
					"\nIsUnderage: " + Social.localUser.underage;

				Debug.Log (userInfo);
			}
			else
				Debug.Log ("Authentication failed");
		});
	}
}
