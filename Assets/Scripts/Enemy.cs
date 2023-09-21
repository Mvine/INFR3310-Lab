using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [Header("Enemy Stats")]
    [SerializeField]
    protected int baseHealth = 10;

    [SerializeField]
    protected float baseMoveSpeed = 1;
    
    [SerializeField]
    protected int attackDamage = 1;

    [SerializeField]
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
    public virtual void Move()
    {
        //this is to be overwritten in the child class
    }
    public virtual void Attack() 
    {
        //this is to be overwritten in the child class
    }
    public virtual void Die()
    {
        //this is to be overwritten in the child class
    }
    public virtual void DropLoot()
    {
        //this is to be overwritten in the child class
    }
    public virtual void GroundCheck()
    {
        
    }
    public Transform EnemyTransform { get => m_enemyTransform; set => m_enemyTransform = value; }
    public int CurrentHealth { get => m_currentHealth; set => m_currentHealth = value; }
    public int CurentSpeed { get => m_curentSpeed; set => m_curentSpeed = value; }

}
