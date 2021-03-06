// Created by @wtfmig, shared on Twitter.
// http://twitter.com/wtfmig/status/676883299495624704

// 2015/12/20 02:13 AM

using UnityEngine;

[ExecuteInEditMode]
[AddComponentMenu("Image Effects/PixelBoy")]
public class PixelBoy : MonoBehaviour
{
    public int w = 720;
    int h;

    void Update()
    {
        float ratio = ((float) Camera.main.pixelHeight / (float) Camera.main.pixelWidth);
        h = Mathf.RoundToInt(w * ratio);
    }

    void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        source.filterMode = FilterMode.Point;
        RenderTexture buffer = RenderTexture.GetTemporary(w, h, -1);
        buffer.filterMode = FilterMode.Point;
        Graphics.Blit(source, buffer);
        Graphics.Blit(buffer, destination);
        RenderTexture.ReleaseTemporary(buffer);
    }
}