using UnityEngine;

[ExecuteInEditMode]
public class HierarchyTitle : MonoBehaviour
{
    public string title = "Hierarchy Title";
    public int margin = 4;
    public char character = '-';

    private string lastName = "";

#if UNITY_EDITOR
    void Update()
    {
        var left = new string(character, margin);
        var name = $" {left} {title}";

        if (lastName == name)
            return;
        lastName = name;

        transform.name = name;
    }
#endif
}