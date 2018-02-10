using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiagonalMover : MonoBehaviour {

    public float moveHorizontal;
    public float moveVertical;

    private Rigidbody rb;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        //True = Go Left. False = Go Right
        if (Random.Range(0.0f,1.0f) < 0.5f)
        {
            moveHorizontal *= -1;
        }

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, -moveVertical);
        rb.velocity = movement;
    }
}
