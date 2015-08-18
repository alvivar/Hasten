
// 2015/08/11 09:42:14 PM


using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class Camera2D : MonoBehaviour
{
    [Header("Focus")]
    public Transform focus;
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


    void Start()
    {
        // The whiteScreen could be disabled to avoid click over it while working
        if (whiteScreen.gameObject.activeSelf == false)
            whiteScreen.gameObject.SetActive(true);


        // Fix children layer
        Transform[] children = GetComponentsInChildren<Transform>();
        for (int i = 0; i < children.Length; i++)
        {
            if (children[i] == transform) continue;
            children[i].localPosition = new Vector3(children[i].localPosition.x, children[i].localPosition.y, childrenZLayer);
        }


        // White Screen adjustment
        this.tt("whiteScreenAdjustment").ttAdd(() =>
        {
            if (whiteScreen != null)
            {
                float height = Camera.main.orthographicSize * 2.0f;
                float width = height * Screen.width / Screen.height;
                whiteScreen.transform.localScale = new Vector3(width, height, 1) * 1.1f;
                whiteScreen.sortingOrder = Mathf.Abs(Mathf.FloorToInt(layer));
            }
        })
        .ttAdd(1).ttRepeat();
    }


    void Update()
    {
        Vector3 pos = Vector3.zero;


        // Main focus
        if (focus)
            pos = focus.position;


        // Slowdown on proximity #experimental
        Vector3 camerapos = transform.position;
        camerapos.z = 0;

        Vector3 focuspos = pos;
        focuspos.z = 0;

        if (Vector3.Distance(camerapos, focuspos) < 9)
        {
            this.tt("SlowdownDown").ttAdd(() =>
            {
                this.tt("SlowdownUp").ttReset();
                slowdown = 1;
            })
            .ttLoop(1f, (ttHandler t) =>
            {
                slowdown = Mathf.Lerp(slowdown, 0.34f, t.deltaTime);
            })
            .ttAdd(int.MaxValue).ttWait();
        }
        else
        {
            this.tt("SlowdownUp").ttAdd(() =>
            {
                this.tt("SlowdownDown").ttReset();
            })
            .ttLoop(1f, (ttHandler t) =>
            {
                slowdown = Mathf.Lerp(slowdown, 1f, t.deltaTime);
            })
            .ttAdd(int.MaxValue).ttWait();
        }


        // Be at the center of everything
        if (focusGroup.Count > 0)
        {
            for (int i = 0; i < focusGroup.Count; i++)
            {
                pos += focusGroup[i].position;
            }
            pos /= (focusGroup.Count + (focus == null ? 0 : 1)) + 1;
        }


        // Focus
        if (focus || focusGroup.Count > 0)
        {
            pos.z = layer;
            transform.position = Vector3.Lerp(transform.position, pos, Time.deltaTime * speed * slowdown);
        }
    }
}
