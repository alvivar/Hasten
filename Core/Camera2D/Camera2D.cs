
// Custom 2D camera with some tricks.

// Andrés Villalobos ~ andresalvivar@gmail.com ~ twitter.com/matnesis
// 2015/08/11 09:42 PM


using System.Collections.Generic;
using UnityEngine;
using matnesis.TeaTime;


public class Camera2D : MonoBehaviour
{
    [Header("Focus")]
    public Transform focus; // Main point of focus
    public Vector3 focusOffset; // Variation to the focus position
    public List<Transform> focusGroup; // All transforms here share the camera focus

    [Header("Config")]
    public float speed = 3; // Speed
    public float layer = -10; // Camera Z position
    public float childrenZLayer = 1; // Local z position for children


    /// <summary>
    /// Returns a Vector2 where 'x' represents the width and 'y' represents the
    /// heigh of the screen scale for the camera.
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
        Transform[] children = GetComponentsInChildren<Transform>();
        for (int i = 0; i < children.Length; i++)
        {
            if (children[i] == transform) continue;
            children[i].localPosition = new Vector3(children[i].localPosition.x, children[i].localPosition.y, childrenZLayer);
        }
    }


    void Update()
    {
        Vector3 pos = Vector3.zero;


        // Main focus
        if (focus)
            pos = focus.position + focusOffset;


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
