using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooterController : MonoBehaviour
{
    //Fire control variables.
    //fireRate controls the... Well Fire Rate
    public float fireRate;
    //Shot to fire
    public GameObject shot;
    //Where the ship shoots from. Can be a list of them.
    public Transform shotSpawn;

    //Keeps track of when the weapon can fire again.
    private float nextFire;

    //Runs every frame
    private void Update()
    {
        //Spawns 1 Bullet from HP 1
        if (Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
        }
    }
}
