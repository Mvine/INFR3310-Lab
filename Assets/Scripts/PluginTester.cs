using UnityEngine;
using System.Runtime.InteropServices;

public class PluginTester : MonoBehaviour
{

    [DllImport("UnityDLL")]
    private static extern int GetID();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            Debug.Log(GetID());
        }
        
    }
}
