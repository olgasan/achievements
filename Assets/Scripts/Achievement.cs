using System;

public class Achievement : IAchievement
{
	private Action<IAchievement> unlockedDelegate;
	private int progress;

	public string Id 
	{ 
		get;
		private set;
	}

	public string Type 
	{ 
		get;
		private set;
	}

	public int Progress
	{ 
		get { return progress; }
		set
		{
			bool wasUnlocked = IsUnlocked;

			progress = value;

			if (!wasUnlocked && IsUnlocked)
			{
				OnUnlocked ();
			}
		}
	}

	public int Goal
	{ 
		get;
		private set;
	}
	
	public bool IsUnlocked
	{ 
		get { return Progress >= Goal; }
	}

	public Achievement (string id, string type, int initial, int goal)
	{
		Id = id;
		Type = type;
		Progress = initial;
		Goal = goal;
	}

	public void SetUnlockedDelegate (Action<IAchievement> del) 
	{
		unlockedDelegate = del;
	}

	private void OnUnlocked ()
	{
		if (unlockedDelegate != null)
		{
			unlockedDelegate (this);
		}
	}
}
