using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrongEnamy : Enemy
{
    // Start is called before the first frame update
    void Start()
    {
        
        MyRigidbody = GetComponent<Rigidbody2D>();
        Player = FindObjectOfType<Player>().transform;
        
        MyMovementSpeeed = MoveSpeed * Random.Range(0.95f,1.05f);
        Logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<UIScript>();
    }

    // Update is called once per frame
}
