using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public abstract class Enemy : MonoBehaviour
{

    public Rigidbody2D MyRigidbody;
    public int damage = 1;
    public float MoveSpeed = 2;
    public float MyMovementSpeeed;
    public Transform Player;
    public GameObject Loot;
    public UIScript Logic;
    public float health = 10f;


  

    void Update(){
        MyRigidbody.velocity = (Player.position - transform.position).normalized * MyMovementSpeeed;

    }


    public void OnTriggerEnter2D(Collider2D  collison){
        if (collison.tag == "Player"){
            Logic.PlayerHit(damage);
            Destroy(this.gameObject);
       }
    }

    
    
    public void TakeDamage(float damageToTake)
    {
        health -= damageToTake;

        if (health <= 0)
        {
            Death();
        }
    }
    
    void Death(){
        Instantiate(Loot,new Vector3(transform.position.x,transform.position.y ,0),Quaternion.identity);
         Destroy(this.gameObject);
    }
    
}
