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

     public Transform Player;
       public Rigidbody2D Playerbody;

    void Start(){
        Player = FindObjectOfType<Player>().transform;
        Playerbody = Player.GetComponent<Rigidbody2D>();
    }


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
        GameObject arrowInstance = Instantiate(arrowPrefab, transform.position,transform.rotation);

        // Get the Rigidbody2D component from the arrow instance
        Rigidbody2D arrowRigidbody = arrowInstance.GetComponent<Rigidbody2D>();

        // Calculate the direction the arrow should move
        Vector2 arrowDirection;
        if (Playerbody.velocity.normalized == Vector2.zero){

            arrowDirection = transform.right * arrowSpeed;
        }
        else{
            arrowDirection = Playerbody.velocity.normalized * arrowSpeed;
        }

        // Apply a force to the arrow to move it in the calculated direction
        arrowRigidbody.AddForce(arrowDirection, ForceMode2D.Impulse);

        float ArrowAngel = Vector2.SignedAngle(Vector2.right,arrowDirection.normalized);

        arrowInstance.transform.Rotate(0,0,ArrowAngel);


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
