using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyB : Enemy
{
    public override void Constructor()
    {
        GameObject.Instantiate(this, new Vector3(2, 2, 0), Quaternion.identity);
        state = EnemyState.calm;
    }

    private void Attack()
    {
        //idk do thing
    }
}
