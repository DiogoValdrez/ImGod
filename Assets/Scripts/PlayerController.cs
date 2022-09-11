using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    private Rigidbody2D rb;
    private float moveInput; //-1 left, 1 right

    private bool isGrounded;
    public Transform feetPos;
    public float checkRadius;
    public LayerMask whatIsGround;//Layer of jumpable ground

    private float jumpTimeCounter;
    public float jumpTime;
    private bool isJumping;

    private bool notBonk;//true when not bonking
    public Transform headPos;
    public float checkBonkRadius;


    public int testFrameRate = -1;//use this to test limited framerate
    private void Awake()
    {
        Application.targetFrameRate = testFrameRate;
    }


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        moveInput = Input.GetAxisRaw("Horizontal");//change key bindings in Project Settings->InputManager,  take out raw to have less "snappy"movement
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
    }

    private void Update()
    {// you should make sure to multiply your movements by time.deltaTime, or you should put the physics in the FixedUpdate

        isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGround);//Check if a ground is in the radius of feet
        notBonk = !Physics2D.OverlapCircle(headPos.position, checkBonkRadius, whatIsGround);//Check if not bonked

        if (moveInput > 0)//trocar por animações
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }else if (moveInput < 0)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }

        if (isGrounded && Input.GetKeyDown(KeyCode.Space)) {//passar o keycode.space para uma variavel para se pudermudar á vontade
            isJumping = true;
            jumpTimeCounter = jumpTime;
            rb.velocity = Vector2.up * jumpForce;
        }
        if (Input.GetKey(KeyCode.Space) && isJumping)
        {
            if (jumpTimeCounter > 0 && notBonk)
            {
                rb.velocity = Vector2.up * jumpForce;
                jumpTimeCounter -= Time.deltaTime;
            }
            else
            {
                isJumping = false;
            }
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            isJumping = false;
        }
    }
}
