using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperCarrierMain : MonoBehaviour
{
    private Rigidbody rb;
    public float speed;
    //Where the boss is gonna stop moving.
    public float bossPosition;

    public Transform hangarSpawn;

    public GameObject[] enemyships;

    //Hangar spawn variables.
    public float startWait;
    private int shipSpawns;

	// Use this for initialization
	void Start ()
    {
        gameObject.name = "SuperCarrierBoss";
        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.forward * speed;

        StartCoroutine(spawnShips());
    }

    // Update is called once per frame
    void FixedUpdate ()
    {
        if (transform.position.z <= bossPosition)
        {
            rb.velocity = transform.forward * 0;
        }

    }


    IEnumerator spawnShips()
    {
        while(true)
        {
            yield return new WaitForSeconds(startWait);

            shipSpawns = 5;
            for (int i = 0; i < shipSpawns; i++)
            {
                Instantiate(enemyships[0], hangarSpawn.position, hangarSpawn.rotation);
                yield return new WaitForSeconds(0.25f);
            }

            yield return new WaitForSeconds(5.0f);
            Instantiate(enemyships[1], hangarSpawn.position, hangarSpawn.rotation);

            yield return new WaitForSeconds(10.0f);
            Instantiate(enemyships[2], hangarSpawn.position, hangarSpawn.rotation);

            yield return new WaitForSeconds(10.0f);
            Instantiate(enemyships[3], hangarSpawn.position, hangarSpawn.rotation);

            yield return new WaitForSeconds(30.0f);
        }
    }
}
