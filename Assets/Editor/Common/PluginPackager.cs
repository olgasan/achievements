using UnityEngine;
using UnityEditor;
using System;

public class PluginPackager 
{
	private static string TARGET_DIR = Environment.GetFolderPath (System.Environment.SpecialFolder.Desktop);

	public void Pack (string[] assetPaths, string packName)
	{
		string packagePath = TARGET_DIR + "/" + packName;
		
		ExportPackageOptions options = ExportPackageOptions.Recurse;
		AssetDatabase.ExportPackage (assetPaths, packagePath, options);
		
		Debug.Log (string.Format ("Exported package [{0}] at [{1}]", packName, TARGET_DIR));
	}
}
