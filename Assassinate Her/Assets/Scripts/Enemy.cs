using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("References")]

    [SerializeField] Transform[] waypoints;

    
    [SerializeField] public Transform attackPright;
    [SerializeField] public Transform attackPleft;
    [SerializeField] public Animator animator;
    [SerializeField] public LayerMask EnemyMask;
    [SerializeField] public SpriteRenderer sr;
    [SerializeField] public GameObject rangeright;
    [SerializeField] public GameObject rangeleft;
    public Transform attackP;

    [Header("Attributes")]
    [SerializeField] private float HP = 1f;
    [SerializeField] private float attackRange = 1f;
    [SerializeField] private float speed;
    [SerializeField] private float waitTime = 1f;

    private int currentWaypointIndex;
    private Transform currentWaypoint;

    private bool isWaiting = false;
    private bool isAlive = true;
    

    private void Start()
    {
        animator.SetBool("IsMoving", true);
        if (waypoints.Length > 0)
        {
            currentWaypoint = waypoints[currentWaypointIndex];
        } 
       
    }
    private void Update()
    {
        if (!isWaiting)
        {
            MoveToWaypoint();
        }

        Collider2D[] hitplayer = Physics2D.OverlapCircleAll(attackP.position, attackRange, EnemyMask);
        foreach(Collider2D player in hitplayer)
        {
            if(isAlive == true)
            AsassinMovement.main.die();
        }
    }
    private void Awake()    
    {
    }

    private void MoveToWaypoint()
    {
        Vector3 direction = (currentWaypoint.position - transform.position);
        transform.Translate(direction * speed * Time.deltaTime);

        if (direction.x > 0)
        {
            sr.flipX = false;
            attackP = attackPright;
            rangeright.SetActive(true);
            rangeleft.SetActive(false);
        }
        else if (direction.x < 0)
        {
            sr.flipX = true;
            attackP = attackPleft;
            rangeright.SetActive(false);
            rangeleft.SetActive(true);
        }

        if (Vector2.Distance(transform.position, currentWaypoint.position) < 0.1f)
        {
            StartCoroutine(WaitAtWaypoint());
        }
    }

    private IEnumerator WaitAtWaypoint()
    {
        isWaiting = true;
        animator.SetBool("IsMoving", false);
        yield return new WaitForSeconds(waitTime);
        animator.SetBool("IsMoving", true);
        isWaiting = false;

        currentWaypointIndex = (currentWaypointIndex+1) % waypoints.Length;
        currentWaypoint = waypoints[currentWaypointIndex];
    }
    public void takeDamage(float dmg)
    {
        HP -= dmg;
        animator.SetTrigger("Hit");
        if (HP <= 0f)
        {
            speed = 0;
            isAlive = false;
            Debug.Log("Enemy died");
            Invoke("deadEnemy", 1.10f);

            //Destroy(gameObject); 
        }
       
    }
    void deadEnemy()
    {
        Destroy(gameObject);
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
      
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(attackP.position, attackRange);
    }
}
