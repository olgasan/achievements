using UnityEngine;
using UnityEditor;

public class CommonPlugin
{
	[MenuItem ("Tools/Common/Package", false, 12)]
	public static void PackageCore ()
	{
		PluginUtils packager = new PluginUtils ();

		string[] assetPaths = new string[]
		{
			"Assets/Editor/Common",
			"Assets/Plugins/Common",
		};
		
		packager.Pack (assetPaths, "/common-core.unitypackage");
	}
}
