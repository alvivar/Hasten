
// 2015/09/30 09:48:35 PM


using UnityEngine;
using System.Collections;


public class Palette : MonoBehaviour
{
	private static Palette _instance;
	public static Palette g
	{
		get
		{
			if (_instance == null)
				_instance = FindObjectOfType<Palette>();

			return _instance;
		}
	}


	public Color grayLite;
	public Color grayStrong;

	public Color redAlert;
}
