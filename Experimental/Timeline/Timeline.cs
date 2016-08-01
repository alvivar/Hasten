
// Timeline that records keyframes over Transforms manipulations. I use this for
// quick animations using the public data with other scripts.

// @matnesis
// 2016/05/13 05:36 PM


using UnityEngine;
using System.Collections.Generic;


public class TimelineNode
{
    public Vector3 position;
    public Vector3 rotation;
    public Vector3 scale;

    public TimelineNode(Vector3 position, Vector3 rotation, Vector3 scale)
    {
        this.position = position;
        this.rotation = rotation;
        this.scale = scale;
    }
}


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

    public List<List<TimelineNode>> childrenData = new List<List<TimelineNode>>();


    void Update()
    {
        Vector3 pos = transform.position;
        position = pos.x + ", " + pos.y + ", " + pos.z;

        Vector3 rot = transform.eulerAngles;
        rotation = rot.x + ", " + rot.y + ", " + rot.z;

        Vector3 scl = transform.localScale;
        scale = scl.x + ", " + scl.y + ", " + scl.z;
    }


    // public void AddSnapshot()
    // {
    //     // Extract all transforms

    //     Transform[] allTrans = transform.GetComponents<Transform>();
    //     var newNode = new List<TimelineNode>();

    //     for (int i = 0, len = allTrans.Length; i < len; i++)
    //     {
    //         newNode.Add(new TimelineNode(
    //             allTrans[i].position,
    //             allTrans[i].eulerAngles,
    //             allTrans[i].localScale
    //         ));
    //     }


    //     // Add
    //     childrenData.Add(newNode);
    // }
}
