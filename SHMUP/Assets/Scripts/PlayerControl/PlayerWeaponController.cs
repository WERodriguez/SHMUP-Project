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
    public int baseWLevel;
    //Weapon current level
    public int currentWLevel;
    //Currently equipped primary weapon.
    //MG = 0. ScatterShot = 1. Flak = 2. Canon = 3.
    //I was having a hard time with the string array and this just works. >.>
    public int primaryWeaponSelector;

    //Shot to fire
    /*public GameObject mgShot;
    public GameObject scatterShot;
    public GameObject flakShot;
    public GameObject canonShot;*/

    public GameObject[] currentWeapon;

    //Where the ship shoots from. Can be a list of them.
    public Transform[] shotSpawns;

    //For spread shots!
    private int numberOfShots; //Should probably be odd. Let's find out.
    private int shotCounter;
    private float spreadAngleIncrement;
    private float spreadAngleIncrementDefault;
    private float spreadAngleDefault;
    private float spreadSpawnIncrement;

    //False = Player 1. True = Player 2
    private bool whichPlayer;
    //Current weapon modified with the whichPlayer bool.
    private GameObject bullet;

    void Start()
    {
        //Pulls which player it is from the parent object.
        whichPlayer = GetComponent<PlayerController>().whichPlayer;
        currentWLevel = baseWLevel;
    }

    // Use this for initialization
    public void Fire()
    {
        if (primaryWeaponSelector == 0)
        {
            fireRate = 0.25f;
            MachineGun();
        }
        else if (primaryWeaponSelector == 2)
        {
            fireRate = 1.0f;
            FlakCannon();
        }
        else if (primaryWeaponSelector == 3)
        {
            fireRate = 1.0f;
            Cannon();
        }

    }

    private void MachineGun()
    {
        WhatPlayer();

        //Spawns 1 Bullet from primary hard point.
        if (currentWLevel == 1 && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(bullet, shotSpawns[0].position, shotSpawns[0].rotation);
        }
        //Spawns 1 Bullet from all hard points
        else if (currentWLevel == 2 && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            foreach (var shotSpawn in shotSpawns)
            {
                Instantiate(bullet, shotSpawn.position, shotSpawn.rotation);
            }
        }
        else if (currentWLevel == 3 && Time.time > nextFire)
        {
            //Tracks how many shots the loop has fired.
            shotCounter = 0;
            //Angle to spawn bullets at.
            spreadAngleDefault = 3;
            //Number of shots to be fired by the loop.
            numberOfShots = 2;
            nextFire = Time.time + fireRate;
            foreach (var shotSpawn in shotSpawns)
            {
                //While shots fired is less than total number of shots requested.
                while (shotCounter < numberOfShots)
                {
                    //Spawns bullets at shotSpawn but with a Y rotation of 3.
                    Instantiate(bullet, shotSpawn.position, Quaternion.Euler(0, spreadAngleDefault, 0));
                    shotCounter++;
                    //Flips that bullet around for the next shot.
                    spreadAngleDefault *= -1;
                }
                //Resets the shotCounter so it can spawn bullets at the rest of the spawners.
                if (shotCounter >= numberOfShots)
                {
                    shotCounter = 0;
                    spreadAngleDefault = 3;
                }
            }
        }
        else if (currentWLevel == 4 && Time.time > nextFire)
        {
            shotCounter = 0;
            numberOfShots = 3;
            //Angle to spawn bullets at.
            spreadAngleDefault = 3;
            //For those guns that need to shoot more side ways than the front gun.
            spreadAngleIncrementDefault = 9;
            nextFire = Time.time + fireRate;

            foreach (var shotSpawn in shotSpawns)
            {
                if (shotSpawn == shotSpawns[1])
                {
                    //Increments default angle.
                    spreadAngleIncrement = spreadAngleIncrementDefault;

                    while (shotCounter < numberOfShots)
                    {
                        spreadAngleIncrement += spreadAngleDefault;

                        Instantiate(bullet, shotSpawn.position, Quaternion.Euler(0, -spreadAngleIncrement, 0));
                        shotCounter++;
                    }
                }
                else if(shotSpawn == shotSpawns[2])
                {                    
                    //Increments default angle.
                    spreadAngleIncrement = spreadAngleIncrementDefault;

                    while (shotCounter < numberOfShots)
                    {
                        spreadAngleIncrement += spreadAngleDefault;

                        Instantiate(bullet, shotSpawn.position, Quaternion.Euler(0, +spreadAngleIncrement, 0));
                        shotCounter++;
                    }                    
                }
                else if (shotSpawn == shotSpawns[0])
                {
                    Instantiate(bullet, shotSpawn.position, shotSpawn.rotation);

                    while (shotCounter < numberOfShots-1)
                    {
                        Instantiate(bullet, shotSpawn.position, Quaternion.Euler(0, spreadAngleDefault, 0));
                        shotCounter++;
                        spreadAngleDefault *= -1;
                    }
                    shotCounter++;
                }                
                
                if (shotCounter == numberOfShots)
                {
                    shotCounter = 0;
                }
            }
        }
        else if (currentWLevel == 5 && Time.time > nextFire)
        {
            shotCounter = 0;
            numberOfShots = 5;
            //Angle to spawn bullets at.
            spreadAngleDefault = 3;
            //For those guns that need to shoot more side ways than the front gun.
            spreadAngleIncrementDefault = 9;
            nextFire = Time.time + fireRate;

            foreach (var shotSpawn in shotSpawns)
            {
                if (shotSpawn == shotSpawns[1])
                {
                    //Increments default angle.
                    spreadAngleIncrement = spreadAngleIncrementDefault;

                    while (shotCounter < numberOfShots)
                    {
                        spreadAngleIncrement += spreadAngleDefault;

                        Instantiate(bullet, shotSpawn.position, Quaternion.Euler(0, -spreadAngleIncrement, 0));
                        shotCounter++;
                    }
                }
                else if (shotSpawn == shotSpawns[2])
                {
                    //Increments default angle.
                    spreadAngleIncrement = spreadAngleIncrementDefault;

                    while (shotCounter < numberOfShots)
                    {
                        spreadAngleIncrement += spreadAngleDefault;

                        Instantiate(bullet, shotSpawn.position, Quaternion.Euler(0, +spreadAngleIncrement, 0));
                        shotCounter++;
                    }
                }
                else if (shotSpawn == shotSpawns[0])
                {
                    Instantiate(bullet, shotSpawn.position, shotSpawn.rotation);
                    spreadAngleIncrement = spreadAngleDefault + spreadAngleDefault;


                    while (shotCounter < numberOfShots - 1)
                    {
                        if ( shotCounter >= 2)
                        {
                            Instantiate(bullet, shotSpawn.position, Quaternion.Euler(0, spreadAngleIncrement, 0));
                            //Instantiate(mgShot, shotSpawn.position, Quaternion.Euler(0, -spreadAngleIncrement, 0));
                            shotCounter++;
                            spreadAngleIncrement *= -1;
                        }
                        else if (shotCounter <= 1)
                        {
                            Instantiate(bullet, shotSpawn.position, Quaternion.Euler(0, spreadAngleDefault, 0));
                            shotCounter++;
                            spreadAngleDefault *= -1;
                        }
                    }
                    shotCounter++;
                }

                if (shotCounter == numberOfShots)
                {
                    shotCounter = 0;
                }
            }
        }

    }

    private void ScatterGun()
    {

    }

    private void FlakCannon()
    {
        WhatPlayer();

        //Spawns 1 Bullet from primary hard point.
        if (currentWLevel == 1 && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(bullet, shotSpawns[0].position, shotSpawns[0].rotation);
        }
        else if (currentWLevel == 2 && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            foreach (var shotSpawn in shotSpawns)
            {
                Instantiate(bullet, shotSpawn.position, shotSpawn.rotation);
            }
        }
        else if (currentWLevel == 3 && Time.time > nextFire)
        {
            fireRate = 0.75f;
            nextFire = Time.time + fireRate;
            foreach (var shotSpawn in shotSpawns)
            {
                Instantiate(bullet, shotSpawn.position, shotSpawn.rotation);
            }
        }
        else if (currentWLevel == 4 && Time.time > nextFire)
        {
            //Tracks how many shots the loop has fired.
            shotCounter = 0;
            //Angle to spawn bullets at.
            spreadAngleDefault = 3;
            //For those guns that need to shoot more side ways than the front gun.
            spreadAngleIncrementDefault = 10;
            //Number of shots to be fired by the loop.
            numberOfShots = 2;
            nextFire = Time.time + fireRate;
            foreach (var shotSpawn in shotSpawns)
            {
                if (shotSpawn == shotSpawns[1])
                {
                    //Increments default angle.
                    spreadAngleIncrement = spreadAngleIncrementDefault;

                    while (shotCounter < numberOfShots)
                    {
                        spreadAngleIncrement += spreadAngleDefault;

                        Instantiate(bullet, shotSpawn.position, Quaternion.Euler(0, -spreadAngleIncrement, 0));
                        shotCounter++;
                    }
                }
                else if (shotSpawn == shotSpawns[2])
                {
                    //Increments default angle.
                    spreadAngleIncrement = spreadAngleIncrementDefault;

                    while (shotCounter < numberOfShots)
                    {
                        spreadAngleIncrement += spreadAngleDefault;

                        Instantiate(bullet, shotSpawn.position, Quaternion.Euler(0, +spreadAngleIncrement, 0));
                        shotCounter++;
                    }
                }
                else if (shotSpawn == shotSpawns[0])
                {
                    while (shotCounter < numberOfShots)
                    {
                        Instantiate(bullet, shotSpawn.position, Quaternion.Euler(0, spreadAngleDefault, 0));
                        shotCounter++;
                        spreadAngleDefault *= -1;
                    }
                }

                if (shotCounter == numberOfShots)
                {
                    shotCounter = 0;
                }
            }
        }
        else if (currentWLevel == 5 && Time.time > nextFire)
        {
            fireRate = 0.5f;

            shotCounter = 0;
            numberOfShots = 3;
            //Angle to spawn bullets at.
            spreadAngleDefault = 5;
            //For those guns that need to shoot more side ways than the front gun.
            spreadAngleIncrementDefault = 1;
            nextFire = Time.time + fireRate;

            foreach (var shotSpawn in shotSpawns)
            {
                if (shotSpawn == shotSpawns[1])
                {
                    //Increments default angle.
                    spreadAngleIncrement = spreadAngleIncrementDefault;

                    while (shotCounter < numberOfShots)
                    {
                        spreadAngleIncrement += spreadAngleDefault;

                        Instantiate(bullet, shotSpawn.position, Quaternion.Euler(0, -spreadAngleIncrement, 0));
                        shotCounter++;
                    }
                }
                else if (shotSpawn == shotSpawns[2])
                {
                    //Increments default angle.
                    spreadAngleIncrement = spreadAngleIncrementDefault;

                    while (shotCounter < numberOfShots)
                    {
                        spreadAngleIncrement += spreadAngleDefault;

                        Instantiate(bullet, shotSpawn.position, Quaternion.Euler(0, +spreadAngleIncrement, 0));
                        shotCounter++;
                    }
                }
                else if (shotSpawn == shotSpawns[0])
                {
                    Instantiate(bullet, shotSpawn.position, shotSpawn.rotation);

                    while (shotCounter < numberOfShots - 1)
                    {
                        Instantiate(bullet, shotSpawn.position, Quaternion.Euler(0, spreadAngleDefault, 0));
                        shotCounter++;
                        spreadAngleDefault *= -1;
                    }
                    shotCounter++;
                }

                if (shotCounter == numberOfShots)
                {
                    shotCounter = 0;
                }
            }
        }
    }

    private void Cannon()
    {
        WhatPlayer();

        //Spawns 1 Bullet from primary hard point.
        if (currentWLevel == 1 && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(bullet, shotSpawns[0].position, shotSpawns[0].rotation);
        }
        else if (currentWLevel == 2 && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            foreach (var shotSpawn in shotSpawns)
            {
                Instantiate(bullet, shotSpawn.position, shotSpawn.rotation);
            }
        }
        else if (currentWLevel == 3 && Time.time > nextFire)
        {
            fireRate = 0.75f;
            nextFire = Time.time + fireRate;
            foreach (var shotSpawn in shotSpawns)
            {
                Instantiate(bullet, shotSpawn.position, shotSpawn.rotation);
            }
        }
        else if (currentWLevel == 4 && Time.time > nextFire)
        {
            //Tracks how many shots the loop has fired.
            shotCounter = 0;
            //Angle to spawn bullets at.
            spreadAngleDefault = 3;
            //For those guns that need to shoot more side ways than the front gun.
            spreadAngleIncrementDefault = 10;
            //Number of shots to be fired by the loop.
            numberOfShots = 2;
            nextFire = Time.time + fireRate;
            foreach (var shotSpawn in shotSpawns)
            {
                if (shotSpawn == shotSpawns[1])
                {
                    //Increments default angle.
                    spreadAngleIncrement = spreadAngleIncrementDefault;

                    while (shotCounter < numberOfShots)
                    {
                        spreadAngleIncrement += spreadAngleDefault;

                        Instantiate(bullet, shotSpawn.position, Quaternion.Euler(0, -spreadAngleIncrement, 0));
                        shotCounter++;
                    }
                }
                else if (shotSpawn == shotSpawns[2])
                {
                    //Increments default angle.
                    spreadAngleIncrement = spreadAngleIncrementDefault;

                    while (shotCounter < numberOfShots)
                    {
                        spreadAngleIncrement += spreadAngleDefault;

                        Instantiate(bullet, shotSpawn.position, Quaternion.Euler(0, +spreadAngleIncrement, 0));
                        shotCounter++;
                    }
                }
                else if (shotSpawn == shotSpawns[0])
                {
                    while (shotCounter < numberOfShots)
                    {
                        Instantiate(bullet, shotSpawn.position, Quaternion.Euler(0, spreadAngleDefault, 0));
                        shotCounter++;
                        spreadAngleDefault *= -1;
                    }
                }

                if (shotCounter == numberOfShots)
                {
                    shotCounter = 0;
                }
            }
        }
        else if (currentWLevel == 5 && Time.time > nextFire)
        {
            fireRate = 0.5f;

            shotCounter = 0;
            numberOfShots = 3;
            //Angle to spawn bullets at.
            spreadAngleDefault = 5;
            //For those guns that need to shoot more side ways than the front gun.
            spreadAngleIncrementDefault = 1;
            nextFire = Time.time + fireRate;

            foreach (var shotSpawn in shotSpawns)
            {
                if (shotSpawn == shotSpawns[1])
                {
                    //Increments default angle.
                    spreadAngleIncrement = spreadAngleIncrementDefault;

                    while (shotCounter < numberOfShots)
                    {
                        spreadAngleIncrement += spreadAngleDefault;

                        Instantiate(bullet, shotSpawn.position, Quaternion.Euler(0, -spreadAngleIncrement, 0));
                        shotCounter++;
                    }
                }
                else if (shotSpawn == shotSpawns[2])
                {
                    //Increments default angle.
                    spreadAngleIncrement = spreadAngleIncrementDefault;

                    while (shotCounter < numberOfShots)
                    {
                        spreadAngleIncrement += spreadAngleDefault;

                        Instantiate(bullet, shotSpawn.position, Quaternion.Euler(0, +spreadAngleIncrement, 0));
                        shotCounter++;
                    }
                }
                else if (shotSpawn == shotSpawns[0])
                {
                    Instantiate(bullet, shotSpawn.position, shotSpawn.rotation);

                    while (shotCounter < numberOfShots - 1)
                    {
                        Instantiate(bullet, shotSpawn.position, Quaternion.Euler(0, spreadAngleDefault, 0));
                        shotCounter++;
                        spreadAngleDefault *= -1;
                    }
                    shotCounter++;
                }

                if (shotCounter == numberOfShots)
                {
                    shotCounter = 0;
                }
            }
        }
    }

    public void MorePrimaryGun()
    {
            currentWLevel += 1;
            if(currentWLevel > 5)
            {
                currentWLevel = 5;
            }
    }

    public void MoreSecondaryGun()
    {

    }


    //For When you respawn
    public void LessGun()
    {

    }

    //Figures out what player it belongs to?
    private void WhatPlayer()
    {
        //Puts the bullet into a container to modify.
        bullet = currentWeapon[primaryWeaponSelector] as GameObject;

        if (primaryWeaponSelector == 0)
        {
            //Takes said container and tells it to let the bullet know what player it belongs to.
            bullet.GetComponent<AttackScript>().whoDoIBelongTo = whichPlayer;
        }
        else if (primaryWeaponSelector == 1)
        {
            //Takes said container and tells it to let the bullet know what player it belongs to.
            bullet.GetComponent<AttackScript>().whoDoIBelongTo = whichPlayer;
        }
        else if (primaryWeaponSelector == 2)
        {
            //Takes said container and tells it to let the bullet know what player it belongs to.
            bullet.GetComponent<AttackAoE>().whoDoIBelongTo = whichPlayer;
        }
        else if (primaryWeaponSelector == 3)
        {
            //Takes said container and tells it to let the bullet know what player it belongs to.
            bullet.GetComponent<AttackPenetrate>().whoDoIBelongTo = whichPlayer;
        }
    }
}
