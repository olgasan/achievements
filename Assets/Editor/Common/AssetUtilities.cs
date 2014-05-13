using UnityEngine;
using System.Collections;
using UnityEditor;
using System.IO;

public class AssetUtilities
{
	private const string ASSET_PATH = "Config/Resources";
	private const string ASSET_EXTENSION = ".asset";
	
	public static T GetAsset<T> (string assetName) where T : ScriptableObject
	{
		T asset = Resources.Load (assetName) as T;

		if (asset == null)
			asset = CreateAsset <T> (assetName);

		EditorUtility.FocusProjectWindow ();
		return asset;
	}

	private static T CreateAsset<T> (string assetName) where T : ScriptableObject
	{
		T asset = ScriptableObject.CreateInstance <T> ();
		string path = Application.dataPath + "/" + ASSET_PATH;
		
		if (!Directory.Exists(path))
			Directory.CreateDirectory(path);
		
		string assetPath = "Assets/" + ASSET_PATH + "/" + assetName + ASSET_EXTENSION;
		
		AssetDatabase.CreateAsset(asset, assetPath);
		AssetDatabase.SaveAssets ();

		return asset;
	}

	public static T GetAssetInstance<T> (string assetName) where T : ScriptableObject
	{
		T asset = Resources.Load(assetName) as T;
		if (asset == null)
		{
			asset = ScriptableObject.CreateInstance<T>();
			AssetHelper assetHelper = new AssetHelper ();
			assetHelper.CreateAsset (assetName, asset);
		}
		
		return asset;
	}
}
