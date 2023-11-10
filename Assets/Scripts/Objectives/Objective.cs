using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objective : MonoBehaviour
{
    //Things an objective might need are a UI element and a reference to the objective manager

    //Functions we need
    private void Start()
    {
        //create a reference to the manager
    }

    private void OnEnable()
    {
        //Enable appropriate UI
    }
    private void OnDisable()
    {
        //Disable appropriate UI
    }
    protected void OnCompleted()
    {
        //set UI to unactive
        //Unregister from the manager using the singleton
        //Destory this
    }

}
