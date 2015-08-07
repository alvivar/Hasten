
// 2015/08/06 11:20:24 PM


using UnityEngine;
using System.Collections;


[RequireComponent(typeof(Motion))]
public class WalkJump : MonoBehaviour
{
	private Motion motion;


	void Start()
	{
		motion = GetComponent<Motion>();
	}


	void Update()
	{

	}
}
