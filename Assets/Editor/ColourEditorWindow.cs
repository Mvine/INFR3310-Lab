using UnityEngine;
using UnityEditor;
using System.Collections;

public class ColourEditorWindow : EditorWindow
{

    Color color;

    [MenuItem("Window/Sprite Color")]
    public static void ShowWindow()
    {
        EditorWindow.GetWindow(typeof(ColourEditorWindow));
    }
    private void OnGUI()
    {
        GUILayout.Label("This is a label", EditorStyles.boldLabel);

        color = EditorGUILayout.ColorField("Color", color);

        if (GUILayout.Button("Colorize"))
        {
            Colorize();
        }
    }

    void Colorize()
    {
        foreach (GameObject obj in Selection.gameObjects)
        {
            Renderer renderer = obj.GetComponent<Renderer>();

            if (!renderer)
            {
                return;
            }

            renderer.sharedMaterial.color = color;
        }
    }
}
