
using UnityEngine;
using System.Collections;


public class SimpleRPG : MonoBehaviour
{
	public IntReactiveProp hp = new IntReactiveProp(0);
	public IntReactiveProp stamina = new IntReactiveProp(0);
	public IntReactiveProp xp = new IntReactiveProp(0);


	void SyncAll()
	{
		hp.SyncWithInspector();
		stamina.SyncWithInspector();
		xp.SyncWithInspector();
	}


	void Start()
	{
		SyncAll();
	}


#if UNITY_EDITOR
	void Update()
	{
		SyncAll();
	}
#endif
}
