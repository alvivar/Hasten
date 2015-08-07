
// Andrés Villalobos < andresalvivar@gmail.com < twitter.com/matnesis
// 2015/06/25 12:41:37 AM

// Data is a quite simple component to sync data.


using UnityEngine;
using System.Collections;


public class Data : MonoBehaviour
{
	[Header("Config")]
	public DataMode mode = DataMode.Receiver;
	public float messageRate = 0.25f;

	[Header("Data")]
	public int hp;
	public int bullets;

	private float rateLock = 0;


	public enum DataMode
	{
		Receiver,
		Emitter
	}


	private void Plus(Data data)
	{
		hp += data.hp;
		bullets += data.bullets;
	}


	void OnCollisionEnter2D(Collision2D other)
	{
		// Only Receivers detect others
		if (mode != DataMode.Receiver)
			return;


		// Respect the message rate lock
		if (Time.time - rateLock <= messageRate)
			return;


		// If we found an Emitter, plus itself with his values
		Data otherData = other.transform.GetComponent<Data>();

		if (otherData && otherData.mode == DataMode.Emitter)
		{
			Plus(otherData);
			rateLock = Time.time;
		}
	}
}
