using UnityEngine;
using System.Runtime.InteropServices;

public class PluginTester : MonoBehaviour
{
    private const string DLL_NAME = "UnityDLL";

    //Importing our DLL settings
    [DllImport(DLL_NAME)]
    private static extern int GetID();

    [DllImport(DLL_NAME)]
    private static extern int SetID(int id);

    //importing data from C++ side, this doesn't exist in C#, but we made a C++ vector2D struct. We need to deserialize the data
    [StructLayout(LayoutKind.Sequential)]
    struct Vector2D
    {
        public float x;
        public float y;
    }

    //Here is our marshalling for getting our struct between programs
    [DllImport(DLL_NAME)]
    private static extern Vector2D GetPosition();

    [DllImport(DLL_NAME)]
    private static extern void SetPosition(float x, float y);

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {

            SetID(33);

            Debug.Log(GetID());

            SetPosition(3.3f, 5.7f);
            Debug.Log(GetPosition().x);
            Debug.Log(GetPosition().y);
        }

    }
}
