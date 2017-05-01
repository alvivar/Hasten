
// Observer that syncronizes ReactiveProps with the Inspector on classes with
// the attribute [ReactiveInEditMode], classic reflection. This only happens on
// the Unity Editor.

// @matnesis
// 2015/12/18 08:53 PM


#if UNITY_EDITOR
using System.Reflection;
using UnityEngine;
using UnityEditor;
using matnesis.Reactive;
#endif


// [ReactiveInEditMode] is a custom Attribute that indicates that a class
// contains ReactiveProps and need to be watched for changes while the Editor is
// running.

using System;
[AttributeUsage(AttributeTargets.Class)]
class ReactiveInEditMode : Attribute { }


// ReactiveProps Observer, runs only on the Editor, frame by frame,
// automatically, syncing ReactiveProps with the Inspector on classes with the
// Attribute [ReactiveInEditMode].

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
            // On classes with the [ReactiveInEditMode] attribute
            Type monoType = mono.GetType();
            if (Attribute.GetCustomAttribute(monoType, typeof(ReactiveInEditMode)) != null)
            {
                // On public fields
                foreach (FieldInfo field in monoType.GetFields(BindingFlags.Public | BindingFlags.Instance))
                {
                    // On Reactive Properties

                    // Bool
                    if (field.FieldType.Equals(typeof(ReactiveBool)))
                        (field.GetValue(mono) as ReactiveBool).CallSubscribers();

                    // String
                    else if (field.FieldType.Equals(typeof(ReactiveString)))
                        (field.GetValue(mono) as ReactiveString).CallSubscribers();

                    // Int
                    else if (field.FieldType.Equals(typeof(ReactiveInt)))
                        (field.GetValue(mono) as ReactiveInt).CallSubscribers();

                    // Float
                    else if (field.FieldType.Equals(typeof(ReactiveFloat)))
                        (field.GetValue(mono) as ReactiveFloat).CallSubscribers();

                    // Vector3
                    else if (field.FieldType.Equals(typeof(ReactiveVector3)))
                        (field.GetValue(mono) as ReactiveVector3).CallSubscribers();

                    // Vector2
                    else if (field.FieldType.Equals(typeof(ReactiveVector2)))
                        (field.GetValue(mono) as ReactiveVector2).CallSubscribers();
                }
            }
        }
    }


    // I'm not using this, but it's a useful piece of code :)
    // static void SetPropertyToField(MonoBehaviour mono, FieldInfo field, string propertyName, string fieldValue)
    // {
    //     // Current
    //     System.Object currentObject = field.GetValue(mono);
    //     Type currentType = currentObject.GetType();

    //     // Get
    //     PropertyInfo p = currentType.GetProperty(propertyName, BindingFlags.Public | BindingFlags.Instance);
    //     FieldInfo f = currentType.GetField(fieldValue, BindingFlags.NonPublic | BindingFlags.Instance);

    //     // Set
    //     p.SetValue(currentObject, f.GetValue(currentObject), null);
    // }
}
#endif
