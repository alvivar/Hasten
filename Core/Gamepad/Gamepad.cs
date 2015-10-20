
// Simple bind between Action events and Inputs.

// Andrés Villalobos ^ andresalvivar@gmail.com ^ twitter.com/matnesis
// 2015/08/11 09:15 PM


using UnityEngine;
using System.Collections;
using System;


public class Gamepad : MonoBehaviour
{
    public Action OnSpacebar;
    public Action OnLeftShiftIn;
    public Action OnLeftShiftOut;

    public Action OnKIn;
    public Action OnKOut;


    void Update()
    {
        // Spacebar
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.O))
        {
            if (OnSpacebar != null)
                OnSpacebar();
        }

        // Left shift down
        if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.P))
        {
            if (OnLeftShiftIn != null)
                OnLeftShiftIn();
        }

        // Left shift up
        if (Input.GetKeyUp(KeyCode.LeftShift) || Input.GetKeyUp(KeyCode.P))
        {
            if (OnLeftShiftOut != null)
                OnLeftShiftOut();
        }


        // Zoom test
        if (Input.GetKeyDown(KeyCode.M))
        {
            if (OnKIn != null)
            {
                OnKIn();
            }
        }

        if (Input.GetKeyUp(KeyCode.M))
        {
            if (OnKOut != null)
            {
                OnKOut();
            }
        }
    }
}
