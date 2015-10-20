
// LayerSorter v0.1
// by Andrés Villalobos ^ andresalvivar@gmail.com ^ twitter.com/matnesis

// The transform with this component can UP and DOWN the sorting order of all
// SpriteRenderer in his children with buttons.

// 2015/06/04 02:39 AM


using UnityEngine;


[ExecuteInEditMode]
public class LayerSorter : MonoBehaviour
{
#if UNITY_EDITOR

	public int orderAverage = 0;

	[HideInInspector]
	public SpriteRenderer[] sprites;


	void Update()
	{
		// Calculate order average for all children with sprites
		SpriteRenderer[] all = transform.GetComponentsInChildren<SpriteRenderer>();

		orderAverage = 0;
		int count = 0;
		foreach (SpriteRenderer sr in all)
		{
			count += 1;
			orderAverage += sr.sortingOrder;
		}
		orderAverage /= count;
	}


	// void OnEnable()
	// {
	// }


	// void OnDisable()
	// {
	// }


	public void AddToSortingOrder(int n)
	{
		// Sorting order += n
		SpriteRenderer[] all = transform.GetComponentsInChildren<SpriteRenderer>();
		foreach (SpriteRenderer sr in all)
		{
			sr.sortingOrder += n;
		}

		// Also
		Update();

		// And force refresh the scene view
		UnityEditorInternal.InternalEditorUtility.RepaintAllViews();
	}
#endif
}
