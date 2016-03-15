﻿
// Semi-automatic effect layer for a 2D orthographic camera.
// @matnesis ~ 2016/03/14 07:38 PM


using UnityEngine;
using matnesis.TeaTime;

public class Whitescreen : MonoBehaviour
{
    [Header("Automatic")]
    public Renderer render;
    public Material material;
    public Camera cam;
    public int zLayer = 1;


    void Awake()
    {
        // Self
        render = GetComponent<Renderer>();
        material = render.material;


        // The main camera is default
        if (cam == null)
            cam = Camera.main;

        // Parenting & layers        
        transform.SetParent(cam.transform);
        transform.localPosition = new Vector3(0, 0, zLayer);


        // Auto enable
        if (gameObject.activeSelf == false)
            gameObject.SetActive(true);

        // Auto adjustments
        this.tt("AutoAdjustement").Add(() =>
        {
            // Scale
            float height = Camera.main.orthographicSize * 2.0f;
            float width = height * Screen.width / Screen.height;

            transform.localScale = new Vector3(width, height, 1) * 1.1f;
            render.sortingOrder = Mathf.Abs(Mathf.FloorToInt(zLayer));
        })
        .Add(1).Repeat();
    }
}