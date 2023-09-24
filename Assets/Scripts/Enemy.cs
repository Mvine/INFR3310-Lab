using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{

    //Inspector Variables
    [Header("Enemy Stats")]
    [Tooltip("Enemy base health")]
    [SerializeField]
    protected int baseHealth = 10;

    [SerializeField]
    [Tooltip("How fast the enemy moves")]
    protected float baseMoveSpeed = 1;
    
    [SerializeField]
    [Tooltip("How much damage the enemies attack does")]
    protected int attackDamage = 1;

    [SerializeField]
    [Tooltip("GameObject that is dropped when the DropLoot() function is called")]
    protected GameObject baseRewardDrop = null;

    [SerializeField]
    protected Collider groundCheckCollider = null;

    private Transform m_enemyTransform;
    private int m_currentHealth;
    private int m_curentSpeed;
    private bool m_isGrounded;


    //Monobehaviour Functions
    public virtual void Start()
    {
        m_enemyTransform = this.GetComponent<Transform>();
    }

    public abstract void Update();

    //Enemy Functions
    public virtual IEnumerator Wander(float moveRadius, float moveSpeed)
    {

        while(transform.position !=)

        yield return null;
        //we'll do some kinda basic wander pattern here
    }
    public virtual void Attack() 
    {
        //this is to be overwritten in the child class
    }
    public virtual void Die()
    {
        //Start Death Sequence
        //this is to be overwritten in the child class
    }
    public virtual void DropLoot()
    {
        //this is to be overwritten in the child class
    }
    public virtual void GroundCheck()
    {
        //this is to be overwritten in the child class
    }
    public virtual void TakeDamage()
    {
        //this is to be overwritten in the child class
    }

    //Setters & Getters
    public Transform EnemyTransform { get => m_enemyTransform; set => m_enemyTransform = value; }
    public int CurrentHealth { get => m_currentHealth; set => m_currentHealth = value; }
    public int CurentSpeed { get => m_curentSpeed; set => m_curentSpeed = value; }

}
