using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponArrow : Weapon
{
    [SerializeField]
    private GameObject arrowPrefab; // Drag and drop the arrow prefab here in the Inspector

    [SerializeField]
    private float arrowSpeed = 20f;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ShootArrow();
        }
    }

    private void ShootArrow()
    {
        // Instantiate the arrow at the character's position and rotation
        GameObject arrowInstance = Instantiate(arrowPrefab, transform.position, transform.rotation);

        // Get the Rigidbody2D component from the arrow instance
        Rigidbody2D arrowRigidbody = arrowInstance.GetComponent<Rigidbody2D>();

        // Calculate the direction the arrow should move
        Vector2 arrowDirection = transform.right * arrowSpeed;

        // Apply a force to the arrow to move it in the calculated direction
        arrowRigidbody.AddForce(arrowDirection, ForceMode2D.Impulse);

        // Destroy the arrow after 2 seconds
        Destroy(arrowInstance, 2f);
    }

    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        // Check if the arrow hit an enemy
        Enemy enemy = hitInfo.GetComponent<Enemy>();
        if (enemy != null)
        {
            // Destroy the arrow and the enemy
            //Destroy(arrowInstance);
            Destroy(hitInfo.gameObject);
        }
    }
}
