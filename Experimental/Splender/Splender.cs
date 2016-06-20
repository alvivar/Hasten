
// Splender is a collection of ready-to-use simple static effects using
// DOTween.

// Andrés Villalobos ^ andresalvivar@gmail.com ^ twitter.com/matnesis
// 2015/06/22 04:15 PM


using UnityEngine;
// using DG.Tweening;

public class Splender : MonoBehaviour
{
    // public static void BubbleExplosion(Transform explosion, Vector3 position, float radius, float duration, Color color)
    // {
    //     // Main explosion
    //     Transform mainExplosion = explosion.lpSpawn(position, Quaternion.identity);
    //     mainExplosion.SetPosZ(Camera.main.transform.position.z + 1);
    //     MeshRenderer mainMesh = mainExplosion.GetComponent<MeshRenderer>();

    //     mainExplosion.localScale = new Vector3(0.1f, 0.1f, 0.1f);
    //     mainMesh.material.color = color;

    //     Sequence ts = DOTween.Sequence();

    //     ts.Insert(0, mainExplosion.DOScale(radius, duration));
    //     ts.Insert(duration * 0.50f, mainMesh.material.DOColor(Color.white * 0.1f, duration - duration * 0.50f));

    //     ts.Insert(duration, mainExplosion.DOScale(radius * 1.5f, duration * 2));
    //     ts.Insert(duration, mainMesh.material.DOColor(Color.clear, duration * 2));

    //     ts.AppendCallback(() =>
    //     {
    //         mainExplosion.lpRecycle();
    //     });
    // }
}
