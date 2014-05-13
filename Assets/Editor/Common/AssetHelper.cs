using UnityEngine;
using System.Collections;
using System.IO;
using UnityEditor;
using System.Collections.Generic;

public class AssetHelper
{
	private const string ASSET_PATH = "Config/Resources";
	private const string ASSET_EXTENSION = ".asset";

	public void CreateAsset (string assetName, ScriptableObject instance)
	{
		string path = Application.dataPath + "/" + ASSET_PATH;
		
		if (!Directory.Exists(path))
			Directory.CreateDirectory(path);
		
		string assetPath = "Assets/" + ASSET_PATH + "/" + assetName + ASSET_EXTENSION;
		AssetDatabase.CreateAsset(instance, assetPath);
	}
	
	public List<string> GetFolderFilePaths ()
	{
		List<string> filePaths = new List<string> ();

		if (Selection.activeObject != null)
		{
			Object objSelected = Selection.activeObject;
			
			string selectedPath = AssetDatabase.GetAssetPath (objSelected);
			string dataPath = Application.dataPath;
			string path = dataPath.Replace ("Assets", selectedPath);

			DirSearch (path, filePaths);

			return filePaths;
		}

		Debug.Log ("Please select a prefab folder into the Project Tab");
		return filePaths;
	}
	
	private void DirSearch (string sDir, List<string> filePaths)
	{
		try
		{
			foreach (string d in Directory.GetDirectories(sDir))
			{
				foreach (string f in Directory.GetFiles(d))
				{
					if (!filePaths.Contains (f))
					{
						filePaths.Add (f);
					}
				}
				
				DirSearch(d, filePaths);
			}
		}
		catch (System.Exception excpt)
		{
			Debug.LogWarning (excpt.Message);
		}
	}

	public void ApplyChangesToPrefab (GameObject selectedGameObject)
	{
		PrefabType prefabType = PrefabUtility.GetPrefabType (selectedGameObject);
		GameObject parentObj = selectedGameObject.transform.root.gameObject;
		Object prefabParent = PrefabUtility.GetPrefabParent (selectedGameObject);
		
		EditorUtility.SetDirty (selectedGameObject);
		
		if (prefabType == PrefabType.PrefabInstance)
		{
			PrefabUtility.ReplacePrefab (parentObj, prefabParent, ReplacePrefabOptions.ConnectToPrefab);
		}
	}
}
