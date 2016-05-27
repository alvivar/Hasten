
// Timeline that records keyframes over Transforms manipulations. I use this for
// quick animations using the public data with other scripts.

// @matnesis
// 2016/05/13 05:36 PM


using UnityEngine;
using System.Collections.Generic;

[ExecuteInEditMode]
public class Timeline : MonoBehaviour
{
    [SerializeField]
    string position = "";
    [SerializeField]
    string rotation = "";
    [SerializeField]
    string scale = "";

    [Header("Data")]
    public List<Vector3> positions;
    public List<Vector3> rotations;
    public List<Vector3> scales;


    void Update()
    {
        Vector3 pos = transform.position;
        position = pos.x + ", " + pos.y + ", " + pos.z;

        Vector3 rot = transform.eulerAngles;
        rotation = rot.x + ", " + rot.y + ", " + rot.z;

        Vector3 scl = transform.localScale;
        scale = scl.x + ", " + scl.y + ", " + scl.z;
    }
}
