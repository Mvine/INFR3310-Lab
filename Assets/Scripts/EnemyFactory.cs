using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFactory : Factory
{

    [SerializeField]
    List<Enemy> enemyList;


    // Start is called before the first frame update
    void Start()
    {
        foreach (Enemy enemy in enemyList)
        {
            enemy.Constructor();
            
        }
    }

}
