
// Pool v0.1
// The simplest semi-automatic Unity Transform pool I could make.


// Creating a new pool:
// Pool pool = new Pool(prefab).Cache(10);

// Getting a Transform:
// Trasform newTransform = pool.Pop(); // The pool grows 20% if empty

// Recicling an instance:
// pool.Push(someTransform); // Pushed transforms became inactive


// @matnesis ~ 2016/02/08 08:45 PM


using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;


[Serializable]
public class Pool
{
	public Transform _prefab;
	public List<Transform> _waiting;
	public List<Transform> _used;

	public string _name;
	public Transform _parent;

	private float _growRate = 0.20f;


	/// <summary>
	/// A pool with a Transform as prefab.
	/// </summary>
	public Pool(Transform prefab)
	{
		_prefab = prefab;
		_waiting = new List<Transform>();
		_used = new List<Transform>();

		_name =  "[Pool|Prefab:" + prefab.name + "]";
		_parent = GetPoolParent();
	}


	/// <summary>
	/// Returns a reference to an special Transform used as parent for pool instances.
	/// </summary>
	private Transform GetPoolParent()
	{
		// Current
		if (_parent != null)
			return _parent;


		// Or creates
		GameObject go = GameObject.Find(_name);
		if (go == null)
			_parent = new GameObject(_name).transform;

		return _parent;
	}


	/// <summary>
	/// Creates (if needed) new instances ready to Pop().
	/// </summary>
	public Pool Cache(int quantity)
	{
		// We have enough?
		quantity -= _waiting.Count;


		// Create more (start inactive)
		while (quantity-- > 0)
		{
			Transform t = MonoBehaviour.Instantiate(_prefab, Vector3.zero, Quaternion.identity) as Transform;
			t.SetParent(GetPoolParent());
			t.gameObject.SetActive(false);
			_waiting.Add(t);
		}


		return this;
	}


	/// <summary>
	/// Adds a Transform into the pool, at the end, inactive.
	/// </summary>
	public Pool Push(Transform transform, bool setParentToPoolDefault = false)
	{
		// Known transform
		if (_used.Contains(transform) || _waiting.Contains(transform))
		{
			_used.Remove(transform);
			_waiting.Remove(transform);
			_waiting.Add(transform);
		}
		// New
		else if (!_waiting.Contains(transform))
		{
			_waiting.Add(transform);
		}


		// To inactive
		transform.gameObject.SetActive(false);

		// Use the pool parent
		if (setParentToPoolDefault)
			transform.SetParent(GetPoolParent());


		return this;
	}


	/// <summary>
	/// Returns an active Transform from the pool.
	/// </summary>
	public Transform Pop()
	{
		// If empty, grow
		if (_waiting.Count < 1)
			Cache(Mathf.FloorToInt(_used.Count * _growRate) + 2);


		// Choose the first
		Transform chosen = _waiting[0];

		// Retry if null
		if (chosen == null)
		{
			_waiting.RemoveAt(0);
			return this.Pop();
		}

		// Swap the state
		_waiting.Remove(chosen);
		_used.Add(chosen);


		// Return a Transform ready to be used
		chosen.gameObject.SetActive(true);
		chosen.SetParent(null);
		return chosen;
	}
}
