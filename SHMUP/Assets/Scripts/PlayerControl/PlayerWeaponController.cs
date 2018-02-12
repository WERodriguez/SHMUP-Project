using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponController : MonoBehaviour
{

    //Fire control variables.
    //fireRate controls the... Well Fire Rate
    public float fireRate;
    //Keeps track of when the weapon can fire again.
    private float nextFire;

    //Weapon default level at start of scene.
    public int baseWLevel = 0;
    //Weapon current level
    public int currentWLevel = 0;
    //Currently equipped primary weapon.
    //MG = 1. ScatterShot = 2. Flak = 3. Canon = 4.
    //I was having a hard time with the string array and this just works. >.>
    public int primaryWeaponSelector = 1;

    //Shot to fire
    public GameObject mgShot;
    public GameObject scatterShot;
    public GameObject flakShot;
    public GameObject canonShot;
    //Where the ship shoots from. Can be a list of them.
    public Transform[] shotSpawns;

    //False = Player 1. True = Player 2
    private bool whichPlayer;
    private GameObject bullet;

    void Start()
    {
        //Pulls which player it is from the parent object.
        whichPlayer = GetComponent<PlayerController>().whichPlayer;
    }

    // Use this for initialization
    public void Fire()
    {
        if (primaryWeaponSelector == 1)
        {
            MachineGun();
        }
           
    }

    private void MachineGun()
    {
        WhatPlayer();

        //Spawns 1 Bullet from primary hard point.
        if (currentWLevel == 0 && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(bullet, shotSpawns[0].position, shotSpawns[0].rotation);
        }
        //Spawns 1 Bullet from all hard points
        else if (currentWLevel == 1 && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            foreach (var shotSpawn in shotSpawns)
            {
                Instantiate(mgShot, shotSpawn.position, shotSpawn.rotation);
            }
        }
    }

    //Figures out what player it belongs to?
    private void WhatPlayer()
    {
        //Puts the bullet into a container to modify.
        bullet = mgShot as GameObject;
        //Takes said container and tells it to let the bullet know what player it belongs to.
        bullet.GetComponent<AttackScript>().whoDoIBelongTo = whichPlayer;
    }
}
