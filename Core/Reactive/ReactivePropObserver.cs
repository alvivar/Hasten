
// ^
// Observer that syncronize ReactiveProps with the Inspector on classes with
// the attribute [Reactive], classic reflection. This only happens on the
// Unity Editor.

// @matnesis
// 2015/12/18 08:53 PM


using System;
using System.Reflection;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif


// ^
// [Reactive] is a custom Attribute that indicates that a class contains
// ReactiveProps and need to be observed.

[AttributeUsage(AttributeTargets.Class)]
class Reactive : Attribute { }


// ^
// ReactiveProps Observer, runs only on the Editor, frame by frame,
// automatically, syncing ReactiveProps with the Inspector on classes with the
// Attribute [Reactive].

#if UNITY_EDITOR
[InitializeOnLoad] // Editor autorun
class ReactivePropObserver
{
	static ReactivePropObserver()
	{
		EditorApplication.update += Update;
	}


	static void Update()
	{
		// For all MonoBehaviours
		MonoBehaviour[] allMonoBehaviours = GameObject.FindObjectsOfType<MonoBehaviour>();
		foreach (MonoBehaviour mono in allMonoBehaviours)
		{
			// On classes with the [Reactive] attribute
			Type monoType = mono.GetType();
			if (Attribute.GetCustomAttribute(monoType, typeof(Reactive)) != null)
			{
				// On public fields
				foreach (FieldInfo field in monoType.GetFields(BindingFlags.Public | BindingFlags.Instance))
				{
					// On Reactive Properties

					// Bool
					if (field.FieldType.Equals(typeof(BoolReactiveProp)))
						(field.GetValue(mono) as BoolReactiveProp).CallSuscribers();

					// String
					else if (field.FieldType.Equals(typeof(StringReactiveProp)))
						(field.GetValue(mono) as StringReactiveProp).CallSuscribers();

					// Int
					else if (field.FieldType.Equals(typeof(IntReactiveProp)))
						(field.GetValue(mono) as IntReactiveProp).CallSuscribers();

					// Float
					else if (field.FieldType.Equals(typeof(FloatReactiveProp)))
						(field.GetValue(mono) as FloatReactiveProp).CallSuscribers();

					// Vector3
					else if (field.FieldType.Equals(typeof(Vector3ReactiveProp)))
						(field.GetValue(mono) as Vector3ReactiveProp).CallSuscribers();

					// Vector2
					else if (field.FieldType.Equals(typeof(Vector2ReactiveProp)))
						(field.GetValue(mono) as Vector2ReactiveProp).CallSuscribers();
				}
			}
		}
	}


	static void SetPropertyToField(MonoBehaviour mono, FieldInfo field, string propertyName, string fieldValue)
	{
		// Current
		System.Object currentObject = field.GetValue(mono);
		Type currentType = currentObject.GetType();

		// Get
		PropertyInfo p = currentType.GetProperty(propertyName, BindingFlags.Public | BindingFlags.Instance);
		FieldInfo f = currentType.GetField(fieldValue, BindingFlags.NonPublic | BindingFlags.Instance);

		// Set
		p.SetValue(currentObject, f.GetValue(currentObject), null);
	}
}
#endif
