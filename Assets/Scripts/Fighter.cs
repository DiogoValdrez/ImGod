using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Fighter : MonoBehaviour
{
    protected virtual void Start()
    {
    }

    protected virtual void Update()
    {
    }

    protected virtual void ReceiveDamage(Damage dmg)
    {
        Debug.Log("Receive damage not implemented in" + this.name);      
    }

    protected virtual void Death()
    {
        Debug.Log("Death not implemented in" + this.name);      
    }
}