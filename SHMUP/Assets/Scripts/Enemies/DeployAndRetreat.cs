using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeployAndRetreat : MonoBehaviour
{
    public float speed;
    private Rigidbody rb;

    public float deployPosition;
    public float retreatTime;

    public bool deployed;
    public bool retreatForward;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        //Moves object forward at set speed.
        rb.velocity = transform.forward * speed;
    }

    private void FixedUpdate()
    {
        if(transform.position.z <= deployPosition && !deployed)
        {
            rb.velocity = transform.forward * 0;
            StartCoroutine (Retreat());
        }
    }

    IEnumerator Retreat()
    {
        deployed = true;
        yield return new WaitForSeconds(retreatTime);
        if(retreatForward)
        {
            rb.velocity = transform.forward * speed;
        }
        else
        {
            rb.velocity = transform.forward * -speed;
        }        
    }

}
