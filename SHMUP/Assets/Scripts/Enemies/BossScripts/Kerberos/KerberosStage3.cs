using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KerberosStage3 : MonoBehaviour
{
    private Rigidbody rb;

    //Speed at which boss lerps between objects.
    public float speed;

    //How long the boss takes before the boss starts moving.
    public float startDelay;

    //Contains all child object renderers for manipulation.
    public Component[] childRenderers;

    //Lets the ship know it can move
    public bool canIMove;
    public float appearDuration;

    public GameObject[] shotSpawns;

    public float xMin;
    public float xMax;

    public int dodgeDirection;
    public float dodgeDuration;
    public float dodgeDelay;

    //How many shots in a burst.
    public int burstSize;
    //How fast the gun shoots.
    public float fireRate;
    //Next time guns can fire.
    public float nextFire;
    //How often the turret is called to fire.
    public float nextVolley;
    //Enemy shot.
    public GameObject torpedoes;
    public GameObject beamShot;
    public GameObject childWeapon1;
    public GameObject childWeapon2;




    void Start()
    {
        rb = GetComponent<Rigidbody>();
        StartCoroutine(deploy());
        //Invoke("Evade", appearDuration);
        //InvokeRepeating("fireGuns", startDelay, nextVolley);
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        //Goes Left
        if (transform.position.x >= xMax && canIMove)
        {
            rb.velocity = new Vector3(-speed, 0, 0);
        }

        //Goes Right
        else if (transform.position.x <= xMin && canIMove)
        {
            rb.velocity = new Vector3(speed, 0, 0);
        }
    }

    IEnumerator Evade()
    {
        canIMove = true;
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

    IEnumerator deploy()
    {
        yield return new WaitForSeconds(startDelay);
        StartCoroutine(Evade());
        StartCoroutine(fireGuns());
    }


    IEnumerator fireGuns()
    {
        while(true)
        {
            int beamSpawn1 = Random.Range(0, 2);
            int beamSpawn2 = Random.Range(2, shotSpawns.Length);
            int torpSpawn1;
            int torpSpawn2;

            if (beamSpawn1 == 0)
            {
                torpSpawn1 = 1;
            }
            else
            {
                torpSpawn1 = 0;
            }

            if (beamSpawn2 == 2)
            {
                torpSpawn2 = 3;
            }
            else
            {
                torpSpawn2 = 2;
            }

            //Fires the beam weapons.
            childWeapon1 = Instantiate(beamShot, shotSpawns[beamSpawn1].transform.position, gameObject.transform.rotation) as GameObject;
            childWeapon1.transform.parent = gameObject.transform;
            childWeapon2 = Instantiate(beamShot, shotSpawns[beamSpawn2].transform.position, gameObject.transform.rotation) as GameObject;
            childWeapon2.transform.parent = gameObject.transform;

            for (int i = 0; i < burstSize; i++)
            {

                Instantiate(torpedoes, shotSpawns[torpSpawn1].transform.position, shotSpawns[torpSpawn1].transform.rotation);
                Instantiate(torpedoes, shotSpawns[torpSpawn2].transform.position, shotSpawns[torpSpawn2].transform.rotation);
                yield return new WaitForSeconds(nextFire);
            }

            yield return new WaitForSeconds(nextVolley);
        }
    }
}
