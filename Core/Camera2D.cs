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
    public float childrenLayer = 1;

    [Header("Whitescreen")]
    public SpriteRenderer whitescreen = null;


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
        if (whitescreen.gameObject.activeSelf == false)
            whitescreen.gameObject.SetActive(true);

        // Fix children layer
        Transform[] children = GetComponentsInChildren<Transform>();
        for (int i = 0; i < children.Length; i++)
        {
            if (children[i] == transform) continue;
            children[i].localPosition = new Vector3(children[i].localPosition.x, children[i].localPosition.y, childrenLayer);
        }
    }


    void Update()
    {
        Vector3 pos = Vector3.zero;

        // Main focus
        if (focus)
            pos = focus.position;

        // Be at the center of everything
        if (focusGroup.Count > 0)
        {
            for (int i = 0; i < focusGroup.Count; i++)
            {
                pos += focusGroup[i].position;
            }
            pos /= (focusGroup.Count + (focus == null ? 0 : 1)) + 1;
        }

        // Go!
        if (focus || focusGroup.Count > 0)
        {
            pos.z = layer;
            transform.position = Vector3.Lerp(transform.position, pos, Time.deltaTime * speed);
        }

        // Whitescreen
        this.tt("Whitescreen").ttAdd(delegate()
        {
            if (whitescreen != null)
            {
                float height = Camera.main.orthographicSize * 2.0f;
                float width = height * Screen.width / Screen.height;
                whitescreen.transform.localScale = new Vector3(width, height, 1) * 1.1f;
                whitescreen.sortingOrder = Mathf.Abs(Mathf.FloorToInt(layer));
            }
        })
        .ttAdd(1).ttWait();
    }
}
