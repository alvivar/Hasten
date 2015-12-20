
// ^
// GameObject that helps with the first syncronization of ReactiveProp and his
// Inspector value. Runs only once.

// @matnesis
// 2015/12/19 03:15 PM


using System;
using System.Collections;
using UnityEngine;


public class ReactivePropLoader : MonoBehaviour
{
	private Action firstReactiveLoad;
	private static ReactivePropLoader instance;
	public static ReactivePropLoader Instance
	{
		get
		{
			if (instance == null)
				instance = FindObjectOfType<ReactivePropLoader>();

			if (instance == null)
			{
				GameObject go = new GameObject("[ReactivePropLoader]");
				instance = go.AddComponent<ReactivePropLoader>();
			}

			return instance;
		}
	}


	void Start()
	{
		StartCoroutine(LoadAllProps());
	}


	public void LoadIntProp(IntReactiveProp prop)
	{
		// firstReactiveLoad += () => prop.SyncWithInspector();
	}


	IEnumerator LoadAllProps()
	{
		yield return new WaitForSeconds(1);

		if (firstReactiveLoad != null)
			firstReactiveLoad();
	}
}
