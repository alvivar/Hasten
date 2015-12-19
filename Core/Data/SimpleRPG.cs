
using UnityEngine;
using System.Collections;


[Reactive]
public class SimpleRPG : MonoBehaviour
{
	public IntReactiveProp hp = new IntReactiveProp(0);
	public IntReactiveProp stamina = new IntReactiveProp(0);
	public IntReactiveProp xp = new IntReactiveProp(0);
}
