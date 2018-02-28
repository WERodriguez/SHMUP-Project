using System.Collections;
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

    // Use this for initialization
    void Start ()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        StartCoroutine (slowFall());
	}

    IEnumerator slowFall()
    {
        rb.velocity = new Vector3(driftSpeedX, fallSpeed, driftSpeedZ);
        yield return new WaitForSeconds(deathDuration);
        Destroy(gameObject);
    }
}
