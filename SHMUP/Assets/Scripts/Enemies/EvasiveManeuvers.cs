using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvasiveManeuvers : MonoBehaviour
{
    public float speed;
    private Rigidbody rb;

    //Howlong before it can dodge again.
    public float dodgeDelay;
    //How long a dodge lasts.
    public float dodgeDuration;
    //Which direction to dodge in.
    //Zero = Left. One = Right.
    public int dodgeDirection;

    public float xMin;
    public float xMax;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        //Moves object forward at set speed.

        rb.velocity = transform.forward * speed;
        StartCoroutine(Evade());
    }

    private void FixedUpdate()
    {
        //Goes Left
        if (transform.position.x >= xMax)
        {
            rb.velocity = new Vector3(-speed, 0, -speed);
        }

        //Goes Right
        else if (transform.position.x <= xMin)
        {
            rb.velocity = new Vector3(speed, 0, -speed);
        }


    }

    IEnumerator Evade()
    {
        while(true)
        {            
            yield return new WaitForSeconds(Random.Range(0.5f, dodgeDelay));
            dodgeDirection = Random.Range(0, 2);

            //Goes Left
            if (dodgeDirection == 0)
            {
                rb.velocity = new Vector3(-speed, 0, -speed);
            }
            //Goes Right
            else if (dodgeDirection == 1)
            {
                rb.velocity = new Vector3(speed, 0, -speed);
            }

            yield return new WaitForSeconds(Random.Range(0.5f, dodgeDuration));

            rb.velocity = transform.forward * speed;
        }
    }
}
