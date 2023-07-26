using UnityEngine;

public class FPSSettings : MonoBehaviour
{
    void Update()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Confined;
    }
}
