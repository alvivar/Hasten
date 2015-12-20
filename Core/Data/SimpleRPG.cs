
using UnityEngine;
using System.Collections;
using matnesis.TeaTime;


[Reactive]
public class SimpleRPG : MonoBehaviour
{
	public IntReactiveProp hp = new IntReactiveProp(3);


	void Start()
	{
		// hp.Value = 9;
	}
}
