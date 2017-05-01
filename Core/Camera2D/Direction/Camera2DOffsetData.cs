
// This component contains offset information for the camera and an static
// reference to all like him.

// @matnesis
// 2016/10/09 06:14 PM


using UnityEngine;
using System.Collections.Generic;
using matnesis.TeaTime;
using matnesis.Reactive;

[ReactiveInEditMode]
[ExecuteInEditMode]
public class Camera2DOffsetData : MonoBehaviour
{
    [Header("Config")]
    public Vector2 offset; // New camera offset
    public float changeDuration = 4;
    public float zoom; // New camera zoom
    public float zoomDuration = 4f;
    public GameObject cameraLockObject; // Priorize to centers around an object
    public string findLockObject; // Find objects by name for the cameraLockObject ^
    public bool cinematic; // Ignore itselfs from <all> static list

    [Header("Reactive")]
    public ReactiveBool forceRefresh = new ReactiveBool(false);

    [Header("Info")]
    public Transform icon = null; // Gameobject used to visualize
    public bool inTransition; // Indicates transition

    public static List<Camera2DOffsetData> all;


    GameObject ghost;
    Camera2DOffsetCaster camCaster;


    void Awake()
    {
        // A list of all of us
        if (all == null)
            all = new List<Camera2DOffsetData>();

        // Cinematics are used for specific stuff
        if (!all.Contains(this) && !cinematic)
            all.Add(this);
    }


    void Start()
    {
        camCaster = FindObjectOfType<Camera2DOffsetCaster>();

        var ghostName = "ghost@cameraOffset";
        ghost = GameObject.Find(ghostName);
        ghost = ghost ? ghost : new GameObject(ghostName);


        // We don't need the icon while playing
        if (icon)
        {
            GameObject.DestroyImmediate(icon.gameObject);
            icon = null;
        }


        // This will force the camera update
        forceRefresh.Subscribe(x =>
        {
            if (x) camCaster.forceDetection = true;
            forceRefresh.Value = false;

            // Try to save the values outside the editor
            // PlayerPrefs.SetString(transform.GetInstanceID() + ".x", offset.x + "");
            // PlayerPrefs.SetString(transform.GetInstanceID() + ".y", offset.y + "");
        });
    }


    void OnDestroy()
    {
        // Out
        if (all != null && all.Contains(this)) all.Remove(this);
    }


    public void InterpolateCamera2DOffsetOverride()
    {
        if (!string.IsNullOrEmpty(findLockObject) && cameraLockObject == null)
        {
            cameraLockObject = GameObject.Find(findLockObject);
        }

        Camera2D cam = Game.camera2D;

        // Interpolation
        inTransition = true;
        // Game.offsetCaster.executeInterpolation = !inTransition;

        Vector3 current = cam.focusOffsetOverride;
        float cameraSize = Game.camera2D.layer;

        if (zoom != 0)
        {
            ZoomIn();
        }
        else
        {
            if (cameraSize != Game.defaultOrthographicSize)
            {
                ZoomOut();
            }
        }


        Vector3 ghostPos = Vector3.zero;
        this.tt("@InterpolateCamera2DOffsetOverride").Reset()
        .Add(() =>
        {
            if (cameraLockObject != null)
            {
                ghost.transform.position = (Game.player.position + cameraLockObject.transform.position) / 2;
                ghost.transform.position += Game.camera2D.focusOffsetFixed;
                Game.camera2D.focusGroup.Add(ghost.transform);
                ghostPos = ghost.transform.position;
            }
            else
            {
                if (Game.camera2D.focusGroup.Count > 0)
                {
                    ghostPos = Game.camera2D.focusGroup[0].position;
                }
            }
        })
        .Loop(changeDuration, (ttHandler t) =>
        {
            if (Game.camera2D.focusGroup.Count <= 0)
            {
                // Moving the ghost to target
                cam.focusOffsetOverride = Vector3.Lerp(
                current,
                offset,
                t.t);
            }
            else
            {
                ghost.transform.position = Vector3.Lerp(
                    ghostPos,
                    Game.player.position + Game.camera2D.focusOffsetFixed,
                    t.t
                );
            }
        }).Add(() =>
        {
            inTransition = false;
            //Game.offsetCaster.executeInterpolation = !inTransition;
        });
    }


