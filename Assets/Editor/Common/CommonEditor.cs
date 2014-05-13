using UnityEngine;
using System.Collections;
using UnityEditor;
using System.Collections.Generic;

public class CommonEditor
{
	[MenuItem ("Tools/Common/Instantiate folder prefabs", false, 11)]
	public static void GetAllPrefabs ()
	{
		AssetHelper assetHelper = new AssetHelper ();
		List<string> filePaths = assetHelper.GetFolderFilePaths ();
		
		string log = string.Empty;
		int instantiatorCount = 0;
		foreach (string str in filePaths)
		{
			if (str.Contains (".prefab") && !str.Contains (".meta"))
			{
				InstantiatePrefab (str);
				log += "  " + str + "\n";
				instantiatorCount++;
			}
		}
		
		if (!string.IsNullOrEmpty (log))
			Debug.Log (string.Format ("Instantiated {0} prefabs: \n{1}", instantiatorCount, log));
	}

	private static void InstantiatePrefab (string str)
	{
		string sAssetPath = str.Substring (Application.dataPath.Length-6);
		Object objAsset = AssetDatabase.LoadAssetAtPath (sAssetPath, typeof(Object));

		if (objAsset != null)
		{
			PrefabUtility.InstantiatePrefab (objAsset);
		}
		else
		{
			Debug.LogWarning (sAssetPath);
		}
	}
}
