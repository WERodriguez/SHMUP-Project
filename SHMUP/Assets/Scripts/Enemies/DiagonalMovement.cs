using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiagonalMovement : MonoBehaviour
{

    public float speed;
    private Rigidbody rb;

    public float leftPosition;
    public float rightPosition;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        //Moves object forward at set speed.
        //rb.velocity = transform.forward * speed;

        if (transform.position.x > 0)
        {
            rb.velocity = new Vector3(-speed, 0, -speed);
        }
        else if (transform.position.x < 0)
        {
            rb.velocity = new Vector3(speed, 0, -speed);
        }
        else
        {
            rb.velocity = transform.forward * speed;
        }
    }

    private void FixedUpdate()
    {
        //float rbPositionX = rb.position.x;

        if (transform.position.x >= rightPosition)
        {
            rb.velocity = new Vector3(-speed, 0, -speed);
        }
        else if (transform.position.x <= leftPosition)
        {
            rb.velocity = new Vector3(speed, 0, -speed);
        }
    }
}
