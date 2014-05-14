using UnityEngine;

public class InstantiatorHelper
{
	public T InstantiateFromResources<T> (string assetName, Transform parent) where T: MonoBehaviour
	{
		T prefab = Resources.Load<T> (assetName);
		T obj = GameObject.Instantiate (prefab) as T;
		obj.transform.parent = parent;

		return obj;
	}
}
