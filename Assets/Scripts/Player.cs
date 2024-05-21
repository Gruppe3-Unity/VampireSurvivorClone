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

    public Animator MyAnimator;

    void Start (){
        MyRigidBody = GetComponent<Rigidbody2D>();

    }

    void Update(){
        SpeedX = Input.GetAxisRaw("Horizontal") * MoveSpeed;
        
        SpeedY = Input.GetAxisRaw("Vertical") * MoveSpeed;
       
        MyRigidBody.velocity = new Vector2(SpeedX,SpeedY);
        MyAnimator.SetFloat("SpeedX",MyRigidBody.velocity.x);
        MyAnimator.SetFloat("SpeedY",MyRigidBody.velocity.y);
        if(MyRigidBody.velocity.x == 0 && MyRigidBody.velocity.y == 0 ){
            MyAnimator.SetFloat("IdleOffset",1);
        }
        else MyAnimator.SetFloat("IdleOffset",0);
    }
  
}
