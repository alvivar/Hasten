
// Semi-automatic effect layer for a 2D orthographic camera.

// @matnesis
// 2016/03/14 07:38 PM


using UnityEngine;
using matnesis.TeaTime;

public class Whitescreen : MonoBehaviour
{
    public int zOnCam = 1;
    public bool autoOrthoAdjust = false; // Whitescreen will change his scale to the width and height of the scene

    [Header("Automatic references")]
    public Renderer render;
    public Material material;
    public Camera cam;


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
        transform.localPosition = new Vector3(0, 0, zOnCam);


        // Auto enable
        if (!gameObject.activeSelf)
            gameObject.SetActive(true);

        if (!render.enabled)
            render.enabled = true;


        // Auto scale
        if (autoOrthoAdjust)
        {
            this.tt().Add(() =>
            {
                // Scale
                float height = Camera.main.orthographicSize * 2.0f;
                float width = height * Screen.width / Screen.height;

                transform.localScale = new Vector3(width, height, 1) * 1.1f;
                render.sortingOrder = Mathf.Abs(Mathf.FloorToInt(zOnCam));
            })
            .Add(1).Repeat();
        }
    }
}
