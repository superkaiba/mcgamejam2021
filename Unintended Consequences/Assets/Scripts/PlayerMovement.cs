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


    private Camera theCam;

    public Transform firePoint;
    public GameObject bulletToFire;
    // Start is called before the first frame update
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        theCam = Camera.main;
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


        Vector3 mouse = Input.mousePosition;

        Vector3 screenPoint = Camera.main.WorldToScreenPoint(transform.localPosition);

        Vector2 offset = new Vector2(mouse.x - screenPoint.x, mouse.y - screenPoint.y);

        float angle = Mathf.Atan2(offset.y, offset.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0f, 0f, angle);

        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(bulletToFire, firePoint.position, transform.rotation);
        }
    }


    
}
