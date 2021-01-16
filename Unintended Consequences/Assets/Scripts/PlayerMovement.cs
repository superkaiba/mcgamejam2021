using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D myRigidBody;
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
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(upKey))
        {
            velocityVector.y = movementVelocity;
        }

        else if (Input.GetKey(downKey))
        {
            velocityVector.y = -movementVelocity;
        }

        else velocityVector.y = 0f;

        if (Input.GetKey(leftKey))
        {
            velocityVector.x = -movementVelocity;
        }

        else if (Input.GetKey(rightKey))
        {
            velocityVector.x = movementVelocity;
        }

        else velocityVector.x = 0f;

        myRigidBody.velocity = velocityVector;
    }
}
