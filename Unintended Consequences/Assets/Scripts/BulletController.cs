using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
public class BulletController : NetworkBehaviour
{
    public float speed = 10f;
    private Rigidbody2D myRb;
    // Start is called before the first frame update
    void Start()
    {
        myRb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        myRb.velocity = transform.right * speed;
    }
}
