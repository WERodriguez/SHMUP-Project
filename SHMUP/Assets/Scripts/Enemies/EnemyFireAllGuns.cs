using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFireAllGuns : MonoBehaviour
{
    public float nextFire;
    public float fireDelay;
    public float fireRate;

    public GameObject shot;
    public Transform[] shotSpawns;

	// Use this for initialization
	void Start ()
    {
        nextFire = Time.time + fireDelay;
	}
	
	// Update is called once per frame
	void Update ()
    {
		if (Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            foreach (var shotSpawn in shotSpawns)
            {
                Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
            }
        }
    }
}
