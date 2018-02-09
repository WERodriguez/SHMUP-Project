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
    private int baseWLevel = 0;
    //Weapon current level
    public int currentWLevel = 0;
    //Currently equipped primary weapon.
    //MG = 1. ScatterShot = 2. Flak = 3. Canon = 4.
    //I was having a hard time with the string array and this just works. >.>
    public int primaryWeapon = 1;

    //Shot to fire
    public GameObject mgShot;
    public GameObject scatterShot;
    public GameObject flakShot;
    public GameObject canonShot;
    //Where the ship shoots from. Can be a list of them.
    public Transform[] shotSpawns;

    // Use this for initialization
    public void Fire()
    {
        if(primaryWeapon == 1)
        {
            //Spawns 1 Bullet from HP 1
            if (currentWLevel == 0 && Time.time > nextFire)
            {
                nextFire = Time.time + fireRate;
                Instantiate(mgShot, shotSpawns[0].position, shotSpawns[0].rotation);
            }
            //Spawns 1 Bullet from all HP
            else if (currentWLevel == 1 && Time.time > nextFire)
            {
                nextFire = Time.time + fireRate;
                foreach (var shotSpawn in shotSpawns)
                {
                    Instantiate(mgShot, shotSpawn.position, shotSpawn.rotation);
                }
            }
        }
           
    }
}
