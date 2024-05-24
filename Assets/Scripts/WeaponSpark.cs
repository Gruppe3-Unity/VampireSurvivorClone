using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WeaponSpark : Weapon
{
    [SerializeField]
    private GameObject sparkPrefab; // Drag and drop the kunai prefab here in the Inspector

    [SerializeField]
    private float sparkSpeed = 20f;
    public GameObject Player;
    public Rigidbody2D Playerbody;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");

        Playerbody = Player.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {

    }

    public void ShootSpark()
    {


        // Instantiate the kunai at the character's position and rotation
        GameObject sparkInstance = Instantiate(sparkPrefab, transform.position, transform.rotation);

        // Get the Rigidbody2D component from the kunai instance
        Rigidbody2D sparkRigidbody = sparkInstance.GetComponent<Rigidbody2D>();

        // Calculate the direction the kunai should move
        Vector2 sparkDirection;

        if (Playerbody.velocity.normalized == Vector2.zero)
        {
            sparkDirection = Player.GetComponent<Player>().Lastmove.normalized * sparkSpeed;
        }
        else
        {
            sparkDirection = Playerbody.velocity.normalized * sparkSpeed;
        }

        // Apply a force to the kunai to move it in the calculated direction
        sparkRigidbody.AddForce(sparkDirection, ForceMode2D.Impulse);

        float SparkAngel = Vector2.SignedAngle(Vector2.up, sparkDirection.normalized);

        sparkInstance.transform.Rotate(0, 0, SparkAngel);


        // Destroy the kunai after 2 seconds
        Destroy(sparkInstance, 2f);
    }

    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        // Check if the kunai hit an enemy
        Enemy enemy = hitInfo.GetComponent<Enemy>();
        if (enemy != null)
        {

            Destroy(hitInfo.gameObject);
        }
    }
}