    void ZoomIn()
    {
        {
            float cameraSize = 0;
            Vector3 ghostPos = Vector3.zero;
            this.tt("@zoomIn").Reset().Add(() =>
            {
                // Create a ghost that will be followed by the camera
                if (cameraLockObject != null)
                {
                    ghost.transform.position = (Game.player.position + cameraLockObject.transform.position) / 2;
                    ghost.transform.position += Game.camera2D.focusOffsetFixed;
                    Game.camera2D.focusGroup.Add(ghost.transform);
                    ghostPos = ghost.transform.position;
                }
                else
                {
                    // Back to normal
                    if (Game.camera2D.focusGroup.Count > 0)
                    {
                        Game.camera2D.focusGroup.Clear();
                    }
                }
                // Current
                cameraSize = Game.camera2D.layer;
            })
            .Loop(zoomDuration, (ttHandler t) =>
            {
                // Camera zoom
                Game.camera2D.layer = Mathf.Lerp(
                    cameraSize,
                    zoom,
                    t.t
                );

                if (cameraLockObject != null)
                {
                    // Moving the ghost to the HiveLord
                    ghost.transform.position = Vector3.Lerp(
                        ghostPos,
                        cameraLockObject.transform.position + Game.camera2D.focusOffsetFixed,
                        t.t
                    );
                }
            }).Immutable();
        }
    }


    void ZoomOut()
    {
        {
            float cameraSize = 0;
            Vector3 ghostPos = Vector3.zero;

            this.tt("@zoomOut").Reset().Add(() =>
            {
                ghostPos = ghost.transform.position;
                cameraSize = Game.camera2D.layer;
            })
            .Loop(zoomDuration, (ttHandler t) =>
            {
                // Zoom out
                Game.camera2D.layer = Mathf.Lerp(
                    cameraSize,
                    Game.defaultOrthographicSize,
                    Easef.Smoothstep(t.t)
                );

                // Moving to ghost to the player
                ghost.transform.position = Vector3.Lerp(
                    ghostPos,
                    Game.player.position + Game.camera2D.focusOffsetFixed,
                    t.t
                );
            })
            .Add(() =>
            {
                // Back to normal
                Game.camera2D.focusGroup.Clear();
            }).Immutable();
        }
    }


    public void RemoveLockObject()
    {
        cameraLockObject = null;
        Game.camera2D.focusGroup.Clear();
        InterpolateCamera2DOffsetOverride();
    }


    // This part should work only on the Editor
#if UNITY_EDITOR
    void Update()
    {
        if (!Application.isPlaying)
        {
            // Get / create a child cube to be used as icon / direction
            string name = "@icon";

            // Find
            if (icon == null) icon = transform.FindChild(name);

            // Or create
            if (icon == null)
            {
                icon = GameObject.CreatePrimitive(PrimitiveType.Cube).transform;
                icon.name = name;
                icon.parent = transform;
            }

            // Sync
            // :+#;-#;+0
            transform.name = string.Format(
                "x{0} y{1} {2}s | z{3} {4}s",
                offset.x, offset.y, changeDuration,
                zoom, zoomDuration);

            // The icon properties are trying to represent the offset direction :)
            icon.localPosition = Vector3.zero;
            icon.localScale = (Vector3.one + (Vector3)offset).normalized * 5;

            if (offset.normalized != Vector2.zero)
                icon.forward = offset.normalized;


            // Always at z 0
            var pos = transform.localPosition;
            if (pos.z != 0)
            {
                pos.z = 0;
                transform.localPosition = pos;
            }



            // Name the parent
            // This is commented, because it could be dangerous
            // var parentName = "CameraOffsets";
            // if (transform.parent.name != parentName) transform.parent.name = parentName;


            // Use the saved date when it was force during the editor as
            // current, then delete it.

            // var xKey = transform.GetInstanceID() + ".x";
            // var yKey = transform.GetInstanceID() + ".y";

            // if (PlayerPrefs.HasKey(xKey))
            // {
            //     offset.x = float.Parse(PlayerPrefs.GetString(xKey));
            //     PlayerPrefs.DeleteKey(xKey);
            // }

            // if (PlayerPrefs.HasKey(yKey))
            // {
            //     offset.y = float.Parse(PlayerPrefs.GetString(yKey));
            //     PlayerPrefs.DeleteKey(yKey);
            // }

        }
    }
#endif
}
