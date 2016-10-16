
// This component updates the Camera2D offset with the closest
// Camera2DOffsetData.

// @matnesis
// 2016/10/09 06:14 PM


using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using matnesis.TeaTime;

public class Camera2DOffsetCaster : MonoBehaviour
{
    public float tolerance = 16; // Search every 32 units of distance
    public LayerMask layerThatBlocks; // The layers that will block the activate

    [Header("Info")]
    public Vector3 lastPosition;
    public List<Camera2DOffsetData> offsets;

    private Camera2D cam;
    private static MonoBehaviour mono;


    void Start()
    {
        cam = Game.camera2D;
        if (mono == null) mono = this;


        // @
        // This sequence updates the Camera2D offset with the closest
        // Camera2DOffsetData.
        {
            Camera2DOffsetData latest = null;
            lastPosition = Vector3.zero;

            this.tt().Add(0.50f, (ttHandler t) =>
            {
                // Do they exists?
                if (Camera2DOffsetData.all == null) return;

                // Are we in a new position?
                var snapPos = SnapVector(transform.position, tolerance);
                if (snapPos != lastPosition)
                {
                    lastPosition = snapPos;

                    // Sort them
                    offsets = Camera2DOffsetData.all
                        .OrderBy(x => (snapPos - x.transform.position).sqrMagnitude)
                        .ToList();

                    // Update if new
                    if (offsets.Count > 0 && offsets[0] != latest)
                    {
                        // Ignore if there is something between us
                        var tPos = transform.position;
                        var oPos = offsets[0].transform.position;
                        var dir = (oPos - tPos).normalized;
                        var distance = Vector3.Distance(oPos, tPos);

                        if (Physics2D.Raycast(transform.position, dir, distance, layerThatBlocks))
                            return;


                        // Interpolate
                        latest = offsets[0];
                        InterpolateCamera2DOffsetOverride(offsets[0].offset);

                        Debug.Log("Camera2D :: New Override Offset = " + offsets[0].offset);
                    };
                }
            })
            .Repeat();
        }
    }


    private void InterpolateCamera2DOffsetOverride(Vector3 newOffset)
    {
        // Interpolation
        Vector3 current = cam.focusOffsetOverride;
        mono.tt("@InterpolateCamera2DOffsetOverride").Reset().Loop(3f, (ttHandler t) =>
        {
            cam.focusOffsetOverride = Vector3.Lerp(
                current,
                newOffset,
                Easef.EaseIn(t.t)
            );
        });
    }


    public static Vector3 SnapVector(Vector3 vector, float gridSize)
    {
        return new Vector3(
            Mathf.Round(vector.x / gridSize) * gridSize,
            Mathf.Round(vector.y / gridSize) * gridSize,
            Mathf.Round(vector.z / gridSize) * gridSize
        );
    }
}
