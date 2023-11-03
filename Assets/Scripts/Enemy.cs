using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    public enum EnemyState
    {
        angry,
        calm
    };

    protected EnemyState state;

    protected int health;
    protected int attack;

    // Start is called before the first frame update
    public abstract void Constructor();

    // Update is called once per frame
    void Update()
    {
        
    }
}
