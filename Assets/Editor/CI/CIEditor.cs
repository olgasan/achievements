using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
using System.IO;
using System;

public class CIEditor
{
	[MenuItem ("Tools/CI/Perform iOS")]
	private static void PerformIOS ()
	{
		string filepath = CIBuilder.GetBuildFilepath (BuildTarget.iPhone);
		CIBuilder.DoBuild (BuildTarget.iPhone, filepath);
		Debug.Log ("CI -> Perform iOS");
	}
	
	[MenuItem ("Tools/CI/Perform Android")]
	private static void PerformAndroid ()
	{
		string filepath = CIBuilder.GetBuildFilepath (BuildTarget.Android);
		CIBuilder.DoBuild (BuildTarget.Android, filepath);
		Debug.Log ("CI -> Perform Android");
	}
}
