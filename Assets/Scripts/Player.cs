using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class Player : MonoBehaviour
{
    public float MoveSpeed;
    float SpeedX, SpeedY;
    Rigidbody2D MyRigidBody;

    void Start (){
        MyRigidBody = GetComponent<Rigidbody2D>();

    }

    void Update(){
        SpeedX = Input.GetAxisRaw("Horizontal") * MoveSpeed;
        SpeedY = Input.GetAxisRaw("Vertical") * MoveSpeed;
        MyRigidBody.velocity = new Vector2(SpeedX,SpeedY);
    }
  
}
