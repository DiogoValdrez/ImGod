using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Collidable : MonoBehaviour
{
    // public ContactFilter2D filter;
    // private BoxCollider2D boxCollider;
    // private Collider2D[] hits = new Collider2D[10];
    
    protected virtual void Start()
    {
        // boxCollider = GetComponent<BoxCollider2D>();
    }

    protected virtual void Update()
    {
    //     // Collision handling
    //     boxCollider.OverlapCollider(filter, hits);
    //     for(int i = 0; i < hits.Length; i++)
    //     {
    //         if(hits[i] == null)
    //         {
    //             continue;
    //         }

    //         OnColide(hits[i]);

    //         // clean up array
    //         hits[i] = null;
    //     }
    }

    // protected virtual void OnColide(Collider2D coll)
    // {
    //     Debug.Log("OnCollide was not implemented in "+ this.name);
    // }

    protected virtual void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("OnCollide was not implemented in "+ this.name);
        
    }
    
    
    protected virtual void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("OnTrigger was not implemented in "+ this.name);
    }
    //use Physics.IgnoreLayerCollision to ignore collisions between layers
}