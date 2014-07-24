using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SocialPlatforms;
using UnityEngine.SocialPlatforms.GameCenter;

public class GameCenterAdapter : Brainz.IGamingNetworkAdapter
{
	public List<Brainz.IAchievement> Achievements 
	{ 
		get; 
		private set;
	}

	public GameCenterAdapter ()
	{
		Achievements = new List<Brainz.IAchievement> ();
	}

	public void Init ()
	{
		Social.localUser.Authenticate (OnAuthenticate);
	}

	public void ShowUI ()
	{
		Social.ShowAchievementsUI ();
	}

	public void Unlocked (Brainz.IAchievement achievement)
	{
		Debug.Log ("achievement unlocked " + achievement.Id);
	}

	public void ResetAllAchievements ()
	{
		GameCenterPlatform.ResetAllAchievements( (resetResult) => {
			Debug.Log( (resetResult) ? "Reset done." : "Reset failed." );
		});
	}

	public void Progressed (Brainz.IAchievement achievement)
	{
		double percent = ((double)achievement.Progress * 100) / (double)achievement.Goal;

		IAchievement a = Social.CreateAchievement();
		a.id = achievement.Id;
		a.percentCompleted = percent;
		a.ReportProgress(OnRegistered);

		Debug.Log ("achievement " + achievement.Id + " progressed on " + percent  + " points");
	}

	public void Register (Brainz.IAchievement achievement)
	{
		IAchievement a = Social.CreateAchievement();
		a.id = achievement.Id;
		a.percentCompleted = ((double)achievement.Progress * 100) / (double)achievement.Goal;
		a.ReportProgress(OnRegistered);
	}

	private void OnRegistered (bool result)
	{
		if (result)
			Debug.Log ("Successfully reported progress");
		else
			Debug.Log ("Failed to report progress");
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
