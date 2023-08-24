using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

public class WallTrap : MonoBehaviour
{
    public GameObject arrowPrefab;
    public Transform arrowSpawnPoint;
    public float shootingInterval = 3.0f;
    private float timeSinceLastShot = 0.0f;

    private bool isShooting = false;


    private void Update()
    {
        timeSinceLastShot += Time.deltaTime;

        if (timeSinceLastShot >= shootingInterval && !isShooting)
        {
            ShootArrow();
            timeSinceLastShot = 0.0f;
        }
    }

    public void ShootArrow()
    {
        isShooting = true;

        GameObject arrow = Instantiate(arrowPrefab, arrowSpawnPoint.position, arrowSpawnPoint.rotation);
        Rigidbody2D arrowRigidbody = arrow.GetComponent<Rigidbody2D>();

        arrowRigidbody.velocity = arrow.transform.up * 1f; 

        isShooting = false;
    }

 

}
