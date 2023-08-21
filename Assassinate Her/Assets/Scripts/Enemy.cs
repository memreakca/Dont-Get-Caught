using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public static Enemy main;

    [Header("References")]
  
    [SerializeField] public Transform attackP;
    //[SerializeField] public Animator animator;
    [SerializeField] public LayerMask EnemyMask;
    
    [Header("Attributes")]
    [SerializeField] private float HP = 1f;
    [SerializeField] private float attackRange = 1f;

    private void Update()
    {
        
        Collider2D[] hitplayer = Physics2D.OverlapCircleAll(attackP.position, attackRange, EnemyMask);
        foreach(Collider2D player in hitplayer)
        {
            AsassinMovement.main.die();
        }
    }
    private void Awake()    
    {
        main = this;
    }
    public void takeDamage(float dmg)
    {
        HP -= dmg;
        if (HP <= 0f)
        {
            Debug.Log("Enemy died");
            //Destroy(gameObject); 
        }
       
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
      
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(attackP.position, attackRange);
    }
}
