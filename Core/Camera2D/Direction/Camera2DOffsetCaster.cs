
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
    [Header("Config")]
    public bool forceDetection = false; // On true, it will force the detection of near cams and apply again the transition
    public float tolerance = 16; // Units of distance to search between movement
    public float changeDuration = 2;
    public LayerMask layerThatBlocks; // The layers that blocks detections
    public bool executeInterpolation = true;

    [Header("Info")]
    public Vector3 lastSnapPos;
    public List<Camera2DOffsetData> offsets;

    Camera2D cam;


    void Start()
    {
        cam = Game.camera2D;


        // @
        // This sequence updates the Camera2D with the info from the closest
        // Camera2DOffsetData.
        {
            Camera2DOffsetData latest = null;
            lastSnapPos = Vector3.zero;

            this.tt().Add(0.50f, (ttHandler t) =>
            {
                if (!executeInterpolation)
                    return;


                // Do they exists?
                if (Camera2DOffsetData.all == null)
                {
                    ResetCameraInterpolationOffset();
                    return;
                }


                // Are we in a new position?
                var snapPos = Snap(transform.position, tolerance);
                if (snapPos != lastSnapPos || forceDetection)
                {
                    lastSnapPos = snapPos;

                    // Sort them
                    offsets = Camera2DOffsetData.all
                        .OrderBy(x => (snapPos - x.transform.position).sqrMagnitude)
                        .ToList();

                    // Update if new
                    if (offsets.Count > 0 && (offsets[0] != latest || forceDetection))
                    {
                        // Calculations
                        var tPos = transform.position;
                        var oPos = offsets[0].transform.position;
                        var dir = (oPos - tPos).normalized;
                        var distance = Vector3.Distance(oPos, tPos);

                        // Ignore if there is something between us
                        if (Physics2D.Raycast(transform.position, dir, distance, layerThatBlocks))
                            return;

                        // Interpolate
                        latest = offsets[0];
                        offsets[0].InterpolateCamera2DOffsetOverride();
                        offsets[0].transform.SetAsFirstSibling(); // Move up in the list
                        Debug.Log("Cam2D Offset Caster :: Override -> " + offsets[0].offset, transform);

                        // Just once
                        forceDetection = false;
                    }
                }
            })
            .Repeat();
        }
    }


    private void ResetCameraInterpolationOffset()
    {
        // Interpolation
        Vector3 current = cam.focusOffsetOverride;
        this.tt("@InterpolateCamera2DOffsetOverride").Reset().Loop(changeDuration, (ttHandler t) =>
        {
            cam.focusOffsetOverride = Vector3.Lerp(
                current,
                Vector3.zero,
                Easef.Smootherstep(t.t)
            );
        });
    }


    public static Vector3 Snap(Vector3 vector, float size)
    {
        return new Vector3(
            Mathf.Round(vector.x / size) * size,
            Mathf.Round(vector.y / size) * size,
            Mathf.Round(vector.z / size) * size
        );
    }
}
