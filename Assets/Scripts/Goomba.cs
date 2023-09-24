using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goomba : BaseEnemy
{
    [SerializeField]
    protected int defense = 1;

    //override for attacking
    public override void Attacking()
    {
       //the goomba does not do anything
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public override void Update()
    {
       //the goomba does not move
    }

    public virtual void BreakDance()
    {

    }
}
