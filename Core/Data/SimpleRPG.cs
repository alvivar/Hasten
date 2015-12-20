
using UnityEngine;
using System.Collections;
using matnesis.TeaTime;


[Reactive]
public class SimpleRPG : MonoBehaviour
{
	public IntReactiveProp hp = new IntReactiveProp(3);
	public IntReactiveProp stamina = new IntReactiveProp(3);
	public IntReactiveProp coins = new IntReactiveProp(0);
}
