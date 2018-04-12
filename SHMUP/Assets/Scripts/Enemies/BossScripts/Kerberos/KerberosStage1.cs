using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KerberosStage1 : MonoBehaviour
{
    private Rigidbody rb;
    public float speed;
    //Where the boss is gonna stop moving.
    public float bossPosition;
    //Checks if the boss is deployed.
    public bool bossDeployed;

    //Howlong before it can dodge again.
    public float dodgeDelay;
    //How long a dodge lasts.
    public float dodgeDuration;
    //Which direction to dodge in.
    //Zero = Left. One = Right.
    public int dodgeDirection;

    public float xMin;
    public float xMax;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.forward * speed;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Stops the boss forward movement.
        if (transform.position.z <= bossPosition && !bossDeployed)
        {
            rb.velocity = transform.forward * 0;
            bossDeployed = true;
            StartCoroutine(Evade());
        }

        //Goes Left
        if (transform.position.x >= xMax && bossDeployed)
        {
            rb.velocity = new Vector3(-speed, 0, 0);
        }

        //Goes Right
        else if (transform.position.x <= xMin && bossDeployed)
        {
            rb.velocity = new Vector3(speed, 0, 0);
        }
    }

    IEnumerator Evade()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(0.5f, dodgeDelay));
            dodgeDirection = Random.Range(0, 2);

            //Goes Left
            if (dodgeDirection == 0)
            {
                rb.velocity = new Vector3(-speed, 0, 0);
            }
            //Goes Right
            else if (dodgeDirection == 1)
            {
                rb.velocity = new Vector3(speed, 0, 0);
            }

            yield return new WaitForSeconds(Random.Range(0.5f, dodgeDuration));

            rb.velocity = new Vector3(0, 0, 0);
        }
    }
}
