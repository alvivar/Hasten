using UnityEngine;

[ExecuteInEditMode]
public class HierarchyTitle : MonoBehaviour
{
    public string title = "Hierarchy Title";
    public int margin = 4;

#if UNITY_EDITOR
    void Update()
    {
        if (Application.isPlaying)
            return;

        var left = new string('-', margin);
        transform.name = $" {left} {{ {title} }}";
    }
#endif
}