using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Experience : MonoBehaviour
{
    public UIScript Logic;

    public int ExpValue = 1;

    public float MagnetForce = 10;

    void Start(){
        Logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<UIScript>();
       
    }
     void OnTriggerStay2D(Collider2D collision){
        
        if (collision.gameObject.tag == "Magnet"){
           
            float step = MagnetForce * Time.deltaTime;
            this.gameObject.transform.position = Vector2.MoveTowards(transform.position , collision.gameObject.transform.parent.position ,step);

        }
     }

     void OnTriggerEnter2D(Collider2D  collison){
        if (collison.tag == "Player"){
            Logic.GiveExp(ExpValue);
           Destroy(this.gameObject);
        
       }
    }
}
