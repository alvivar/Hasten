
// Takes screenshots around certain area.


using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Camera2DScreenshoter : MonoBehaviour
{
    [Header("Config")]
    public Vector2 dirToScan;

    [Header("Info")]
    public Vector3 originalPosition;
    public Vector2 widthHeigh;


    void Start()
    {
        originalPosition = transform.position;
        widthHeigh = GetWidthHeightScale(Camera.main);

        StartCoroutine(ScanDirection());
    }


    IEnumerator ScanDirection()
    {
        string name = "screenshot";
        string extn = "png";

        for (int i = 0; i < dirToScan.x; i++)
        {
            for (int j = 0; j < dirToScan.y; j++)
            {
                var scanPos = originalPosition + new Vector3(
                    i * widthHeigh.x,
                    j * widthHeigh.y
                );

                transform.position = scanPos;


                // Ignore cicle if there is nothing on the screen
                var size = new Vector3(widthHeigh.x, widthHeigh.y, 2);

                if (!Physics.CheckBox(scanPos, size * 0.5f, Quaternion.identity) && !Physics2D.OverlapBox(scanPos, size, 0))
                    continue;


                var screen = string.Format("{0}.{1}", name + "_" + i + "-" + j, extn);
                Debug.Log(screen + " " + Time.time);

                yield return new WaitForEndOfFrame();
                ScreenCapture.CaptureScreenshot(screen);
            }
        }

        yield return null;
    }


    public static Vector2 GetWidthHeightScale(Camera camera)
    {
        float height = Camera.main.orthographicSize * 2.0f;
        float width = height * Screen.width / Screen.height;

        return new Vector2(width, height);
    }
}
