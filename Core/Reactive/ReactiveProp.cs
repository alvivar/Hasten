
// Experimental reactive properties!

// @matnesis
// 2015/12/12 02:40 PM


using UnityEngine;
using System.Collections;
using System;


/// <summary>
/// Reactive properties core.
/// </summary>
public class ReactiveProp<T>
{
	private T _value = default(T);
	public T Value
	{
		set
		{
			if (_value != null && _value.Equals(value))
				return;

			_value = value;

			if (Suscribers != null)
				Suscribers(_value);
		}

		get { return _value; }
	}

	private Action<T> Suscribers;


	/// <summary>
	/// Suscribe an Action that will be called when .Value changes.
	/// </summary>
	public void Suscribe(Action<T> callback)
	{
		Suscribers += callback;
	}
}



// ^
// Specialized properties can be seeing on the Unity inspector.


[Serializable]
public class BoolReactiveProp : ReactiveProp<bool>
{
	[SerializeField]
	private bool boolValue;


	public BoolReactiveProp(bool initialValue)
	{
		Suscribe(x => boolValue = x);
		Value = initialValue;
	}


	/// <summary>
	/// Value = Value in the inspector.
	/// </summary>
	public void SyncWithInspector()
	{
		if (Value != boolValue)
			Value = boolValue;
	}
}


[Serializable]
public class StringReactiveProp : ReactiveProp<string>
{
	[SerializeField]
	private string stringValue;


	public StringReactiveProp(string initialValue)
	{
		Suscribe(x => stringValue = x);
		Value = initialValue;
	}


	/// <summary>
	/// Value = Value in the inspector.
	/// </summary>
	public void SyncWithInspector(bool force = false)
	{
		if (Value != stringValue)
			Value = stringValue;
	}
}


[Serializable]
public class IntReactiveProp : ReactiveProp<int>
{
	[SerializeField]
	private int intValue;


	public IntReactiveProp(int initialValue)
	{
		Suscribe(x => intValue = x);
		Value = initialValue;
	}


	/// <summary>
	/// Value = Value in the inspector.
	/// </summary>
	public void SyncWithInspector()
	{
		if (Value != intValue)
			Value = intValue;
	}
}


[Serializable]
public class FloatReactiveProp : ReactiveProp<float>
{
	[SerializeField]
	private float floatValue;


	public FloatReactiveProp(float initialValue)
	{
		Suscribe(x => floatValue = x);
		Value = initialValue;
	}


	/// <summary>
	/// Value = Value in the inspector.
	/// </summary>
	public void SyncWithInspector()
	{
		if (Value != floatValue)
			Value = floatValue;
	}
}


[Serializable]
public class Vector3ReactiveProp : ReactiveProp<Vector3>
{
	[SerializeField]
	private Vector3 vector3Value;


	public Vector3ReactiveProp(Vector3 initialValue)
	{
		Suscribe(x => vector3Value = x);
		Value = initialValue;
	}


	/// <summary>
	/// Value = Value in the inspector.
	/// </summary>
	public void SyncWithInspector()
	{
		if (Value != vector3Value)
			Value = vector3Value;
	}
}


[Serializable]
public class Vector2ReactiveProp : ReactiveProp<Vector2>
{
	[SerializeField]
	private Vector2 vector2Value;


	public Vector2ReactiveProp(Vector2 initialValue)
	{
		Suscribe(x => vector2Value = x);
		Value = initialValue;
	}


	/// <summary>
	/// Value = Value in the inspector.
	/// </summary>
	public void SyncWithInspector()
	{
		if (Value != vector2Value)
			Value = vector2Value;
	}
}
