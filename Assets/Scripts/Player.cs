using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Mover
{
    //Frame rate
    public int testFrameRate = 60;//use this to test limited framerate(-1 for max)

    private float knockbackStartTime2 = -1f;
    public float knockbackDuration2 = 0.2f;

    private void Awake(){
        QualitySettings.vSyncCount = 0;  // VSync must be disabled
        Application.targetFrameRate = testFrameRate;
    }

    protected override void Update()
    {
        base.Update();
        float x = 0;
        float y = 0;
        // float z = 0;
        float w = 0;
        //por no game manager para n usar weapon. ....
        if(Time.time > Weapon.knockbackStartTime + Weapon.knockbackDuration && 
        Time.time > knockbackStartTime2 + knockbackDuration2){
            x=0;
            y=0;
            
            if(Input.GetKey(KeyCode.A)){
                x = -1;
            }
            if(Input.GetKey(KeyCode.D)){
                x = 1;
            }            
            if(Input.GetKeyDown(KeyCode.Space)){
                y = 1;
            }else if(Input.GetKey(KeyCode.Space)){
                y = 2;
            }
            if(!Input.GetKey(KeyCode.Space)){
                y = 0;
            }
            if(Input.GetKey(KeyCode.W)){
                w = 2;//fix this by using a bigger vector
            }
            if(Input.GetKeyUp(KeyCode.W)){
                w = -2;//fix this by using a bigger vector
            }
            if(!Input.GetKey(KeyCode.W)){
                w=0;
            }
            if(Input.GetKey(KeyCode.S)){
                y = -1;
            }
            UpdateMotor(new Vector3(x, y, w));
        }
    }

    protected override void ReceiveDamage(Damage dmg){
        transform.GetComponent<Rigidbody2D>().velocity =  new Vector2(-1 * dmg.pushDirection * dmg.pushForce * speed, transform.GetComponent<Rigidbody2D>().velocity.y);
        knockbackStartTime2 = Time.time;
        if(dmg.damageAmount>=2){
            Death();
        } 
    }
}