
using UnityEngine;
using System.Collections;
using matnesis.TeaTime;


[Reactive]
public class SimpleRPG : MonoBehaviour
{
	public IntReactiveProp hp = new IntReactiveProp(0);


	void Start()
	{
		hp.SyncWithInspector();
	}
}
