
// @
// Reactive Properties!

// Soon.

// @matnesis
// 2015/12/12 02:40 PM


using UnityEngine;
using System;

/// <summary>
/// Generic Reactive Property.
/// </summary>
[Serializable]
public class ReactiveProp<T>
{
	private Action<T> suscribers;
	private T valueSent = default(T);

	[SerializeField]
	private T _value = default(T);
	public T Value
	{
		get { return _value; }

		set
		{
			if (_value != null && _value.Equals(value))
				return;

			_value = value;

			CallSuscribers();
		}
	}


	public ReactiveProp(T initialValue)
	{
		Value = initialValue;
	}


	public void Suscribe(Action<T> callback)
	{
		suscribers += callback;

		if (valueSent != null) callback(_value);
	}


	public void CallSuscribers()
	{
		if (valueSent != null && valueSent.Equals(_value))
			return;

		valueSent = _value;
		if (suscribers != null) suscribers(_value);
	}
}


// @
// Specialized properties that can be seeing on the Unity inspector.

[Serializable]
public class BoolReactiveProp : ReactiveProp<bool>
{
	public BoolReactiveProp(bool initialValue) : base(initialValue) { }
}


[Serializable]
public class StringReactiveProp : ReactiveProp<string>
{
	public StringReactiveProp(string initialValue) : base(initialValue) { }
}


[Serializable]
public class IntReactiveProp : ReactiveProp<int>
{
	public IntReactiveProp(int initialValue) : base(initialValue) { }
}


[Serializable]
public class FloatReactiveProp : ReactiveProp<float>
{
	public FloatReactiveProp(float initialValue) : base(initialValue) { }
}


[Serializable]
public class Vector3ReactiveProp : ReactiveProp<Vector3>
{
	public Vector3ReactiveProp(Vector3 initialValue) : base(initialValue) { }
}


[Serializable]
public class Vector2ReactiveProp : ReactiveProp<Vector2>
{
	public Vector2ReactiveProp(Vector2 initialValue) : base(initialValue) { }
}
