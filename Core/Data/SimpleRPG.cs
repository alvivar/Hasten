
// Reactive data for simple RPG behaviours.

// @matnesis
// 2016/06/20 07:32 PM


using UnityEngine;

[Reactive]
public class SimpleRPG : MonoBehaviour
{
	[Header("Stats")]
	public IntReactiveProp hp = new IntReactiveProp(3);
	public IntReactiveProp stamina = new IntReactiveProp(5);
	public IntReactiveProp coins = new IntReactiveProp(0);

	[Header("Combat")]
	public IntReactiveProp damage = new IntReactiveProp(1);
	public IntReactiveProp knockback = new IntReactiveProp(1);
}
