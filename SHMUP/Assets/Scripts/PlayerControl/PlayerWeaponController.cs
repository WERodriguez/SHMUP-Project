using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponController : MonoBehaviour
{

    //Fire control variables.
    //fireRate controls the... Well Fire Rate
    public float fireRate;
    public float secondaryFireRate;

    //Keeps track of when the weapon can fire again.
    private float nextFire;
    private float nextSecondaryFire;

    //Experimenting with chainfire.
    public int nextGun;

    //Weapon default level at start of scene.
    public int baseWLevel;
    public int baseSecondaryLevel;
    //Weapon current level
    public int currentWLevel;
    public int currentSecondaryLevel;
    //Currently equipped primary weapon.
    //MG = 0. ScatterShot = 1. Flak = 2. Canon = 3.
    //I was having a hard time with the string array and this just works. >.>
    public int primaryWeaponSelector;
    public int secondaryWeaponSelector;

    //Shot to fire
    public GameObject[] primaryWeapons;
    public GameObject[] secondaryWeapons;

    //Where the ship shoots from. Can be a list of them.
    public Transform[] shotSpawns;
    public Transform[] secondarySpawns;

    private int shotCounter;

    //False = Player 1. True = Player 2
    private bool whichPlayer;
    //Current weapon modified with the whichPlayer bool.
    private GameObject bullet;
    private GameObject secondaryBullet;

    void Start()
    {
        //Pulls which player it is from the parent object.
        whichPlayer = GetComponent<PlayerController>().whichPlayer;
        currentWLevel = baseWLevel;
        currentSecondaryLevel = baseSecondaryLevel;
    }

    // Use this for initialization
    public void Fire()
    {
        if (primaryWeaponSelector == 0)
        {
            MachineGun();
        }
        else if (primaryWeaponSelector == 1)
        {
            FlakCannon();
        }
        else if (primaryWeaponSelector == 2)
        {
            Cannon();
        }

        if(currentSecondaryLevel > 0)
        {
            if (secondaryWeaponSelector == 0)
            {
                HomingMissile();
            }
        }

    }

    //Primary Weapons Go Here
    private void MachineGun()
    {
        WhatPlayer();

        //Spawns 1 Bullet from primary hard point.
        if (currentWLevel == 1 && Time.time > nextFire)
        {
            fireRate = 0.25f;
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
            //How to use FanFire()
            //int numberOfShots, float spreadAngleDefault, float spreadAngleIncrementDefault
            FanFire(2, 3.0f, 0.0f);
            //Tracks how many shots the loop has fired.
        }
        else if (currentWLevel == 4 && Time.time > nextFire)
        {
            FanFire(3, 3.0f, 9.0f);
        }
        else if (currentWLevel == 5 && Time.time > nextFire)
        {
            FanFire(5, 3.0f, 9.0f);
        }

    }
    
    private void FlakCannon()
    {
        WhatPlayer();

        //Spawns 1 Bullet from primary hard point.
        if (currentWLevel == 1 && Time.time > nextFire)
        {
            fireRate = 1.0f;
            nextFire = Time.time + fireRate;
            Instantiate(bullet, shotSpawns[0].position, shotSpawns[0].rotation);
        }
        else if (currentWLevel == 2 && Time.time > nextFire)
        {
            fireRate = 0.75f;
            ChainFire();
        }
        else if (currentWLevel == 3 && Time.time > nextFire)
        {
            fireRate = 0.5f;
            ChainFire();
        }
        else if (currentWLevel == 4 && Time.time > nextFire)
        {
            fireRate = 1.0f;
            FanFire(3, 20.0f, 20.0f);
        }
        else if (currentWLevel == 5 && Time.time > nextFire)
        {
            fireRate = 1.0f;
            FanFire(5, 20.0f, 45.0f);
        }
    }

    private void Cannon()
    {
        WhatPlayer();

        //Spawns 1 Bullet from primary hard point.
        if (currentWLevel == 1 && Time.time > nextFire)
        {
            fireRate = 1.0f;
            nextFire = Time.time + fireRate;
            Instantiate(bullet, shotSpawns[0].position, shotSpawns[0].rotation);
        }
        else if (currentWLevel == 2 && Time.time > nextFire)
        {
            fireRate = 0.75f;
            ChainFire();
        }
        else if (currentWLevel == 3 && Time.time > nextFire)
        {
            fireRate = 0.5f;
            ChainFire();
        }
        else if (currentWLevel == 4 && Time.time > nextFire)
        {
            fireRate = 0.35f;
            ChainFire();
        }
        else if (currentWLevel == 5 && Time.time > nextFire)
        {
            fireRate = 0.25f;
            ChainFire();            
        }
    }
    
    //Secondary Weapons Go Here
    private void HomingMissile()
    {
        WhatPlayer();

        if (currentSecondaryLevel == 1 && Time.time > nextSecondaryFire)
        {
            secondaryFireRate = 2;
            nextSecondaryFire = Time.time + secondaryFireRate;
            foreach (var secondarySpawn in secondarySpawns)
            {
                Instantiate(secondaryBullet, secondarySpawn.position, secondarySpawn.rotation);
            }
        }
        else if (currentSecondaryLevel == 2 && Time.time > nextSecondaryFire)
        {
            secondaryFireRate = 1.75f;
            nextSecondaryFire = Time.time + secondaryFireRate;
            foreach (var secondarySpawn in secondarySpawns)
            {
                Instantiate(secondaryBullet, secondarySpawn.position, secondarySpawn.rotation);
            }
        }
        else if (currentSecondaryLevel == 3 && Time.time > nextSecondaryFire)
        {
            nextSecondaryFire = Time.time + secondaryFireRate;
            secondaryFireRate = 1.75f;
            SecondaryFanFire(2, 3, 4);
        }
        else if (currentSecondaryLevel == 4 && Time.time > nextSecondaryFire)
        {
            nextSecondaryFire = Time.time + secondaryFireRate;
            secondaryFireRate = 1.5f;
            SecondaryFanFire(2, 3, 4);
        }
        else if (currentSecondaryLevel == 5 && Time.time > nextSecondaryFire)
        {
            nextSecondaryFire = Time.time + secondaryFireRate;
            secondaryFireRate = 1.5f;
            SecondaryFanFire(3, 3, 5);
        }
    }



    //Where fancy shooting patterns go.
    //Fires one gun after another.
    private void ChainFire()
    {
        if (nextGun >= shotSpawns.Length)
        {
            nextGun = 0;
        }
        nextFire = Time.time + fireRate;
        Instantiate(bullet, shotSpawns[nextGun].position, shotSpawns[nextGun].rotation);
        nextGun++;
    }

    //Number of shots. Default Angle for spread. Default increment for those bullets that need to start more sideways.
    private void FanFire(int numberOfShots, float spreadAngleDefault, float spreadAngleIncrementDefault)
    {
        //Contains the incremented shot angle.
        float spreadAngleIncrement;

        if (numberOfShots == 2)
        {
            //Tracks how many shots the loop has fired.
            shotCounter = 0;
            spreadAngleIncrement = spreadAngleDefault;

            nextFire = Time.time + fireRate;
            foreach (var shotSpawn in shotSpawns)
            {
                //While shots fired is less than total number of shots requested.
                while (shotCounter < numberOfShots)
                {
                    //Spawns bullets at shotSpawn but with a Y rotation of 3.
                    Instantiate(bullet, shotSpawn.position, Quaternion.Euler(0, spreadAngleIncrement, 0));
                    shotCounter++;
                    //Flips that bullet around for the next shot.
                    spreadAngleIncrement *= -1;
                }
                //Resets the shotCounter so it can spawn bullets at the rest of the spawners.
                if (shotCounter >= numberOfShots)
                {
                    shotCounter = 0;
                    spreadAngleIncrement = spreadAngleDefault;
                }
            }
        }
        else if (numberOfShots == 3)
        {
            shotCounter = 0;
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
        else if (numberOfShots >= 4)
        {
            shotCounter = 0;

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
                        if (shotCounter >= 2)
                        {
                            Instantiate(bullet, shotSpawn.position, Quaternion.Euler(0, spreadAngleIncrement, 0));
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

    private void SecondaryFanFire(int numberOfShots, float spreadAngleDefault, float spreadAngleIncrementDefault)
    {
        //Contains the incremented shot angle.
        float spreadAngleIncrement;

        if (numberOfShots == 2)
        {
            //Tracks how many shots the loop has fired.
            shotCounter = 0;
            spreadAngleIncrement = spreadAngleDefault;

            nextSecondaryFire = Time.time + secondaryFireRate;
            foreach (var secondarySpawn in secondarySpawns)
            {
                //While shots fired is less than total number of shots requested.
                while (shotCounter < numberOfShots)
                {
                    //Spawns bullets at shotSpawn but with a Y rotation of 3.
                    Instantiate(secondaryBullet, secondarySpawn.position, Quaternion.Euler(0, spreadAngleIncrement, 0));
                    shotCounter++;
                    //Flips that bullet around for the next shot.
                    spreadAngleIncrement *= -1;
                }
                //Resets the shotCounter so it can spawn bullets at the rest of the spawners.
                if (shotCounter >= numberOfShots)
                {
                    shotCounter = 0;
                    spreadAngleIncrement = spreadAngleDefault;
                }
            }
        }
        else if (numberOfShots == 3)
        {
            shotCounter = 0;
            spreadAngleDefault = 3;
            nextSecondaryFire = Time.time + secondaryFireRate;
            foreach (var secondarySpawn in secondarySpawns)
            {
                if (secondarySpawn == secondarySpawns[0])
                {
                    //Increments default angle.
                    spreadAngleIncrement = spreadAngleIncrementDefault;

                    while (shotCounter < numberOfShots)
                    {
                        spreadAngleIncrement += spreadAngleDefault;

                        Instantiate(secondaryBullet, secondarySpawn.position, Quaternion.Euler(0, -spreadAngleIncrement, 0));
                        shotCounter++;
                    }
                }
                else if (secondarySpawn == secondarySpawns[1])
                {
                    //Increments default angle.
                    spreadAngleIncrement = spreadAngleIncrementDefault;

                    while (shotCounter < numberOfShots)
                    {
                        spreadAngleIncrement += spreadAngleDefault;

                        Instantiate(secondaryBullet, secondarySpawn.position, Quaternion.Euler(0, +spreadAngleIncrement, 0));
                        shotCounter++;
                    }
                }
                if (shotCounter == numberOfShots)
                {
                    shotCounter = 0;
                }
            }
        }
        else if (numberOfShots >= 4)
        {
            shotCounter = 0;

            nextSecondaryFire = Time.time + secondaryFireRate;
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
                        if (shotCounter >= 2)
                        {
                            Instantiate(bullet, shotSpawn.position, Quaternion.Euler(0, spreadAngleIncrement, 0));
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


    //Figures out what player it belongs to?
    private void WhatPlayer()
    {
        //Puts the bullet into a container to modify.
        bullet = primaryWeapons[primaryWeaponSelector] as GameObject;
        secondaryBullet = secondaryWeapons[secondaryWeaponSelector] as GameObject;


        if (primaryWeaponSelector == 0 || primaryWeaponSelector == 2)
        {
            //Takes said container and tells it to let the bullet know what player it belongs to.
            bullet.GetComponent<AttackScript>().whoDoIBelongTo = whichPlayer;
        }
        else if (primaryWeaponSelector == 1)
        {
            //Takes said container and tells it to let the bullet know what player it belongs to.
            bullet.GetComponent<AttackAoE>().whoDoIBelongTo = whichPlayer;
        }

        if(currentSecondaryLevel > 0)
        {
            if (secondaryWeaponSelector == 0)
            {
                secondaryBullet.GetComponent<AttackAoE>().whoDoIBelongTo = whichPlayer;
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
        currentSecondaryLevel += 1;
        if (currentSecondaryLevel > 5)
        {
            currentSecondaryLevel = 5;
        }
    }


    //For When you respawn
    public void LessGun()
    {
        currentWLevel = baseWLevel;
        currentSecondaryLevel = baseSecondaryLevel;
    }
}