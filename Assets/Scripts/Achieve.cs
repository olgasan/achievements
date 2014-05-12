public class Achieve 
{
	public void Register (Achievement achievement)
	{
		ValidateAchievement (achievement);
	}

	private void ValidateAchievement (Achievement achievement)
	{
		if (achievement == null)
		{
			throw new System.ArgumentException ("Cannot register null achievements");
		}
	}
}
