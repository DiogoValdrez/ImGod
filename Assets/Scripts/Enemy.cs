using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Mover
{
    private bool isLeft;
    private bool isRight;
    public Transform leftPos;
    public Transform rightPos;
    private float checkRadiusSide = 0.1f;
    private float knockbackStartTime;
    public float knockbackDuration = 2f;
    public int hp = 2;
    
    [SerializeField]
    private int dir = 1;

    protected override void Update()
    {
        base.Update();
        float x = 0;
        float y = 0;
        float w = 0;
        if(Time.time > knockbackStartTime + knockbackDuration){
            isLeft = Physics2D.OverlapCircle(leftPos.position, checkRadiusSide, whatIsGround);
            isRight = Physics2D.OverlapCircle(rightPos.position, checkRadiusSide, whatIsGround);
            if(isLeft){
                dir=1;
            }else if(isRight){
                dir=-1;
            }
            x = dir;
            UpdateMotor(new Vector3(x,y,w));
        }

        
    }

    protected override void ReceiveDamage(Damage dmg){
        transform.GetComponent<Rigidbody2D>().velocity =  new Vector2(dmg.pushDirection * dmg.pushForce * speed, transform.GetComponent<Rigidbody2D>().velocity.y);
        knockbackStartTime = Time.time;
        hp = hp - dmg.damageAmount;
        if(hp<=0){
            Death();
        }
    }
    
    protected override void Death()
    {
        Destroy(gameObject);
    }
}