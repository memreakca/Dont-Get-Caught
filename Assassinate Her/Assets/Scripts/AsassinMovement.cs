using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsassinMovement : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private SpriteRenderer sr;
    [SerializeField] public float moveSpeed = 10f;

    public Animator animator;
    private void Start()
    {
        
    }

    void Attack()
    {
        animator.SetTrigger("Attack");
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            Attack();
        }
        
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        
        Vector2 movement = new Vector2(horizontalInput, verticalInput) * moveSpeed * Time.deltaTime;
        Vector2 newPosition = rb.position + movement;

        rb.MovePosition(newPosition);

        if (horizontalInput > 0)
        {
            sr.flipX = false; 
        }
        else if (horizontalInput < 0)
        {
            sr.flipX = true; 
        }
    }

    
    private void OnCollisionEnter2D(Collision2D collision2D)
    {
        //if (collision2D.gameObject.CompareTag("Environment"))
        //{
            Debug.Log("Collided with square!");
        //}
    }
}
