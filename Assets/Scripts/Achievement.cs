using System;

public class Achievement : IAchievement
{
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
		get;
		set;
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
}
