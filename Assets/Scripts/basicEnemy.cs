using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class basicEnemy : Enemy
{

    Rigidbody2D MyRigidbody;
    public int damage = 1;
    public float MoveSpeed = 2;
    public float MyMovementSpeeed;
    public Transform Player;
    public GameObject Loot;
    public UIScript Logic;
    public float health = 10f;

    void Start(){

        MyRigidbody = GetComponent<Rigidbody2D>();
        Player = FindObjectOfType<Player>().transform;
        
        MyMovementSpeeed = MoveSpeed * Random.Range(0.95f,1.05f);
        Logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<UIScript>();
        
    }

    
    void Update(){
        MyRigidbody.velocity = (Player.position - transform.position).normalized * MyMovementSpeeed;

    }

    void Death(){
        Instantiate(Loot,new Vector3(transform.position.x,transform.position.y ,0),Quaternion.identity);
         Destroy(this.gameObject);
    }
    

    // just a place hollder collsion 
    public void OnTriggerEnter2D(Collider2D  collison){
        if (collison.tag == "Player"){
            Logic.PlayerHit(damage);
            Death();
        
       }
    }

    public void TakeDamage(float damageToTake)
    {
        health -= damageToTake;

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

}
