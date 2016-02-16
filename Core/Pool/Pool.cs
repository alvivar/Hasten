
// Pool v0.1
// The simplest semi-automatic Unity Transform pool I could make :)

// New ~ Pool pool = new Pool(prefab).Cache(10);
// Get ~ Trasform newTransform = pool.Get();
// Recycle ~ pool.Recycle(someTransform);

// @matnesis ~ 2016/02/08 08:45 PM


using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;


[Serializable]
public class Pool
{
	[Header("Config")]
	public Transform _prefab; // Base for new elements
	public string _name;
	public Transform _parent; // Reference to the default pool parent
	public float _growFactor = 0.20f; // How much the pool grows if empty (size *= 0.20f)

	[Header("Pool data")]
	public List<Transform> _waiting; // Ready to be used
	public List<Transform> _used; // Currently being used



	/// <summary>
	/// A pool with a Transform as prefab.
	/// The pool will grow if empty his current size *= growFactor [0..1].
	/// </summary>
	public Pool(Transform prefab, float growFactor = 0.20f)
	{
		_prefab = prefab;
		_waiting = new List<Transform>();
		_used = new List<Transform>();

		_name =  "[Pool(" + prefab.name + ")]";
		_parent = GetDefaultPoolParent();
		_growFactor = Mathf.Clamp01(growFactor);
	}


	/// <summary>
	/// Returns the Transform that represents the Pool parent.
	/// Used to store new pool elements.
	/// </summary>
	private Transform GetDefaultPoolParent()
	{
		// Current
		if (_parent != null)
			return _parent;


		// Or find / create
		GameObject go = GameObject.Find(_name);
		if (go == null)
			_parent = new GameObject(_name).transform;

		return _parent;
	}


	/// <summary>
	/// Creates (if needed) new inactive instances ready to used.
	/// </summary>
	public Pool Cache(int quantity)
	{
		// We have enough?
		quantity -= _waiting.Count;


		// Create more (start inactive)
		while (quantity-- > 0)
		{
			Transform t = MonoBehaviour.Instantiate(_prefab, Vector3.zero, Quaternion.identity) as Transform;
			t.SetParent(GetDefaultPoolParent());
			t.gameObject.SetActive(false);
			_waiting.Add(t);
		}


		return this;
	}


	/// <summary>
	/// Adds the Transform into the pool, at the end, inactive, ready to be used.
	/// </summary>
	public Pool Recycle(Transform transform, bool setParentToDefault = false)
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
		if (setParentToDefault)
			transform.SetParent(GetDefaultPoolParent());


		return this;
	}


	/// <summary>
	/// Returns the next active Transform from the pool.
	/// </summary>
	public Transform Get()
	{
		// If empty, grow
		if (_waiting.Count < 1)
			Cache(Mathf.FloorToInt(_used.Count * _growFactor) + 2); // This 2 is trying to speed up small sizes, I guess


		// Choose the first
		Transform chosen = _waiting[0];

		// Retry if null
		if (chosen == null)
		{
			_waiting.RemoveAt(0);
			return this.Get();
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
