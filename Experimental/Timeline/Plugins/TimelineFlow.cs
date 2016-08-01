﻿
// Timeline animation flow using TeaTime.

// @matnesis
// 2016/05/14 12:15 AM


using UnityEngine;
using matnesis.TeaTime;

[RequireComponent(typeof(Timeline))]
public class TimelineFlow : MonoBehaviour
{
    public int index = 0;
    private Timeline timeline;


    void Start()
    {
        timeline = GetComponent<Timeline>();
    }


    // void Update()
    // {
    //     // Debug
    //     if (Input.GetKeyDown(KeyCode.M))
    //         GoTo(index + 1, 2);

    //     if (Input.GetKeyDown(KeyCode.N))
    //         GoTo(index - 1, 2);
    // }


    /// <summary>
    /// Reseteable smooth transition to the selected Timeline index.
    /// </summary>
    public TeaTime FlowTo(int index, float seconds)
    {
        // Allows to do this GoTo(index + 1, 2)
        index = index > timeline.positions.Count ? 0 : index;
        index = index < 0 ? timeline.positions.Count - 1 : index;
        this.index = index;

        // @
        return this.tt("@flowTo").Reset().Add((ttHandler t) =>
        {
            t.Wait(this.ttMove(transform, timeline.positions[index], seconds));
            t.Wait(this.ttRotate(transform, timeline.rotations[index], seconds));
            t.Wait(this.ttScale(transform, timeline.scales[index], seconds));
        });
    }


    public TeaTime Stop()
    {
        return this.tt("@flowTo").Reset();
    }
}
