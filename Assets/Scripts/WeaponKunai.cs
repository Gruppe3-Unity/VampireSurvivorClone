using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WeaponKunai : Weapon
{
    [SerializeField]
    private GameObject kunaiPrefab; // Drag and drop the kunai prefab here in the Inspector

    [SerializeField]
    private float kunaiSpeed = 20f;
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
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            ShootKunai();
        }
    }

    private void ShootKunai()
    {


        // Instantiate the kunai at the character's position and rotation
        GameObject kunaiInstance = Instantiate(kunaiPrefab, transform.position, transform.rotation);

        // Get the Rigidbody2D component from the kunai instance
        Rigidbody2D kunaiRigidbody = kunaiInstance.GetComponent<Rigidbody2D>();

        // Calculate the direction the kunai should move
        Vector2 kunaiDirection;

        if (Playerbody.velocity.normalized == Vector2.zero)
        {
            kunaiDirection = Player.GetComponent<Player>().Lastmove.normalized * kunaiSpeed;
        }
        else
        {
            kunaiDirection = Playerbody.velocity.normalized * kunaiSpeed;
        }

        // Apply a force to the kunai to move it in the calculated direction
        kunaiRigidbody.AddForce(kunaiDirection, ForceMode2D.Impulse);

        float KunaiAngel = Vector2.SignedAngle(Vector2.right, kunaiDirection.normalized);

        kunaiInstance.transform.Rotate(0, 0, KunaiAngel);


        // Destroy the kunai after 2 seconds
        Destroy(kunaiInstance, 2f);
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
