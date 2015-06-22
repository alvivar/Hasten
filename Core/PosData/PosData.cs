using UnityEngine;
using System.Collections;
using System.Collections.Generic;


[ExecuteInEditMode]
public class PosData : MonoBehaviour
{
    [HideInInspector]
    public List<Vector3> all;
    public string currentPos = "";
    public string selectedPos = "";


    void Start()
    {
        all = new List<Vector3>();
    }


    void Update()
    {
        Vector3 pos = transform.position;
        currentPos = pos.x + ", " + pos.y + ", " + pos.z;
    }
}
