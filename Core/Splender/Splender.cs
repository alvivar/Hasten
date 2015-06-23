
// Splender is a collection of ready-to-use simple static effects.

// Andrés Villalobos > andresalvivar@gmail.com > twitter.com/matnesis
// 2015/06/22 04:15:09 PM


using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;


public class Splender : MonoBehaviour
{
    public static void BubbleExplosion(Transform explosion, Vector3 position, float radius, float duration,
                                       Transform spark, int sparksQuantity, float sparkRadius, float sparkDuration)
    {
        // Main explosion
        Transform mainExplosion = explosion.lpSpawn(position, Quaternion.identity);
        MeshRenderer mainMesh = explosion.GetComponent<MeshRenderer>();


        // Defaults
        mainExplosion.localScale = new Vector3(0.1f, 0.1f, 0.1f);
        mainMesh.material.color = Color.white;


        // Explosion fx
        Sequence ts = DOTween.Sequence();
        ts.Insert(0, mainExplosion.DOScale(radius, duration));
        ts.Insert(0, mainMesh.material.DOColor(Color.clear, duration));
        ts.AppendCallback(() =>
        {
            mainMesh.material.color = Color.clear;
            mainExplosion.lpRecycle();
        });


        // Sparks generation
        Sequence sts = DOTween.Sequence();
        while (sparksQuantity-- > 0)
        {
            Vector3 randomPos = Random.insideUnitSphere * radius;
            Transform someSpark = spark.lpSpawn(position + randomPos, Quaternion.identity);
            MeshRenderer sparkMesh = spark.GetComponent<MeshRenderer>();

            // Sparks default
            someSpark.localScale = new Vector3(0.1f, 0.1f, 0.1f);
            sparkMesh.material.color = Color.white;

            // Spark fx
            sts.Insert(0, someSpark.DOScale(sparkRadius, sparkDuration));
            sts.Insert(0, sparkMesh.material.DOColor(Color.clear, sparkDuration));
            sts.AppendCallback(() =>
            {
                sparkMesh.material.color = Color.clear;
                someSpark.lpRecycle();
            });
        }
    }
}
