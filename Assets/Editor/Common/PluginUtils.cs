using UnityEngine;
using UnityEditor;
using System;

public class PluginUtils 
{
	private static string TARGET_DIR = Environment.GetFolderPath (System.Environment.SpecialFolder.Desktop);

	public void Pack (string[] assetPaths, string packName)
	{
		string packagePath = TARGET_DIR + "/" + packName;
		
		ExportPackageOptions options = ExportPackageOptions.Recurse;
		AssetDatabase.ExportPackage (assetPaths, packagePath, options);
		
		Debug.Log (string.Format ("Exported package [{0}] at [{1}]", packName, TARGET_DIR));
	}

	public void Uninstall (string[] filePaths)
	{
		foreach (string path in filePaths)
		{
			FileUtil.DeleteFileOrDirectory(path);
			FileUtil.DeleteFileOrDirectory(path + ".meta");
			
			Debug.Log ("Removed " + path);
		}
	}
}
