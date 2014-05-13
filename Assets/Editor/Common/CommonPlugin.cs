using UnityEngine;
using UnityEditor;

public class CommonPlugin
{
	[MenuItem ("Tools/Common/Package", false, 12)]
	public static void PackageCore ()
	{
		PluginPackager packager = new PluginPackager ();

		string[] assetPaths = new string[]
		{
			"Assets/Editor/Common",
		};
		
		packager.Pack (assetPaths, "/common-core.unitypackage");
	}
}
