using UnityEngine;

[ExecuteInEditMode]
public class HierarchyTitle : MonoBehaviour
{
    public string title = "Hierarchy Title";
    public int margin = 4;
    public char character = '-';

    private string lastTitle = "";

#if UNITY_EDITOR
    void Update()
    {
        if (title == lastTitle)
            return;
        lastTitle = title;

        var left = new string(character, margin);
        transform.name = $" {left} {title}";
    }
#endif
}