using UnityEngine;
using UnityEditor;
using System;
using System.IO;

public class ServiceLocatorPlugin
{
	[MenuItem ("Tools/Service Locator/Package", false, 12)]
	public static void PackageCore ()
	{
		PluginUtils packager = new PluginUtils ();

		string[] assetPaths = new string[]
		{
			"Assets/Editor/ServiceLocator",
			"Assets/Plugins/ServiceLocator",
		};
		
		packager.Pack (assetPaths, "/service-locator-core.unitypackage");
	}
}