using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;


public class WeaponAxe : Weapon
{
    [SerializeField]
    private GameObject axePrefab; // Drag and drop the axe prefab here in the Inspector

    [SerializeField]
    private float axeSpeed = 20f;
    
    public float spread = 0.5f;

    public int NumberOfAxes = 3;

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

    public void ThrowAxe()
    {
        
        for (int i = 0; i < NumberOfAxes;i++){

        // Instantiate the axe at the character's position and rotation
        GameObject axeInstance = Instantiate(axePrefab, transform.position, transform.rotation);

        // Get the Rigidbody2D component from the axe instance
        Rigidbody2D axeRigidbody = axeInstance.GetComponent<Rigidbody2D>();

        // Calculate the direction the axe should move
        Vector2 axeDirection;

        if (Playerbody.velocity.normalized == Vector2.zero)
        {
            axeDirection = Player.GetComponent<Player>().Lastmove.normalized * axeSpeed;
        }
        else
        {
            axeDirection = Playerbody.velocity.normalized * axeSpeed;
        }
        axeDirection.x = axeDirection.x + (i-1)*spread;

        axeDirection.y = axeDirection.y + (i-1)*spread;
        

        // Apply a force to the axe to move it in the calculated direction
        axeRigidbody.AddForce(axeDirection, ForceMode2D.Impulse);

        float AxeAngel = Vector2.SignedAngle(Vector2.right, axeDirection.normalized);

        axeInstance.transform.Rotate(0, 0, AxeAngel);

    
        // Destroy the axe after 2 seconds
        Destroy(axeInstance, 0.5f);
        
    }

    }

    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        // Check if the axe hit an enemy
        Enemy enemy = hitInfo.GetComponent<Enemy>();
        if (enemy != null)
        {
            
            Destroy(hitInfo.gameObject);
        }
    }
}
