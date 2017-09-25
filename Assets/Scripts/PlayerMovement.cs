using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    [SerializeField]
    float movementSpeed = 1;

    [SerializeField]
    float jumpStrength = 5;
    
    private bool isOnGround;

    [SerializeField]
    Transform groundDetectCenterPoint;

    [SerializeField]
    float groundDetectRadius = 0.2f;

    [SerializeField]
    LayerMask whatCountsAsGround;

    Rigidbody2D myRigidbody;
	
    // Use this for initialization
	void Start ()
    {
        //This code teleports the game object to a new location
        //transform.position = new Vector3(0,0,0);	

        myRigidbody = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	private void Update ()
    {
        UpdateIsOnGround();
        Move();
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
        if (Input.GetButtonDown("Jump") && isOnGround)
        {
            myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, jumpStrength);
            isOnGround = false;

        }
    }

    private void Move()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
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