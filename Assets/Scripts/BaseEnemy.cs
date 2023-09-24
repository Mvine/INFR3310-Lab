using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseEnemy : MonoBehaviour
{

    public enum EnemyState
    {
        idle,
        wander,
        attacking
    }


    [SerializeField]
    protected float moveSpeed = 1.0f;
    [SerializeField]
    protected float baseHealth = 10.0f;
    [SerializeField]
    protected Vector3 color = new Vector3(1.0f, 1.0f, 1.0f);
    [SerializeField]
    protected int attackStat = 1;

    public EnemyState enemyState = EnemyState.idle;


    protected Collider enemyHitbox = null;


    int m_currentHealth;
    bool m_dead;

    public int CurrentHealth { get => m_currentHealth; set => m_currentHealth = value; }
    public bool Dead { get => m_dead; set => m_dead = value; }

    // Start is called before the first frame update
    void Start()
    {
        enemyHitbox = this.transform.GetComponent<Collider>();
    }


    public virtual void Attacking()
    {

        enemyHitbox.gameObject.SetActive(true);
        enemyState = EnemyState.attacking;

    }

    public virtual void Move()
    {
        this.transform.position = this.transform.position + new Vector3(0, 0, 1) * moveSpeed * Time.deltaTime;
    }



    // Update is called once per frame
    public virtual void Update()
    {
        Move();
    }
}
