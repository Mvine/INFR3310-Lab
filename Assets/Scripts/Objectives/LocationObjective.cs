using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Collider2D))]
public class LocationObjective : Objective
{
    private Collider2D m_collider;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D other)
    {
        Frogger frog = other.GetComponent<Frogger>();

        //check if it's the player, and then call completed
        if (frog)
        {
            Debug.Log("frog");
            OnCompleted();
        }
    }
}