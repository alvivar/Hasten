﻿
// 2015/08/11 09:42:14 PM


using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using matnesis.TeaTime;


public class Camera2D : MonoBehaviour
{
    [Header("Focus")]
    public Transform focus;
    public Vector3 focusOffset;
    public List<Transform> focusGroup;

    [Header("Config")]
    public float speed = 3;
    public float layer = -10;
    public float childrenZLayer = 1;

    [Header("White Screen")]
    public Renderer whiteScreen;

    private float slowdown = 1;


    private static Camera2D instance;
    public static Camera2D g
    {
        get
        {
            if (instance == null)
                instance = GameObject.FindObjectOfType<Camera2D>();
            return instance;
        }
    }


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
        // The whiteScreen could be disabled to avoid click over it while working
        if (whiteScreen.gameObject.activeSelf == false)
            whiteScreen.gameObject.SetActive(true);


        // White Screen adjustment
        TeaTime whiteScreenAdjustment = this.tt().Add(() =>
        {
            if (whiteScreen != null)
            {
                Vector2 wh = Camera2D.GetWidthHeightScale(Camera.main);

                float width = wh.x;
                float height = wh.y;

                whiteScreen.transform.localScale = new Vector3(width, height, 1) * 1.1f;
                whiteScreen.sortingOrder = Mathf.Abs(Mathf.FloorToInt(layer));
            }
        })
        .Add(1).Repeat();


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


        // #experimental Slowdown on proximity
        // Vector3 camerapos = transform.position;
        // camerapos.z = 0;

        // Vector3 focuspos = pos;
        // focuspos.z = 0;

        // if (Vector3.Distance(camerapos, focuspos) < 7)
        // {
        //     this.tt("SlowdownDown").ttAdd(() =>
        //     {
        //         slowdown = 1;
        //         this.tt("SlowdownUp").ttReset();
        //     })
        //     .ttLoop(1f, (ttHandler t) =>
        //     {
        //         slowdown = Mathf.Lerp(slowdown, 0.34f, t.deltaTime);
        //     })
        //     .ttAdd(int.MaxValue).ttWait();
        // }
        // else
        // {
        //     this.tt("SlowdownUp").ttAdd(() =>
        //     {
        //         this.tt("SlowdownDown").ttReset();
        //     })
        //     .ttLoop(1f, (ttHandler t) =>
        //     {
        //         slowdown = Mathf.Lerp(slowdown, 1f, t.deltaTime);
        //     })
        //     .ttAdd(int.MaxValue).ttWait();
        // }


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
            transform.position = Vector3.Lerp(transform.position, pos, Time.deltaTime * speed * slowdown);
        }
    }
}
