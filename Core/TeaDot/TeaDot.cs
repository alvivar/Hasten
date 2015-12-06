
// Animations + Effects using TeaTime + DOTween :D

// @matnesis
// 2015/11/30 09:52 PM


using UnityEngine;
using System.Collections;
using matnesis.TeaTime;
using DG.Tweening;


public class TeaDot : MonoBehaviour
{
	[Header("Heart Pump")]
	public bool heartPump = false;
	public bool hpRandomRotation = false;
	public float hpGrowScale = 1.5f;
	public float hpAttack = 0.30f;
	public float hpDecay = 0.20f;
	public float hpRepeat = 2;

	[Header("Float")]
	public bool floating = false;
	public Vector3 fAddRemove = new Vector3(0, 2, 0);
	public float fDuration = 3;


	public TeaTime HeartPump;
	public TeaTime Floating;


	void Start()
	{
		// ^
		if (heartPump) HeartPump = this.tt().Add((ttHandler t) =>
		{
			if (hpRandomRotation)
				transform.eulerAngles = new Vector3(0, 0, Random.Range(0, 360f));

			Sequence pump = DOTween.Sequence();
			pump.Append(transform.DOScale(transform.localScale * hpGrowScale, hpAttack));
			pump.Append(transform.DOScale(Vector3.one, hpDecay));

			t.WaitFor(pump.WaitForCompletion());
		})
		.Add(hpRepeat)
		.Repeat();


		// ^
		if (floating) Floating = this.tt().Add((ttHandler t) =>
		{
			Vector3 currentPos = transform.position;

			Sequence ts = DOTween.Sequence();
			ts.Append(transform.DOMove(currentPos + fAddRemove, fDuration));
			ts.Append(transform.DOMove(currentPos, fDuration));

			t.WaitFor(ts.WaitForCompletion());
		})
		.Repeat();
	}


	public void StopAll()
	{
		HeartPump.Stop();
		Floating.Stop();
	}
}
