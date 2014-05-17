using UnityEngine;
using System.Collections.Generic;
using Brainz;

public class GooglePlayGamesAdapter : IGamingNetworkAdapter
{
	public List<IAchievement> Achievements 
	{ 
		get; 
		private set;
	}

	public GooglePlayGamesAdapter ()
	{
		Achievements = new List<IAchievement> ();
	}

	private bool IsAuthenticated
	{
		get { return Social.Active.localUser.authenticated; }
	}

	public void Init ()
	{
		if (!IsAuthenticated)
			Social.localUser.Authenticate (OnAuthenticate);
	}
	
	public void ShowUI()
	{
		if (IsAuthenticated)
			Social.ShowAchievementsUI();
	}

	public void Unlocked (IAchievement achievement)
	{
		Debug.Log ("Reporting achievement " + achievement.Id);
		Social.ReportProgress(achievement.Id, 100.0f, HandleGooglePlayUnlockResponse);
	}

	public void Register (IAchievement achievement)
	{
	}

	private void OnAuthenticate (bool wasSuccessful)
	{
		if (wasSuccessful)
		{
			Debug.Log ("GooglePlayGames: Authentication successful");
			string userInfo = string.Format ("Username: {0}\nUser ID: {1}", Social.localUser.userName, Social.localUser.id);
			Debug.Log (userInfo);
		}
		else
		{
			Debug.Log ("GooglePlayGames: Authentication failed");
		}
	}

	private void HandleGooglePlayUnlockResponse(bool wasSuccessful)
	{
		if (wasSuccessful)
			Debug.Log ("achievement unlocked.");
		else
			Debug.Log ("achievement was not unlocked." );
	}
}
