
// ^
// Observer that syncronizes ReactiveProps with the Inspector on classes with
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
// ReactiveProps Observer runs only on the Editor, frame by frame,
// automatically, syncing ReactiveProps with the Inspector on classes with the
// Attribute [Reactive].

#if UNITY_EDITOR
[InitializeOnLoad] // Autorun
class ReactivePropObserver
{
	static ReactivePropObserver()
	{
		EditorApplication.update += Update;
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
				foreach (FieldInfo t in monoType.GetFields(BindingFlags.Public | BindingFlags.Instance))
				{
					// On Reactive Properties

					// Bool
					if (t.FieldType.Equals(typeof(BoolReactiveProp)))
						(t.GetValue(mono) as BoolReactiveProp).SyncWithInspector();
						// SetPropertyToField(mono, t, "Value", "boolValue");

					// String
					else if (t.FieldType.Equals(typeof(StringReactiveProp)))
						(t.GetValue(mono) as StringReactiveProp).SyncWithInspector();
						// SetPropertyToField(mono, t, "Value", "stringValue");

					// Int
					else if (t.FieldType.Equals(typeof(IntReactiveProp)))
						(t.GetValue(mono) as IntReactiveProp).CallSuscribers();
						// SetPropertyToField(mono, t, "Value", "intValue");

					// Float
					else if (t.FieldType.Equals(typeof(FloatReactiveProp)))
						(t.GetValue(mono) as FloatReactiveProp).SyncWithInspector();
						// SetPropertyToField(mono, t, "Value", "floatValue");

					// Vector3
					else if (t.FieldType.Equals(typeof(Vector3ReactiveProp)))
						(t.GetValue(mono) as Vector3ReactiveProp).SyncWithInspector();
						// SetPropertyToField(mono, t, "Value", "vector3Value");

					// Vector2
					else if (t.FieldType.Equals(typeof(Vector2ReactiveProp)))
						(t.GetValue(mono) as Vector2ReactiveProp).SyncWithInspector();
						// SetPropertyToField(mono, t, "Value", "vector2Value");
				}
			}
		}
	}
}
#endif
