using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Objective : MonoBehaviour
{
    //Things an objective might need are a UI element and a reference to the objective manager
    [SerializeField]
    GameObject TextUI;

    protected GameObject m_text;
    
    //Functions we need
    private void Start()
    {
        if(TextUI)
        {
            m_text = TextUI;
        }

        //create a reference to the manager
    }
    protected void OnCompleted()
    {
        //set UI to unactive
        TextUI.SetActive(false);

        //Unregister from the manager using the singleton

        ObjectiveManager.Instance().UnregisterObjective(this);

        //Destory this

        Destroy(this);
    }

}
