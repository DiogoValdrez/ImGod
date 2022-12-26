using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : Collidable
{
    public Animator anim;
    public Transform parent;
    public GameObject test;

    //por no manager
    // Declare a variable to store the duration of the knockback effect    
    public static float knockbackDuration = 0.2f;
    // Declare a variable to store the time at which the knockback began
    public static float knockbackStartTime = -1f;


    protected override void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            int pd=0;
            Vector3 right = new Vector3(0, 0, 0);
            Vector3 left = new Vector3(0, 180, 0);
            Vector3 up = new Vector3(0, 0, 90);
            Vector3 down = new Vector3(0, 0, 270);
            if(parent.GetChild(0).eulerAngles == right){          
                parent.GetComponent<Rigidbody2D>().velocity = Vector2.left * 10;
                knockbackStartTime = Time.time;
                pd= 1;
            }else if(parent.GetChild(0).eulerAngles == left){
                parent.GetComponent<Rigidbody2D>().velocity = Vector2.right * 10;
                knockbackStartTime = Time.time;
                pd= -1;
            }else if(parent.GetChild(0).eulerAngles == up){
                parent.GetComponent<Rigidbody2D>().velocity = Vector2.down * 10;
                knockbackStartTime = Time.time;
            }else if(parent.GetChild(0).eulerAngles == down){
                parent.GetComponent<Rigidbody2D>().velocity = Vector2.up * 15;
                knockbackStartTime = Time.time;
            }else{
                Debug.Log(parent.GetChild(0).eulerAngles);
            }

            Damage dmg = new Damage
            {
                damageAmount = 1,
                origin = transform.position,
                pushForce = 2,
                pushDirection = pd
            };
            other.SendMessage("ReceiveDamage", dmg);  

        }
    }
    protected override void Update()
    {
        base.Update();
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Swing();
        }
    }
    protected void Swing()
    {
        if(!anim.GetCurrentAnimatorStateInfo(0).IsName("weapon_swing")){
            anim.SetTrigger("Swing");
        }       
    }
}