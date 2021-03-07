// Creates chunks of boxels!

// 2017/04/23 09:16 PM

using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class BoxelStamper : MonoBehaviour
{
    [Header("Config")]
    public Transform boxelPrefab;
    public float gridSize = 0.5f;
    public string parentName = "[BoxelStamp]";
    public LayerMask layer;

    [Header("Pivots")]
    public Transform pivotA;
    public Transform pivotB;

    int createdCount = 0;

    // [ExecuteInEditMode]
    void Update()
    {
        // Snap
        pivotA.transform.position = Snap(pivotA.transform.position, gridSize);
        pivotB.transform.position = Snap(pivotB.transform.position, gridSize);

        // Scale
        pivotA.transform.localScale = new Vector3(gridSize, gridSize, gridSize);
        pivotB.transform.localScale = new Vector3(gridSize, gridSize, gridSize);
    }

    public static Vector3 Snap(Vector3 vector, float size)
    {
        vector.x = Mathf.Round(vector.x / size) * size;
        vector.y = Mathf.Round(vector.y / size) * size;
        vector.z = Mathf.Round(vector.z / size) * size;

        return vector;
    }

    [ContextMenu("Stamp Between Pivots")]
    public void StampBetweenPivots()
    {
        // Parent GameObject.
        var parent = GameObject.Find(parentName);
        if (!parent) parent = new GameObject(parentName);

        // Posibles x y z between pivots.
        List<float> xs = ListUtil.GetNumbersBetween(
            pivotA.position.x,
            pivotB.position.x,
            gridSize);

        List<float> ys = ListUtil.GetNumbersBetween(
            pivotA.position.y,
            pivotB.position.y,
            gridSize);

        List<float> zs = ListUtil.GetNumbersBetween(
            pivotA.position.z,
            pivotB.position.z,
            gridSize);

        // All possible positions between pivots.
        var permutations = ListUtil.PermuteToVector3(xs, ys, zs);

        // Create them.
        foreach (var p in permutations)
        {
            var pos = Snap(new Vector3(p.x, p.y, p.z), gridSize);
            var clone = Instantiate(boxelPrefab, pos, Quaternion.identity);
            clone.gameObject.layer = layer.value;
            clone.SetParent(parent.transform);
        }
    }

    [ContextMenu("Remove Between Pivots")]
    public void RemoveBetweenPivots()
    {
        // Posibles x y z between pivots.
        List<float> xs = ListUtil.GetNumbersBetween(
            pivotA.position.x,
            pivotB.position.x,
            gridSize);

        List<float> ys = ListUtil.GetNumbersBetween(
            pivotA.position.y,
            pivotB.position.y,
            gridSize);

        List<float> zs = ListUtil.GetNumbersBetween(
            pivotA.position.z,
            pivotB.position.z,
            gridSize);

        // All possible positions between pivots.
        var permutations = ListUtil.PermuteToVector3(xs, ys, zs);

        // A list of elements with a collider.
        var toBeDeleted = new List<Transform>();
        foreach (var p in permutations)
        {
            var around = Physics.OverlapSphere(p, gridSize * 0.9f, layer);
            if (around.Length > 0 && !toBeDeleted.Contains(around[0].transform))
                toBeDeleted.Add(around[0].transform);
        }

        // To be deleted.
        foreach (var t in toBeDeleted)
            DestroyImmediate(t.gameObject);
    }
}