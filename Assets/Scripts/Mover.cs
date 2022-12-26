using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Mover : Fighter
{
    // characteristics of player vars
    public float speed;
    public float jumpForce;
    public float jumpTime;
    private Rigidbody2D rb;

    //Controller and helper vars
    private bool isGrounded;
    public Transform feetPos;
    public float checkRadius;
    public LayerMask whatIsGround;//Layer of jumpable ground
    private float jumpTimeCounter;
    private bool isJumping = false;
    private bool notBonk;//true when not bonking
    public Transform headPos;
    public float checkBonkRadius;

    public Animator anim;




    protected override void Start()
    {
        base.Start();
        rb = GetComponent<Rigidbody2D>();
    }

    protected override void Update()
    {
        base.Update();
    }
    protected virtual void UpdateMotor(Vector3 input)
    {
        rb.velocity = new Vector2(input.x * speed, rb.velocity.y);

        if(!anim.GetCurrentAnimatorStateInfo(0).IsName("weapon_swing")){
            if (input.x == 1){//trocar por animações
                transform.GetChild(0).eulerAngles = new Vector3(0, 0, 0);
            }else if (input.x == -1){
                transform.GetChild(0).eulerAngles = new Vector3(0, 180, 0);
            }
            if (input.z == 2){
                transform.GetChild(0).eulerAngles = new Vector3(0, 0, 90);
            }else if (input.z == -2){
                transform.GetChild(0).eulerAngles = new Vector3(0, 0, 0);
            }else if (input.z == 0 && transform.GetChild(0).eulerAngles == new Vector3(0, 0, 90)){
                transform.GetChild(0).eulerAngles = new Vector3(0, 0, 0);
            }
        }
        //jump
        isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGround);//Check if a ground is in the radius of feet
        notBonk = !Physics2D.OverlapCircle(headPos.position, checkBonkRadius, whatIsGround);//Check if not bonked

        if (input.y == 2 && isJumping){
            if (jumpTimeCounter > 0 && notBonk){
                rb.velocity = Vector2.up * jumpForce;
                jumpTimeCounter -= Time.deltaTime;
            }else{
                isJumping = false;
            }
        }else if (isGrounded && input.y == 1) {
            isJumping = true;
            jumpTimeCounter = jumpTime;
            rb.velocity = Vector2.up * jumpForce;
        }
        if (input.y == 0){ 
            isJumping = false;
        }

        //go down
        if (input.y == -1){
            transform.GetChild(0).eulerAngles = new Vector3(0, 0, -90);
            if(!isGrounded){          
            rb.velocity = Vector2.down * jumpForce;         
            }
        }
    }
}