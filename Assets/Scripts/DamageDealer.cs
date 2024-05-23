using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : UIScript
{
    public int damageAmount;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            collision.GetComponent<basicEnemy>().TakeDamage(damageAmount);
        }
    }
}
