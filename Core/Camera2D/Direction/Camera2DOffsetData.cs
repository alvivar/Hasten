
// This component contains offset information for the camera and an static
// reference to all like him.

// @matnesis
// 2016/10/09 06:14 PM


using UnityEngine;
using System.Collections.Generic;

[ExecuteInEditMode]
public class Camera2DOffsetData : MonoBehaviour
{
    public Vector3 offset;
    public static List<Camera2DOffsetData> all;
    public Transform icon = null;


    void Start()
    {
        if (all == null)
            all = new List<Camera2DOffsetData>();

        if (!all.Contains(this))
            all.Add(this);


        // We don't need the icon while playing
        if (icon && Application.isPlaying)
            GameObject.Destroy(icon.gameObject);
    }


    void OnDestroy()
    {
        if (all != null && all.Contains(this))
            all.Remove(this);
    }


#if UNITY_EDITOR
    void Update()
    {
        // @
        // Get / create a cube to be used as icon.
        if (!Application.isPlaying)
        {
            string name = "@icon";

            // Find
            if (icon == null)
                icon = transform.FindChild(name);

            // Or create
            if (icon == null)
            {
                icon = GameObject.CreatePrimitive(PrimitiveType.Cube).transform;
                icon.name = name;
                icon.parent = transform;
            }

            // Update
            icon.localPosition = Vector3.zero;
            icon.localScale = (Vector3.one + offset).normalized * 5;
            icon.forward = offset.normalized;
        }
    }
#endif
}
