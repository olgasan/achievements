using UnityEngine;
using System.Collections;
using UnityEditor;

public class CISettings : ScriptableObject
{
	public const string ASSET_NAME = "CISettings";

	[SerializeField]
	private string appName = "myAppName";

	[SerializeField]
	private BuildOptions buildOptions = BuildOptions.Development;

	private static CISettings instance;
	
	public static CISettings Instance
	{
		#if UNITY_EDITOR
		set { instance  = value; }
		#endif
		get
		{
			if (instance == null)
				instance = Resources.Load (ASSET_NAME) as CISettings;
			
			return instance;
		}
	}

	public static string AppName 
	{
		get { return Instance.appName; }
	}

	public static BuildOptions Options
	{
		get { return Instance.buildOptions; }
	}
}
