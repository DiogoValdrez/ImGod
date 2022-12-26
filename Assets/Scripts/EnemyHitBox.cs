using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyHitBox : Collidable
{
    public int damage = 1;
    public float pushForce = 1;

    protected override void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Player")
        {                  
            other.collider.SendMessage("ReceiveDamage", new Damage{
                damageAmount = damage,
                origin = transform.position,
                pushForce = pushForce,
                pushDirection = (transform.position.x - other.collider.transform.GetComponent<Rigidbody2D>().position.x)/System.Math.Abs(transform.position.x - other.collider.transform.GetComponent<Rigidbody2D>().position.x)
            });
        }
    }
    protected override void OnTriggerEnter2D(Collider2D other)
    {
    }
}