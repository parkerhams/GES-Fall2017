using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    [SerializeField]
    float movementSpeed = 1;

    [SerializeField]
    float jumpStrength = 5;
       
    [SerializeField]
    Transform groundDetectCenterPoint;

    [SerializeField]
    float groundDetectRadius = 0.2f;

    [SerializeField]
    LayerMask whatCountsAsGround;

    private float horizontalInput;
    private bool isOnGround;
    private bool shouldJump;
    private Vector2 jumpForce;
    Rigidbody2D myRigidbody;
	
    // Use this for initialization
	void Start ()
    {
        //This code teleports the game object to a new location
        //transform.position = new Vector3(0,0,0);	

        myRigidbody = GetComponent<Rigidbody2D>();
        jumpForce = new Vector2(0, jumpStrength);
    }
	
	// Update is called once per frame
	private void Update ()
    {
        //When you use the physics engine, you don't normally want to use physics based functions in update. If you start calling a bunch of them, it begins to get expensive.
        //Use FixedUpdate for any physics things.
        GetMovementInput();
        GetJumpInput();
        UpdateIsOnGround();
        
        //Physics2D.gravity = new Vector2(0, 20);
        //Set up a variable so you're not creating a new Vector2 each time.

        //Keeping velocity in the x direction when roatating gravity -- keep the x-velocity constant when you multiply the Vector2 y value by a negative value????
    }

    private void GetJumpInput()
    {
        if (Input.GetButtonDown("Jump") && isOnGround)
        {
            shouldJump = true;
        }
    }

    private void GetMovementInput()
    {
        horizontalInput = Input.GetAxis("Horizontal");
    }

    private void FixedUpdate()
    {
        //Called once every fixed increment of time; framerate independent. Can also adjust - but not recommended.
        Move();
        //There is a catch: because it is being called every 5 frames for example, it's not being called as often.
        Jump();


    }

    private void UpdateIsOnGround()
    {
        //Draws circle, returns Collider2DArray[] if it fits layerMask of Ground
        //We must save that array to do anything with it--
        Collider2D[] groundObjects = 
        Physics2D.OverlapCircleAll(groundDetectCenterPoint.position, groundDetectRadius, whatCountsAsGround);
        //This will be true if there's anything inside of it, it will be false if nothing is in it
        isOnGround = groundObjects.Length > 0;
    }

    //Must be written this exact way for Unity's 2D engine to call automatically
    private void OnCollisionEnter2D(Collision2D collision)
    {
        isOnGround = true;
    }

    private void Jump()
    {
        if (shouldJump)
        {
            //Learn about addforce!!!!
            //myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, jumpStrength);
            myRigidbody.AddForce(jumpForce, ForceMode2D.Impulse);
            isOnGround = false;
            shouldJump = false;
        }
    }

    private void Move()
    {
        //Whenever you're doing any sort of moving in update. use Time.deltaTime.
        //It represents the amount of time its been since the last time we've call update. We are always moving the player the same amount using this.
        
        //Rigidbody means using physics. So... fixedUpdate. It also isn't need in fixedupdate
        //Two choices: put it in FixedUpdate or multiply by Time.deltaTime.
        myRigidbody.velocity = new Vector2(horizontalInput * movementSpeed, myRigidbody.velocity.y);
    }
}

//Don't use Input.Getkey, use GetButton and GetAxis.

//if (Input.GetKey(KeyCode.D))
//{
//    transform.Translate(new Vector3(0.1f, 0, 0));
//}

//if (Input.GetKey(KeyCode.A))
//{
//    transform.Translate(new Vector3(-0.1f, 0, 0));
//}

//from Update(): transform.Translate(0.1f * horizontalInput, 0 , 0);