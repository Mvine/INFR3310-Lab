using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveManager : Singleton<ObjectiveManager>
{
    // Start is called before the first frame update

    //create a list of objectives

    //have a reference to some kind of completion reward
    void Start()
    {
        //loop through and initialize all the objectives by setting them as false, and then activiting whichever should be active
    }

    // Update is called once per frame
   public void UnregisterObjective(Objective a_objective)
    {
        //remove the objective from the list

        //check to see if there are any remaining objectives, if none then spawn the reward
        
        //else all are not done, set the first index since it's an ordered list to be active
    }
}
