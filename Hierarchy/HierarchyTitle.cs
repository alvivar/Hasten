using UnityEngine;

[ExecuteInEditMode]
public class HierarchyTitle : MonoBehaviour
{
    public string title = "HierarchyTitle";
    public int margin = 4;

#if UNITY_EDITOR
    void Update()
    {
        var left = new string('-', margin);
        transform.name = $" {left} {{ {title} }}";
    }

    [ContextMenu("Send Far Away")]
    void SendFarAway()
    {
        var farAway = 99999;
        transform.position = new Vector3(farAway, farAway, farAway);
    }
#endif
}