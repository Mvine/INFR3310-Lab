using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyA : Enemy
{
    // Start is called before the first frame update
    public override void Constructor()
    {
        GameObject.Instantiate(this, new Vector3(0, 2, 0), Quaternion.identity);
        state = EnemyState.angry;
        //do initialization stuff
    }

}
