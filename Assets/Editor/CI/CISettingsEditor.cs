using UnityEngine;
using UnityEditor;
using System.Collections;
using System.IO;

public class CISettingsEditor
{

	private static CISettings ObjInstance
	{
		get
		{
			if (CISettings.Instance == null)
			{
				AssetHelper assetHelper = new AssetHelper ();

				CISettings.Instance = ScriptableObject.CreateInstance<CISettings>();
				assetHelper.CreateAsset (CISettings.ASSET_NAME, CISettings.Instance);
			}
			
			return CISettings.Instance;
		}
	}

	[MenuItem("Config/CI Settings")]
	[MenuItem("Tools/CI/Settings", false, 10)]
	public static void Edit()
	{
		Selection.activeObject = ObjInstance;
	}
}