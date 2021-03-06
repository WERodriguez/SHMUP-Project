﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverlyDramaticDeath : MonoBehaviour
{
    //For Boss Death
    private Rigidbody rb;
    public float fallSpeed;
    public float driftSpeedX;
    public float driftSpeedZ;
    public float deathDuration;

    //Holds explosions
    public GameObject[] explosions;
    //What it says.
    public float timeBetweenExplosions;
    //Ranges that explosions can spawn at during overly dramatic switch. 
    //Used with Random.Range(minimum Float, max Float)
    public float xRange;
    public float yRange;
    public float zRange;

    //Checks if heavy scrap or not.
    public bool isHeavyScrap;

    // Use this for initialization
    void Start ()
    {
        if (isHeavyScrap)
        {
            driftSpeedX = Random.Range(-driftSpeedX, driftSpeedX);
        }

        rb = gameObject.GetComponent<Rigidbody>();
        StartCoroutine (slowFall());
        StartCoroutine(dramaticExplosions());
    }

    IEnumerator slowFall()
    {
        rb.velocity = new Vector3(driftSpeedX, fallSpeed, driftSpeedZ);
        yield return new WaitForSeconds(deathDuration);
        Destroy(gameObject);
    }

    IEnumerator dramaticExplosions()
    {

        while (true)
        {
            //Instantiates explosions from an array that holds 3 explosions.
            //X and Z coordinates of explosions are random. Y and rotation are static.
            Instantiate(explosions[Random.Range(0, 3)], new Vector3(gameObject.transform.position.x + Random.Range(-xRange, xRange),
                gameObject.transform.position.y + Random.Range(-yRange, yRange),
                gameObject.transform.position.z + Random.Range(-zRange, zRange)), gameObject.transform.rotation);

            yield return new WaitForSeconds(timeBetweenExplosions);
        }
    }
}
