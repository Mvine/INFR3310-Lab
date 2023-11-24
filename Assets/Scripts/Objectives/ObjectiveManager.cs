using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveManager : Singleton<ObjectiveManager>
{

    //create a list of objectives
    [SerializeField]
    List<Objective> objectives;

    [SerializeField]
    GameObject reward;

    //have a reference to some kind of completion reward
    void Start()
    {
        reward.SetActive(false);

        for(int i = 1; i < objectives.Count-1; i++)
        {
            objectives[i].gameObject.SetActive(false);
        }

        objectives[0].gameObject.SetActive(true);

        //loop through and initialize all the objectives by setting them as false, and then activiting whichever should be active
    }

    // Update is called once per frame
   public void UnregisterObjective(Objective a_objective)
    {
        //remove the objective from the list
        objectives.Remove(a_objective);

        //check to see if there are any remaining objectives, if none then spawn the reward
        if(objectives.Count == 0)
        {
            reward.SetActive(true);
        }

        //else all are not done, set the first index since it's an ordered list to be active

        else
        {
            objectives[0].gameObject.SetActive(true);
        }

        Destroy(a_objective.gameObject);
    }
}
