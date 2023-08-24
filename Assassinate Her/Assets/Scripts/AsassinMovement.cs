using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class AsassinMovement : MonoBehaviour
{
    public static AsassinMovement main;


    [Header("References")]
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private SpriteRenderer sr;
    [SerializeField] public Transform attackPoint;
    [SerializeField] public Animator animator;
    [SerializeField] public LayerMask EnemyMask;
    [SerializeField] public Transform attackpointTop;
    [SerializeField] public Transform attackpointDown;
    
    [Header("Attributes")]
    [SerializeField] public float moveSpeed = 10f;
    [SerializeField] private float attackRange = 5f;
    [SerializeField] private float attackCD = 2f;
    [SerializeField] private float attackDamage = 1f;

    public Transform aa;

    private bool canAttack =true;

    private bool hasRotatedleft;
    private bool hasRotatedright;
    private bool hasRotatedup;
    private bool hasRotateddown;
    private void Start()
    {
        
    }

    public void die()
    {
        Debug.Log("Busted");
    }
  
    private void ResetAttackCooldown()
    {
        canAttack = true;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && canAttack)
        {
            Attack();
        }
        
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        animator.SetFloat("HorizontalRotation",Mathf.Abs(horizontalInput));
        animator.SetFloat("VerticalRotation", verticalInput);

        Vector2 movement = new Vector2(horizontalInput, verticalInput);

        if (movement.magnitude > 1f)
        {
            movement.Normalize();
        }

        rb.velocity = movement * moveSpeed;
        movement *= moveSpeed * Time.deltaTime;
        Vector2 newPosition = rb.position + movement;

        
        //rb.MovePosition(newPosition);

        if (horizontalInput > 0 && !hasRotatedright)
        {
            aa = attackPoint;
            rotateRight();
        }
        else if (horizontalInput < 0 && !hasRotatedleft)
        {
            aa = attackPoint;
            rotateLeft();
        }
        else if (horizontalInput == 0 && verticalInput == 0)
        {
            //returnNormal();
        }

        if (verticalInput > 0 && !hasRotatedup)
        {
            
            aa = attackpointTop;
            rotateUp();
        }
        else if (verticalInput < 0 && !hasRotateddown)
        {
            aa = attackpointDown;
            rotateDown();
        }
        

    }

    void Attack()
    {
        canAttack = false;
        Invoke("ResetAttackCooldown", attackCD);
        if (hasRotatedup == true)
        {
            animator.SetTrigger("AttackTop");
        }
        else if (hasRotateddown == true)
        {
            animator.SetTrigger("AttackDown");
        }
        else
            animator.SetTrigger("Attack");

        Collider2D[] hitEnemy = Physics2D.OverlapCircleAll(aa.position, attackRange, EnemyMask);

        foreach (Collider2D enemy in hitEnemy)
        {
            if(enemy.TryGetComponent<Enemy>(out var e))
            {
                e.takeDamage(attackDamage);
            }
        }

    }


    private void OnCollisionEnter2D(Collision2D other)
    {
       
       
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }

    private void Awake()
    {
        main = this;
    }

    void returnNormal()
    {
        Vector3 RotateLeft = transform.rotation.eulerAngles;
        RotateLeft.y = 0f;
        RotateLeft.z = 0;
        transform.rotation = Quaternion.Euler(RotateLeft);
    }

    void rotateRight()
    {
        Vector3 RotateRight = transform.rotation.eulerAngles;
        RotateRight.y = 0;
        RotateRight.z = 0;
        transform.rotation = Quaternion.Euler(RotateRight);
        hasRotatedleft = false;
        hasRotatedright = true;
        hasRotateddown = false;
        hasRotatedup = false;
    }
    void rotateLeft()
    {
        Vector3 RotateLeft = transform.rotation.eulerAngles;
        RotateLeft.y += 180f;
        RotateLeft.z = 0;
        transform.rotation = Quaternion.Euler(RotateLeft);
        hasRotatedleft = true;
        hasRotatedright = false;
        hasRotateddown = false;
        hasRotatedup = false;
    }

    void rotateUp()
    {
        //Vector3 Rotate = transform.rotation.eulerAngles;
        //Rotate.z += 90;
        //Rotate.y = 0;
        //transform.rotation = Quaternion.Euler(Rotate);
        hasRotateddown = false;
        hasRotatedup = true;
        hasRotatedleft = false;
        hasRotatedright = false;
    }

    void rotateDown()
    {
        //Vector3 Rotate = transform.rotation.eulerAngles;
        //Rotate.z -= 90f;
        //Rotate.y = 0;
        //transform.rotation = Quaternion.Euler(Rotate);
        hasRotateddown = true;
        hasRotatedup = false;
        hasRotatedleft = false;
        hasRotatedright = false;
    }
}
