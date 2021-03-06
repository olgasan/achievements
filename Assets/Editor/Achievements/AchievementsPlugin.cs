﻿using UnityEngine;
using UnityEditor;
using System;
using System.IO;

public class AchievementsPlugin
{
	[MenuItem ("Tools/Achievements/Package", false, 22)]
	public static void PackageCore ()
	{
		PluginUtils packager = new PluginUtils ();

		string[] assetPaths = new string[]
		{
			"Assets/Editor/Achievements",
			"Assets/Plugins/Achievements",
		};
		
		packager.Pack (assetPaths, "/achievements-core.unitypackage");
	}
}