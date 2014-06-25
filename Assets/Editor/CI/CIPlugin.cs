using UnityEngine;
using UnityEditor;

public class CIPlugin
{
	[MenuItem ("Tools/CI/Package", false, 22)]
	public static void PackageCore ()
	{
		PluginUtils packager = new PluginUtils ();
		
		string[] assetPaths = new string[]
		{
			"Assets/Editor/CI",
		};
		
		packager.Pack (assetPaths, "/ci-core.unitypackage");
	}
}
