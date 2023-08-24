using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeTrap : MonoBehaviour
{
    public float openDuration = 2.0f;
    public float closedDuration = 4.0f;

    [SerializeField] private Animator animator;
    private BoxCollider2D boxCollider;
    private bool isOpen = false;

    private void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        StartCoroutine(TrapCoroutine());
    }

   
    private IEnumerator TrapCoroutine()
    {
       

        while (true)
        {
            yield return new WaitForSeconds(closedDuration); 
            boxCollider.enabled = false;
            isOpen = true;

            
            yield return new WaitForSeconds(openDuration); 
            boxCollider.enabled = true; 
            isOpen = false;
        }
    }
    private void Update()
    {
        if (isOpen)
        {
            animator.SetBool("IsOpened", false);
        }
        else
        {
            animator.SetBool("IsOpened", true);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!isOpen && other.CompareTag("Assassin"))
        {
            AsassinMovement player = other.GetComponent<AsassinMovement>();
            
                player.die();
            
        }
    }
}
