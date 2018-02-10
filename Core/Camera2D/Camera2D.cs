
// Custom 2D camera with some tricks.

// Andrés Villalobos | twitter.com/matnesis
// 2015/08/11 09:42 PM


using System.Collections.Generic;
using UnityEngine;

public class Camera2D : MonoBehaviour
{
    [Header("Focus")]
    public Transform focus; // Main point of focus
    public Vector3 focusOffset; // Variation to the focus position
    public Vector3 focusOffsetOverride; // This overrides the previous
    public Vector3 focusOffsetFixed = new Vector3(0, 0, 0); // This offset is added always at the end (to help with custom perspectives)
    public List<Transform> focusGroup; // All transforms here share the camera focus

    [Header("Config")]
    public float speed = 3; // Speed
    public float layer = -10; // Camera Z position

    [Header("Children")]
    public Transform[] affectedChildren; // List of children to be affected
    public float childrenZLayer = 1; // Local z position for children


    /// <summary>
    /// Returns a Vector2 where 'x' represents the width and 'y' represents the
    /// heigh of the screen as scale for the camera.
    /// </summary>
    public static Vector2 GetWidthHeightScale(Camera camera)
    {
        float height = Camera.main.orthographicSize * 2.0f;
        float width = height * Screen.width / Screen.height;

        return new Vector2(width, height);
    }


    void Start()
    {
        // Fix children layer
        for (int i = 0; i < affectedChildren.Length; i++)
        {
            if (affectedChildren[i] == transform) continue;
            affectedChildren[i].localPosition = new Vector3(affectedChildren[i].localPosition.x, affectedChildren[i].localPosition.y, childrenZLayer);
        }
    }


    void Update()
    {
        Vector3 pos = Vector3.zero;


        // Main focus
        if (focus)
        {
            if (focusOffsetOverride != Vector3.zero) pos = focus.position + focusOffsetOverride;
            else pos = focus.position + focusOffset;

            // Obligatory offset
            pos += focusOffsetFixed;
        }


        // Be at the center of everything
        if (focusGroup.Count > 0)
        {
            for (int i = 0; i < focusGroup.Count; i++)
            {
                pos += focusGroup[i].position;
            }
            pos /= (focusGroup.Count + (focus != null ? 1 : 0));
        }


        // Focus
        if (focus || focusGroup.Count > 0)
        {
            pos.z = layer;
            transform.position = Vector3.Lerp(transform.position, pos, Time.deltaTime * speed);
        }
    }
}
