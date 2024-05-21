using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    public GameObject Enemy;
    public float SpawnTimer = 2;
    public float timer = 0;

    public int NumberOfEnemy;

    public Transform Player;

    public float Radius;
    
   

    void Start (){
        Player = FindObjectOfType<Player>().transform;
    }

    void Update(){
        transform.position = Player.position;

        if (timer < SpawnTimer){
            timer += Time.deltaTime;

        }
        else{
            for (int i = 0; i < NumberOfEnemy; i ++){
            Instantiate(Enemy,SpawnPoint(),Quaternion.identity);
            }
            timer = 0;
        }

    }

    public Vector3 SpawnPoint(){
         float Angel = UnityEngine.Random.value * 360;
         Vector3 Posison;
         Posison.x = transform.position.x + Radius * Mathf.Sin(Angel * Mathf.Deg2Rad);
         Posison.y = transform.position.y + Radius * Mathf.Cos(Angel * Mathf.Deg2Rad);
         Posison.z = transform.position.z;
     return Posison;
        
    }


}
