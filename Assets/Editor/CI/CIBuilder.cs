using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
using System.IO;
using System;

public class CIBuilder
{
	private static string[] SCENES = FindEnabledEditorScenes ();
	private static string TARGET_DIR = Environment.GetFolderPath (System.Environment.SpecialFolder.Desktop) + "/builds/" + CISettings.AppName;
	
	public static void DoBuild (BuildTarget target, string filepath)
	{
		GenericBuild (SCENES, filepath, target, CISettings.Options);
	}
	
	private static string[] FindEnabledEditorScenes ()
	{
		List<string> EditorScenes = new List<string> ();
		foreach (EditorBuildSettingsScene scene in EditorBuildSettings.scenes)
		{
			if (!scene.enabled)
				continue;
			EditorScenes.Add (scene.path);
		}
		return EditorScenes.ToArray ();
	}
	
	private static void GenericBuild (string[] scenes, string target_dir, BuildTarget build_target, BuildOptions build_options)
	{
		EditorUserBuildSettings.SwitchActiveBuildTarget (build_target);
		string res = BuildPipeline.BuildPlayer (scenes, target_dir, build_target, build_options);
		if (res.Length > 0)
		{
			throw new Exception ("BuildPlayer failure: " + res);
		}
	}
	
	public static string GetBuildFilepath (BuildTarget target, params string[] suffixes)
	{
		string path = TARGET_DIR + "/" + target.ToString ();
		string suffix = GetSuffixAsString (suffixes);
		
		if (!Directory.Exists (path))
			Directory.CreateDirectory (path);
		
		switch (target)
		{
		case BuildTarget.Android:
			return string.Format ("{0}/{1}{2}.{3}", path, CISettings.AppName, suffix, "apk");
			
		default:
			return string.Format ("{0}/{1}{2}", path, CISettings.AppName, suffix);
		}
	}

	private static string GetSuffixAsString (string[] suffixes)
	{
		if (suffixes != null && suffixes.Length > 0)
		{
			return string.Format ("_{0}", string.Join ("", suffixes)).ToLower ();
		}
		else
		{
			return string.Empty;
		}
	}
}
