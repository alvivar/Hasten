
using UnityEngine;
using System.Collections;


public class MouseUtil : MonoBehaviour
{
	public static Vector3 GetMousePosition()
	{
		return Camera.main.ScreenToWorldPoint(Input.mousePosition);
	}
}
