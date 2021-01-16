using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D myRigidBody;
    private Animator myAnimator;
    private SpriteRenderer mySpriteRenderer;

    [Header("Controls")]
    public KeyCode upKey;
    public KeyCode downKey;
    public KeyCode leftKey;
    public KeyCode rightKey;

    private Vector2 velocityVector;
    public float movementVelocity = 1f;

 
    // Start is called before the first frame update
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        mySpriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(upKey))
        {
            velocityVector.y = movementVelocity;
            if (myRigidBody.velocity.y <= 0) myAnimator.SetTrigger("up");
            myAnimator.SetBool("idle", false);
        }

        else if (Input.GetKey(downKey))
        {
            velocityVector.y = -movementVelocity;
            if (myRigidBody.velocity.y >= 0)  myAnimator.SetTrigger("down");
            myAnimator.SetBool("idle", false);
        }

        else
        {
            velocityVector.y = 0f;
        }

        if (Input.GetKey(leftKey))
        {
            velocityVector.x = -movementVelocity;
            if (myRigidBody.velocity.x >= 0) myAnimator.SetTrigger("left");
            myAnimator.SetBool("idle", false);
            mySpriteRenderer.flipX = true;
           
        }

        else if (Input.GetKey(rightKey))
        {
            velocityVector.x = movementVelocity;
            if (myRigidBody.velocity.x <= 0) myAnimator.SetTrigger("right");
            myAnimator.SetBool("idle", false);
            mySpriteRenderer.flipX = false;
        }

        else velocityVector.x = 0f;

        if (velocityVector.x == 0f && velocityVector.y == 0f)
        {
            myAnimator.SetBool("idle", true);
            myAnimator.ResetTrigger("right");
            myAnimator.ResetTrigger("left");
            myAnimator.ResetTrigger("up");
            myAnimator.ResetTrigger("down");

        }
        myRigidBody.velocity = velocityVector;
    }
    
}
