
// ^
// Observer that syncronizes ReactiveProps with the Inspector on classes with
// the attribute [Reactive], classic reflection. This only happens on the
// Unity Editor.

// @matnesis
// 2015/12/18 08:53 PM


using System;
using System.Reflection;
using UnityEditor;
using UnityEngine;


// ^
// [Reactive] is a custom Attribute that indicates that a class contains
// ReactiveProps and need to be observed.

[AttributeUsage(AttributeTargets.Class)]
class Reactive : Attribute { }


// ^
// ReactiveProps Observer runs only on the Editor, frame by frame,
// automatically, syncing ReactiveProps with the Inspector on classes with the
// Attribute [Reactive].

[InitializeOnLoad] // Autorun
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
			// With the [Reactive] attribute

			Type monoType = mono.GetType();

			if (Attribute.GetCustomAttribute(monoType, typeof(Reactive)) != null)
			{
				// On Reactive fields

				foreach (FieldInfo t in monoType.GetFields())
				{
					// Inspector sync

					if (t.FieldType.Equals(typeof(IntReactiveProp)))
						(t.GetValue(mono) as IntReactiveProp).SyncWithInspector();
				}
			}
		}
	}
}
