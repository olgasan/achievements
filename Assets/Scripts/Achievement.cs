using System;

public class Achievement : IAchievement
{
	public class Milestone
	{
		public int Goal 
		{
			get;
			private set;
		}
		
		public int GameReward
		{
			get;
			private set;
		}
		
		public int GameCenterReward
		{
			get;
			private set;
		}
		
		public int GooglePlayReward
		{
			get;
			private set;
		}

		public Milestone (int goal, int gameReward, int gcReward, int gpReward)
		{
			Goal = goal;
			GameReward = gameReward;
			GameCenterReward = gcReward;
			GooglePlayReward = gpReward;
		}
	}

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

	public int NextGoal
	{ 
		get;
		private set;
	}
	
	public bool IsUnlocked
	{ 
		get { return Progress >= NextGoal; }
	}

	public Achievement (string id, string type, int progress, params Milestone[] milestones)
	{
		Id = id;
		Type = type;
		Progress = progress;
	}
}
