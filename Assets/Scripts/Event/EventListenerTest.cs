using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventListenerTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Frogger.Instance().onMoved += Test;
    }

    void Test()
    {
        Debug.Log("This is listening for the player event and then executes when the event is invoked.");
    }

    private void OnDestroy()
    {
        Frogger.Instance().onMoved -= Test;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
