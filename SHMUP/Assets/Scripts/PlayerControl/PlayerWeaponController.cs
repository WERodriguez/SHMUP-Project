using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerWeaponController : MonoBehaviour
{

    //Fire control variables.
    //fireRate controls the... Well Fire Rate
    public float fireRate;
    public float secondaryFireRate;
    public float superFireRate;

    //Keeps track of when the weapon can fire again.
    private float nextFire;
    private float nextSecondaryFire;
    private float nextSuperFire;

    //Experimenting with chainfire.
    public int nextGun;

    //Weapon default level at start of scene.
    public static int baseWLevel;
    public static int baseSecondaryLevel;

    //Weapon current level
    public static int P1currentWLevel;
    public static int P1currentSecondaryLevel;
    public static int P1savedWeaponLevel;
    public static int P1savedSecondaryLevel;

    public static int P2currentWLevel;
    public static int P2currentSecondaryLevel;
    public static int P2savedWeaponLevel;
    public static int P2savedSecondaryLevel;

    //Currently equipped primary weapon.
    //MG = 0. Flak = 1. Canon = 3.
    //I was having a hard time with the string array and this just works. >.>
    private int P1primaryWeaponSelector;
    private int P1secondaryWeaponSelector;
    private int P1superWeaponSelector;

    private int P2primaryWeaponSelector;
    private int P2secondaryWeaponSelector;
    private int P2superWeaponSelector;

    //Shot to fire
    public GameObject[] primaryWeapons;
    public GameObject[] secondaryWeapons;
    public GameObject[] superWeapons;
    //If weapon fires different shots put them here.
    public GameObject[] plasmaAcceleratorCannon;

    private GameObject childSuperWeapon;

    //Where the ship shoots from. Can be a list of them.
    public Transform[] shotSpawns;
    public Transform[] secondarySpawns;

    private int shotCounter;
    //How many times you can fire your super weapon.
    public static int P1superAmmo;
    public static int P1currentSuperAmmo;
    public static int P1savedSuperAmmo;

    public static int P2superAmmo;
    public static int P2currentSuperAmmo;
    public static int P2savedSuperAmmo;

    public static int superAmmoDefault;

    //How much superAmmo players can hold.
    public int superAmmoCap;
    public Text P1superAmmoCounter;
    public Text P2superAmmoCounter;

    //False = Player 1. True = Player 2
    public bool whichPlayer;

    //Current weapon modified with the whichPlayer bool.
    private GameObject P1bullet;
    private GameObject P1secondaryBullet;
    private GameObject P1superBullet;
    private GameObject P2bullet;
    private GameObject P2secondaryBullet;
    private GameObject P2superBullet;

    //Contains Weapon Firing Sounds
    //WeaponSoundList: 0 = MG, 1 = Flak, 2 = PAC, 3 = Missile Launcher, 4 = Plasma Gun, 5 = MegaBomb, 6 = Beam Charge, 7 = SuperShield.
    public AudioClip[] weaponSounds;
    //Holds an array of all audio sources.
    //Need multiple audio sources so no one sound cuts off another.
    public AudioSource[] audioSources;
    //Plays audio for the different weapons.
    public AudioSource primaryWeaponSound;
    public AudioSource secondaryWeaponSound;
    public AudioSource superWeaponSound;

    void Start()
    {
        audioSources = GetComponents<AudioSource>();
        weaponSounds = new AudioClip[]
        {
            (AudioClip)Resources.Load("Sounds/Machinegun"),
            (AudioClip)Resources.Load("Sounds/FlakCannonFiring"),
            (AudioClip)Resources.Load("Sounds/PACFiring"),
            (AudioClip)Resources.Load("Sounds/MissileLauncherFiringV2"),
            (AudioClip)Resources.Load("Sounds/PlasmaGunFiring"),
            (AudioClip)Resources.Load("Sounds/MegaBombDeploy"),
            (AudioClip)Resources.Load("Sounds/BeamCannonChargeUp"),
            (AudioClip)Resources.Load("Sounds/SuperShieldActivate")
         };

        primaryWeaponSound = audioSources[0];
        secondaryWeaponSound = audioSources[1];
        superWeaponSound = audioSources[2];

        baseWLevel = 1;
        baseSecondaryLevel = 0;
        superAmmoDefault = 3;

        if (MainMenuController.onePlayer)
        {
            SettingUpPlayer1Weapon();
            Player1WeaponData();
        }
        else
        {
            SettingUpPlayer1Weapon();
            Player1WeaponData();

            SettingUpPlayer2Weapon();
            Player2WeaponData();
        }
    }

    // Use this for initialization
    public void Fire()
    {
        //player 1
        if (!whichPlayer)
        {
            if (P1primaryWeaponSelector == 0)
            {
                MachineGun();
            }
            else if (P1primaryWeaponSelector == 1)
            {
                FlakCannon();
            }
            else if (P1primaryWeaponSelector == 2)
            {
                Cannon();
            }

            if (P1currentSecondaryLevel > 0)
            {
                if (P1secondaryWeaponSelector == 0)
                {
                    HomingMissile();
                }
                else if (P1secondaryWeaponSelector == 1)
                {
                    SweeperPods();
                }
                else if (P1secondaryWeaponSelector == 2)
                {
                    PlasmaGun();
                }
            }
        }
        //player 2
        if (whichPlayer)
        {
            if (P2primaryWeaponSelector == 0)
            {
                MachineGun();
            }
            else if (P2primaryWeaponSelector == 1)
            {
                FlakCannon();
            }
            else if (P2primaryWeaponSelector == 2)
            {
                Cannon();
            }

            if (P2currentSecondaryLevel > 0)
            {
                if (P2secondaryWeaponSelector == 0)
                {
                    HomingMissile();
                }
                else if (P2secondaryWeaponSelector == 1)
                {
                    SweeperPods();
                }
                else if (P2secondaryWeaponSelector == 2)
                {
                    PlasmaGun();
                }
            }
        }
    }

    public void SuperWeapon()
    {
        //player 1
        if (!whichPlayer)
        {
            if (P1superWeaponSelector == 0)
            {
                MegaBomb();
            }
            else if (P1superWeaponSelector == 1)
            {
                BeamCannon();
            }
            else if (P1superWeaponSelector == 2)
            {
                MegaShield();
            }
        }
        //player 2
        if (whichPlayer)
        {
            if (P2superWeaponSelector == 0)
            {
                MegaBomb();
            }
            else if (P2superWeaponSelector == 1)
            {
                BeamCannon();
            }
            else if (P2superWeaponSelector == 2)
            {
                MegaShield();
            }
        }
    }

    //Primary Weapons Go Here
    private void MachineGun()
    {
        WhatPlayer();

        //player 1
        if (!whichPlayer)
        {
            //Spawns 1 Bullet from primary hard point.
            if (P1currentWLevel == 1 && Time.time > nextFire)
            {
                fireRate = 0.10f;
                nextFire = Time.time + fireRate;
                //Plays the sound all the way through regardless of how quickly it's called.
                primaryWeaponSound.PlayOneShot(weaponSounds[0]);
                Instantiate(P1bullet, shotSpawns[0].position, shotSpawns[0].rotation);
            }
            //Spawns 1 Bullet from all hard points
            else if (P1currentWLevel == 2 && Time.time > nextFire)
            {
                nextFire = Time.time + fireRate;
                primaryWeaponSound.PlayOneShot(weaponSounds[0]);
                Instantiate(P1bullet, new Vector3(shotSpawns[0].position.x + 0.5f, shotSpawns[0].position.y, shotSpawns[0].position.z), shotSpawns[0].rotation);
                Instantiate(P1bullet, new Vector3(shotSpawns[0].position.x + -0.5f, shotSpawns[0].position.y, shotSpawns[0].position.z), shotSpawns[0].rotation);
            }
            else if (P1currentWLevel == 3 && Time.time > nextFire)
            {
                nextFire = Time.time + fireRate;
                primaryWeaponSound.PlayOneShot(weaponSounds[0]);
                foreach (var shotSpawn in shotSpawns)
                {
                    Instantiate(P1bullet, shotSpawn.position, shotSpawn.rotation);
                }
            }
            else if (P1currentWLevel == 4 && Time.time > nextFire)
            {
                primaryWeaponSound.PlayOneShot(weaponSounds[0]);
                //How to use FanFire()
                //int numberOfShots, float spreadAngleIncrementDefault
                P1FanFire(4, 2.0f);
            }
            else if (P1currentWLevel == 5 && Time.time > nextFire)
            {
                primaryWeaponSound.PlayOneShot(weaponSounds[0]);
                P1FanFire(5, 3.0f);
            }
        }
        //player 2
        if (whichPlayer)
        {
            //Spawns 1 Bullet from primary hard point.
            if (P2currentWLevel == 1 && Time.time > nextFire)
            {
                fireRate = 0.10f;
                nextFire = Time.time + fireRate;
                primaryWeaponSound.PlayOneShot(weaponSounds[0]);
                Instantiate(P2bullet, shotSpawns[0].position, shotSpawns[0].rotation);
            }
            //Spawns 1 Bullet from all hard points
            else if (P2currentWLevel == 2 && Time.time > nextFire)
            {
                nextFire = Time.time + fireRate;
                primaryWeaponSound.PlayOneShot(weaponSounds[0]);
                Instantiate(P2bullet, new Vector3(shotSpawns[0].position.x + 0.5f, shotSpawns[0].position.y, shotSpawns[0].position.z), shotSpawns[0].rotation);
                Instantiate(P2bullet, new Vector3(shotSpawns[0].position.x + -0.5f, shotSpawns[0].position.y, shotSpawns[0].position.z), shotSpawns[0].rotation);
            }
            else if (P2currentWLevel == 3 && Time.time > nextFire)
            {
                nextFire = Time.time + fireRate;
                primaryWeaponSound.PlayOneShot(weaponSounds[0]);
                foreach (var shotSpawn in shotSpawns)
                {
                    Instantiate(P2bullet, shotSpawn.position, shotSpawn.rotation);
                }
            }
            else if (P2currentWLevel == 4 && Time.time > nextFire)
            {
                primaryWeaponSound.PlayOneShot(weaponSounds[0]);
                //How to use FanFire()
                //int numberOfShots, float spreadAngleIncrementDefault
                P2FanFire(4, 2.0f);
            }
            else if (P2currentWLevel == 5 && Time.time > nextFire)
            {
                primaryWeaponSound.PlayOneShot(weaponSounds[0]);
                P2FanFire(5, 3.0f);
            }
        }
    }
    
    private void FlakCannon()
    {
        WhatPlayer();

        //player 1
        if (!whichPlayer)
        {
            //Spawns 1 Bullet from primary hard point.
            if (P1currentWLevel == 1 && Time.time > nextFire)
            {
                fireRate = 1.5f;
                primaryWeaponSound.PlayOneShot(weaponSounds[1]);
                nextFire = Time.time + fireRate;
                Instantiate(P1bullet, shotSpawns[0].position, shotSpawns[0].rotation);
            }
            else if (P1currentWLevel == 2 && Time.time > nextFire)
            {
                fireRate = 1.25f;
                primaryWeaponSound.PlayOneShot(weaponSounds[1]);
                P1ChainFire();
            }
            else if (P1currentWLevel == 3 && Time.time > nextFire)
            {
                fireRate = 1.0f;
                primaryWeaponSound.PlayOneShot(weaponSounds[1]);
                P1ChainFire();
            }
            else if (P1currentWLevel == 4 && Time.time > nextFire)
            {
                fireRate = 1f;
                primaryWeaponSound.PlayOneShot(weaponSounds[1]);
                P1FanFire(3, 20.0f);
            }
            else if (P1currentWLevel == 5 && Time.time > nextFire)
            {
                fireRate = 1f;
                primaryWeaponSound.PlayOneShot(weaponSounds[1]);
                P1FanFire(7, 20.0f);
            }
        }
        //player 2
        if (whichPlayer)
        {
            //Spawns 1 Bullet from primary hard point.
            if (P2currentWLevel == 1 && Time.time > nextFire)
            {
                fireRate = 1.5f;
                primaryWeaponSound.PlayOneShot(weaponSounds[1]);
                nextFire = Time.time + fireRate;
                Instantiate(P2bullet, shotSpawns[0].position, shotSpawns[0].rotation);
            }
            else if (P2currentWLevel == 2 && Time.time > nextFire)
            {
                fireRate = 1.25f;
                primaryWeaponSound.PlayOneShot(weaponSounds[1]);
                P2ChainFire();
            }
            else if (P2currentWLevel == 3 && Time.time > nextFire)
            {
                fireRate = 1.0f;
                primaryWeaponSound.PlayOneShot(weaponSounds[1]);
                P2ChainFire();
            }
            else if (P2currentWLevel == 4 && Time.time > nextFire)
            {
                fireRate = 1f;
                primaryWeaponSound.PlayOneShot(weaponSounds[1]);
                P2FanFire(3, 20.0f);
            }
            else if (P2currentWLevel == 5 && Time.time > nextFire)
            {
                fireRate = 1f;
                primaryWeaponSound.PlayOneShot(weaponSounds[1]);
                P2FanFire(7, 20.0f);
            }
        }
    }

    private void Cannon()
    {
        WhatPlayer();

        //player 1
        if (!whichPlayer)
        {
            //Spawns 1 Bullet from primary hard point.
            if (P1currentWLevel == 1 && Time.time > nextFire)
            {
                fireRate = 1.0f;
                nextFire = Time.time + fireRate;
                primaryWeaponSound.PlayOneShot(weaponSounds[2]);
                Instantiate(P1bullet, shotSpawns[0].position, shotSpawns[0].rotation);
            }
            else if (P1currentWLevel == 2 && Time.time > nextFire)
            {
                fireRate = 1.0f;
                nextFire = Time.time + fireRate;
                primaryWeaponSound.PlayOneShot(weaponSounds[2]);
                Instantiate(P1bullet, new Vector3(shotSpawns[0].position.x + 0.3f, shotSpawns[0].position.y, shotSpawns[0].position.z), shotSpawns[0].rotation);
                Instantiate(P1bullet, new Vector3(shotSpawns[0].position.x + -0.3f, shotSpawns[0].position.y, shotSpawns[0].position.z), shotSpawns[0].rotation);
            }
            else if (P1currentWLevel == 3 && Time.time > nextFire)
            {
                fireRate = 1.0f;
                nextFire = Time.time + fireRate;
                primaryWeaponSound.PlayOneShot(weaponSounds[2]);
                Instantiate(P1bullet, shotSpawns[0].position, shotSpawns[0].rotation);
            }
            else if (P1currentWLevel == 4 && Time.time > nextFire)
            {
                fireRate = 1.0f;
                nextFire = Time.time + fireRate;
                primaryWeaponSound.PlayOneShot(weaponSounds[2]);
                Instantiate(P1bullet, new Vector3(shotSpawns[0].position.x + 0.75f, shotSpawns[0].position.y, shotSpawns[0].position.z), shotSpawns[0].rotation);
                Instantiate(P1bullet, new Vector3(shotSpawns[0].position.x + -0.75f, shotSpawns[0].position.y, shotSpawns[0].position.z), shotSpawns[0].rotation);
            }
            else if (P1currentWLevel == 5 && Time.time > nextFire)
            {
                fireRate = 1.0f;
                nextFire = Time.time + fireRate;
                primaryWeaponSound.PlayOneShot(weaponSounds[2]);
                Instantiate(P1bullet, shotSpawns[0].position, shotSpawns[0].rotation);
            }
        }
        //player 2
        if (whichPlayer)
        {
            //Spawns 1 Bullet from primary hard point.
            if (P2currentWLevel == 1 && Time.time > nextFire)
            {
                fireRate = 1.0f;
                nextFire = Time.time + fireRate;
                primaryWeaponSound.PlayOneShot(weaponSounds[2]);
                Instantiate(P2bullet, shotSpawns[0].position, shotSpawns[0].rotation);
            }
            else if (P2currentWLevel == 2 && Time.time > nextFire)
            {
                fireRate = 1.0f;
                nextFire = Time.time + fireRate;
                primaryWeaponSound.PlayOneShot(weaponSounds[2]);
                Instantiate(P2bullet, new Vector3(shotSpawns[0].position.x + 0.3f, shotSpawns[0].position.y, shotSpawns[0].position.z), shotSpawns[0].rotation);
                Instantiate(P2bullet, new Vector3(shotSpawns[0].position.x + -0.3f, shotSpawns[0].position.y, shotSpawns[0].position.z), shotSpawns[0].rotation);
            }
            else if (P2currentWLevel == 3 && Time.time > nextFire)
            {
                fireRate = 1.0f;
                nextFire = Time.time + fireRate;
                primaryWeaponSound.PlayOneShot(weaponSounds[2]);
                Instantiate(P2bullet, shotSpawns[0].position, shotSpawns[0].rotation);
            }
            else if (P2currentWLevel == 4 && Time.time > nextFire)
            {
                fireRate = 1.0f;
                nextFire = Time.time + fireRate;
                primaryWeaponSound.PlayOneShot(weaponSounds[2]);
                Instantiate(P2bullet, new Vector3(shotSpawns[0].position.x + 0.75f, shotSpawns[0].position.y, shotSpawns[0].position.z), shotSpawns[0].rotation);
                Instantiate(P2bullet, new Vector3(shotSpawns[0].position.x + -0.75f, shotSpawns[0].position.y, shotSpawns[0].position.z), shotSpawns[0].rotation);
            }
            else if (P2currentWLevel == 5 && Time.time > nextFire)
            {
                fireRate = 1.0f;
                nextFire = Time.time + fireRate;
                primaryWeaponSound.PlayOneShot(weaponSounds[2]);
                Instantiate(P2bullet, shotSpawns[0].position, shotSpawns[0].rotation);
            }
        }
    }
    
    //Secondary Weapons Go Here
    private void HomingMissile()
    {
        WhatPlayer();

        //player 1
        if (!whichPlayer)
        {
            if (P1currentSecondaryLevel == 1 && Time.time > nextSecondaryFire)
            {
                secondaryFireRate = 2;
                nextSecondaryFire = Time.time + secondaryFireRate;
                secondaryWeaponSound.PlayOneShot(weaponSounds[3]);
                foreach (var secondarySpawn in secondarySpawns)
                {
                    Instantiate(P1secondaryBullet, secondarySpawn.position, secondarySpawn.rotation);
                }
            }
            else if (P1currentSecondaryLevel == 2 && Time.time > nextSecondaryFire)
            {
                secondaryFireRate = 1.75f;
                nextSecondaryFire = Time.time + secondaryFireRate;
                secondaryWeaponSound.PlayOneShot(weaponSounds[3]);
                foreach (var secondarySpawn in secondarySpawns)
                {
                    Instantiate(P1secondaryBullet, secondarySpawn.position, secondarySpawn.rotation);
                }
            }
            else if (P1currentSecondaryLevel == 3 && Time.time > nextSecondaryFire)
            {
                nextSecondaryFire = Time.time + secondaryFireRate;
                secondaryWeaponSound.PlayOneShot(weaponSounds[3]);
                secondaryFireRate = 1.75f;
                P1SecondaryFanFire(2, 3, 4);
            }
            else if (P1currentSecondaryLevel == 4 && Time.time > nextSecondaryFire)
            {
                nextSecondaryFire = Time.time + secondaryFireRate;
                secondaryWeaponSound.PlayOneShot(weaponSounds[3]);
                secondaryFireRate = 1.5f;
                P1SecondaryFanFire(2, 3, 4);
            }
            else if (P1currentSecondaryLevel == 5 && Time.time > nextSecondaryFire)
            {
                nextSecondaryFire = Time.time + secondaryFireRate;
                secondaryWeaponSound.PlayOneShot(weaponSounds[3]);
                secondaryFireRate = 1.5f;
                P1SecondaryFanFire(3, 3, 5);
            }
        }
        //player 2
        if (whichPlayer)
        {
            if (P2currentSecondaryLevel == 1 && Time.time > nextSecondaryFire)
            {
                secondaryFireRate = 2;
                nextSecondaryFire = Time.time + secondaryFireRate;
                secondaryWeaponSound.PlayOneShot(weaponSounds[3]);
                foreach (var secondarySpawn in secondarySpawns)
                {
                    Instantiate(P2secondaryBullet, secondarySpawn.position, secondarySpawn.rotation);
                }
            }
            else if (P2currentSecondaryLevel == 2 && Time.time > nextSecondaryFire)
            {
                secondaryFireRate = 1.75f;
                nextSecondaryFire = Time.time + secondaryFireRate;
                secondaryWeaponSound.PlayOneShot(weaponSounds[3]);
                foreach (var secondarySpawn in secondarySpawns)
                {
                    Instantiate(P2secondaryBullet, secondarySpawn.position, secondarySpawn.rotation);
                }
            }
            else if (P2currentSecondaryLevel == 3 && Time.time > nextSecondaryFire)
            {
                nextSecondaryFire = Time.time + secondaryFireRate;
                secondaryWeaponSound.PlayOneShot(weaponSounds[3]);
                secondaryFireRate = 1.75f;
                P2SecondaryFanFire(2, 3, 4);
            }
            else if (P2currentSecondaryLevel == 4 && Time.time > nextSecondaryFire)
            {
                nextSecondaryFire = Time.time + secondaryFireRate;
                secondaryWeaponSound.PlayOneShot(weaponSounds[3]);
                secondaryFireRate = 1.5f;
                P2SecondaryFanFire(2, 3, 4);
            }
            else if (P2currentSecondaryLevel == 5 && Time.time > nextSecondaryFire)
            {
                nextSecondaryFire = Time.time + secondaryFireRate;
                secondaryWeaponSound.PlayOneShot(weaponSounds[3]);
                secondaryFireRate = 1.5f;
                P2SecondaryFanFire(3, 3, 5);
            }
        }
    }

    private void SweeperPods()
    {
        WhatPlayer();

        //player 1
        if (!whichPlayer)
        {
            if (P1currentSecondaryLevel == 1 && Time.time > nextSecondaryFire)
            {
                secondaryFireRate = 0.10f;
                nextSecondaryFire = Time.time + secondaryFireRate;
                secondaryWeaponSound.PlayOneShot(weaponSounds[0]);
                foreach (var secondarySpawn in secondarySpawns)
                {
                    Instantiate(P1secondaryBullet, secondarySpawn.position, secondarySpawn.rotation);
                }
            }
            else if (P1currentSecondaryLevel == 2 && Time.time > nextSecondaryFire)
            {
                secondaryFireRate = 0.10f;
                nextSecondaryFire = Time.time + secondaryFireRate;
                secondaryWeaponSound.PlayOneShot(weaponSounds[0]);
                //How many bullets. Initial angle to be fired at. How much to increase the angle by.
                P1SecondaryFanFire(2, 30, 5);
            }
            else if (P1currentSecondaryLevel == 3 && Time.time > nextSecondaryFire)
            {
                secondaryFireRate = 0.10f;
                nextSecondaryFire = Time.time + secondaryFireRate;
                secondaryWeaponSound.PlayOneShot(weaponSounds[0]);
                P1SecondaryFanFire(3, 30, 5);
            }
            else if (P1currentSecondaryLevel == 4 && Time.time > nextSecondaryFire)
            {
                secondaryFireRate = 0.10f;
                nextSecondaryFire = Time.time + secondaryFireRate;
                secondaryWeaponSound.PlayOneShot(weaponSounds[0]);
                P1SecondaryFanFire(4, 30, 5);
            }
            else if (P1currentSecondaryLevel == 5 && Time.time > nextSecondaryFire)
            {
                secondaryFireRate = 0.10f;
                nextSecondaryFire = Time.time + secondaryFireRate;
                secondaryWeaponSound.PlayOneShot(weaponSounds[0]);
                P1SecondaryFanFire(5, 30, 5);
            }
        }
        //player 2
        if (whichPlayer)
        {
            if (P2currentSecondaryLevel == 1 && Time.time > nextSecondaryFire)
            {
                secondaryFireRate = 0.10f;
                nextSecondaryFire = Time.time + secondaryFireRate;
                secondaryWeaponSound.PlayOneShot(weaponSounds[0]);
                foreach (var secondarySpawn in secondarySpawns)
                {
                    Instantiate(P2secondaryBullet, secondarySpawn.position, secondarySpawn.rotation);
                }
            }
            else if (P2currentSecondaryLevel == 2 && Time.time > nextSecondaryFire)
            {
                secondaryFireRate = 0.10f;
                nextSecondaryFire = Time.time + secondaryFireRate;
                secondaryWeaponSound.PlayOneShot(weaponSounds[0]);
                //How many bullets. Initial angle to be fired at. How much to increase the angle by.
                P2SecondaryFanFire(2, 30, 5);
            }
            else if (P2currentSecondaryLevel == 3 && Time.time > nextSecondaryFire)
            {
                secondaryFireRate = 0.10f;
                nextSecondaryFire = Time.time + secondaryFireRate;
                secondaryWeaponSound.PlayOneShot(weaponSounds[0]);
                P2SecondaryFanFire(3, 30, 5);
            }
            else if (P2currentSecondaryLevel == 4 && Time.time > nextSecondaryFire)
            {
                secondaryFireRate = 0.10f;
                nextSecondaryFire = Time.time + secondaryFireRate;
                secondaryWeaponSound.PlayOneShot(weaponSounds[0]);
                P2SecondaryFanFire(4, 30, 5);
            }
            else if (P2currentSecondaryLevel == 5 && Time.time > nextSecondaryFire)
            {
                secondaryFireRate = 0.10f;
                nextSecondaryFire = Time.time + secondaryFireRate;
                secondaryWeaponSound.PlayOneShot(weaponSounds[0]);
                P2SecondaryFanFire(5, 30, 5);
            }
        }
    }

    private void PlasmaGun()
    {
        WhatPlayer();

        //player 1
        if (!whichPlayer)
        {
            if (P1currentSecondaryLevel == 1 && Time.time > nextSecondaryFire)
            {
                secondaryFireRate = 1.5f;
                nextSecondaryFire = Time.time + secondaryFireRate;
                secondaryWeaponSound.PlayOneShot(weaponSounds[4]);
                foreach (var secondarySpawn in secondarySpawns)
                {
                    Instantiate(P1secondaryBullet, secondarySpawn.position, secondarySpawn.rotation);
                }
            }
            else if (P1currentSecondaryLevel == 2 && Time.time > nextSecondaryFire)
            {
                secondaryFireRate = 1.25f;
                nextSecondaryFire = Time.time + secondaryFireRate;
                secondaryWeaponSound.PlayOneShot(weaponSounds[4]);
                foreach (var secondarySpawn in secondarySpawns)
                {
                    Instantiate(P1secondaryBullet, secondarySpawn.position, secondarySpawn.rotation);
                }
            }
            else if (P1currentSecondaryLevel == 3 && Time.time > nextSecondaryFire)
            {
                nextSecondaryFire = Time.time + secondaryFireRate;
                secondaryFireRate = 1.25f;
                secondaryWeaponSound.PlayOneShot(weaponSounds[4]);
                P1SecondaryFanFire(2, 10, 15);
            }
            else if (P1currentSecondaryLevel == 4 && Time.time > nextSecondaryFire)
            {
                nextSecondaryFire = Time.time + secondaryFireRate;
                secondaryFireRate = 1.0f;
                secondaryWeaponSound.PlayOneShot(weaponSounds[4]);
                P1SecondaryFanFire(2, 10, 15);
            }
            else if (P1currentSecondaryLevel == 5 && Time.time > nextSecondaryFire)
            {
                nextSecondaryFire = Time.time + secondaryFireRate;
                secondaryFireRate = 1.0f;
                secondaryWeaponSound.PlayOneShot(weaponSounds[4]);
                P1SecondaryFanFire(3, 10, 15);
            }
        }
        //player 2
        if (whichPlayer)
        {
            if (P2currentSecondaryLevel == 1 && Time.time > nextSecondaryFire)
            {
                secondaryFireRate = 1.5f;
                nextSecondaryFire = Time.time + secondaryFireRate;
                secondaryWeaponSound.PlayOneShot(weaponSounds[4]);
                foreach (var secondarySpawn in secondarySpawns)
                {
                    Instantiate(P2secondaryBullet, secondarySpawn.position, secondarySpawn.rotation);
                }
            }
            else if (P2currentSecondaryLevel == 2 && Time.time > nextSecondaryFire)
            {
                secondaryFireRate = 1.25f;
                nextSecondaryFire = Time.time + secondaryFireRate;
                secondaryWeaponSound.PlayOneShot(weaponSounds[4]);
                foreach (var secondarySpawn in secondarySpawns)
                {
                    Instantiate(P2secondaryBullet, secondarySpawn.position, secondarySpawn.rotation);
                }
            }
            else if (P2currentSecondaryLevel == 3 && Time.time > nextSecondaryFire)
            {
                nextSecondaryFire = Time.time + secondaryFireRate;
                secondaryFireRate = 1.25f;
                secondaryWeaponSound.PlayOneShot(weaponSounds[4]);
                P2SecondaryFanFire(2, 10, 15);
            }
            else if (P2currentSecondaryLevel == 4 && Time.time > nextSecondaryFire)
            {
                nextSecondaryFire = Time.time + secondaryFireRate;
                secondaryFireRate = 1.0f;
                secondaryWeaponSound.PlayOneShot(weaponSounds[4]);
                P2SecondaryFanFire(2, 10, 15);
            }
            else if (P2currentSecondaryLevel == 5 && Time.time > nextSecondaryFire)
            {
                nextSecondaryFire = Time.time + secondaryFireRate;
                secondaryFireRate = 1.0f;
                secondaryWeaponSound.PlayOneShot(weaponSounds[4]);
                P2SecondaryFanFire(3, 10, 15);
            }
        }
    }

    //Super Weapons Go Here
    private void MegaBomb()
    {
        WhatPlayer();

        //player 1
        if (!whichPlayer)
        {
            if (Time.time > nextSuperFire && P1superAmmo > 0)
            {
                superFireRate = 1.0f;
                nextSuperFire = Time.time + superFireRate;
                superWeaponSound.PlayOneShot(weaponSounds[5]);
                P1superAmmo--;
                P1superAmmoCounter.text = "Super Ammo: " + P1superAmmo;
                Instantiate(P1superBullet, shotSpawns[0].position, shotSpawns[0].rotation);
            }
        }
        //player 2
        if (whichPlayer)
        {
            if (Time.time > nextSuperFire && P2superAmmo > 0)
            {
                superFireRate = 1.0f;
                nextSuperFire = Time.time + superFireRate;
                superWeaponSound.PlayOneShot(weaponSounds[5]);
                P2superAmmo--;
                P2superAmmoCounter.text = "Super Ammo: " + P2superAmmo;
                Instantiate(P2superBullet, shotSpawns[0].position, shotSpawns[0].rotation);
            }
        }
    }

    private void BeamCannon()
    {
        WhatPlayer();

        //player 1
        if (!whichPlayer)
        {
            if (Time.time > nextSuperFire && P1superAmmo > 0)
            {
                superFireRate = 8.0f;
                nextSuperFire = Time.time + superFireRate;
                superWeaponSound.PlayOneShot(weaponSounds[6]);
                P1superAmmo--;
                P1superAmmoCounter.text = "Super Ammo: " + P1superAmmo;
                childSuperWeapon = Instantiate(P1superBullet, shotSpawns[0].transform.position, shotSpawns[0].transform.rotation) as GameObject;
                childSuperWeapon.transform.parent = gameObject.transform;
            }
        }
        //player 2
        if (whichPlayer)
        {
            if (Time.time > nextSuperFire && P2superAmmo > 0)
            {
                superFireRate = 8.0f;
                nextSuperFire = Time.time + superFireRate;
                superWeaponSound.PlayOneShot(weaponSounds[6]);
                P2superAmmo--;
                P2superAmmoCounter.text = "Super Ammo: " + P2superAmmo;
                childSuperWeapon = Instantiate(P2superBullet, shotSpawns[0].transform.position, shotSpawns[0].transform.rotation) as GameObject;
                childSuperWeapon.transform.parent = gameObject.transform;
            }
        }
    }

    private void MegaShield()
    {
        WhatPlayer();


        //player 1
        if (!whichPlayer)
        {
            if (Time.time > nextSuperFire && P1superAmmo > 0)
            {
                superFireRate = 7.0f;
                nextSuperFire = Time.time + superFireRate;
                superWeaponSound.PlayOneShot(weaponSounds[7]);
                P1superAmmo--;
                P1superAmmoCounter.text = "Super Ammo: " + P1superAmmo;
                childSuperWeapon = Instantiate(P1superBullet, gameObject.transform.position, gameObject.transform.rotation) as GameObject;
                childSuperWeapon.transform.parent = gameObject.transform;
            }
        }
        //player 2
        if (whichPlayer)
        {
            if (Time.time > nextSuperFire && P2superAmmo > 0)
            {
                superFireRate = 7.0f;
                nextSuperFire = Time.time + superFireRate;
                superWeaponSound.PlayOneShot(weaponSounds[7]);
                P2superAmmo--;
                P2superAmmoCounter.text = "Super Ammo: " + P2superAmmo;
                childSuperWeapon = Instantiate(P2superBullet, gameObject.transform.position, gameObject.transform.rotation) as GameObject;
                childSuperWeapon.transform.parent = gameObject.transform;
            }
        }
    }


    //Where fancy shooting patterns go.
    //Fires one gun after another.
    //player 1
    private void P1ChainFire()
    {
        if (nextGun >= shotSpawns.Length)
        {
            nextGun = 0;
        }
        nextFire = Time.time + fireRate;
        Instantiate(P1bullet, shotSpawns[nextGun].position, shotSpawns[nextGun].rotation);
        nextGun++;
    }
    //player 2
    private void P2ChainFire()
    {
        if (nextGun >= shotSpawns.Length)
        {
            nextGun = 0;
        }
        nextFire = Time.time + fireRate;
        Instantiate(P2bullet, shotSpawns[nextGun].position, shotSpawns[nextGun].rotation);
        nextGun++;
    }

    //Number of shots. Default Angle for spread. Default increment for those bullets that need to start more sideways.
    //player 1
    private void P1FanFire(int numberOfShots, float spreadAngleIncrementDefault)
    {
        //Contains the incremented shot angle.
        float spreadAngleIncrement;

        //Checks if there is an even number of shots.
        if (numberOfShots % 2 == 0)
        {
             //Tracks the number of shots fired by the loop.
            shotCounter = 0;
            //Still keeps track of when the gun can shoot next.
            nextFire = Time.time + fireRate;
            //Sets the increment at which bullets will be turned.
            spreadAngleIncrement = spreadAngleIncrementDefault;
            
            while (shotCounter < numberOfShots)
            {
                //Instantiates a bullet at the desired position at the desired Y rotation.
                Instantiate(P1bullet, shotSpawns[0].position, Quaternion.Euler(0, spreadAngleIncrement, 0));
                //Flips the rotation for the next bullet.
                spreadAngleIncrement *= -1;
                //Increments the shot counter.
                shotCounter++;
                //Instantiates flipped bullet.
                Instantiate(P1bullet, shotSpawns[0].position, Quaternion.Euler(0, spreadAngleIncrement, 0));
                //Increments shot counter. Should be incremented by two now.
                shotCounter++;
                //IMPORTANT: Flips the rotation again! Otherwise it's adding a negative by a positive for the next bit and cancels itself out.
                spreadAngleIncrement *= -1;
                //Increeases the Y rotation to apply for the next set of rounds to spawn.
                spreadAngleIncrement = spreadAngleIncrement + spreadAngleIncrementDefault;
            }

            //Resets the shot counter so the next volley of shots can go out.
            if (shotCounter == numberOfShots)
            {
                shotCounter = 0;
            }
        }
        //Uses this if there is an odd number of shots.
        else
        {
            shotCounter = 0;
            nextFire = Time.time + fireRate;

            //Spawns the central bullet
            Instantiate(P1bullet, shotSpawns[0].position, shotSpawns[0].rotation);
            spreadAngleIncrement = spreadAngleIncrementDefault;

            while (shotCounter < numberOfShots - 1)
            {
                //Instantiates a bullet at the desired position at the desired Y rotation.
                Instantiate(P1bullet, shotSpawns[0].position, Quaternion.Euler(0, spreadAngleIncrement, 0));
                //Flips the rotation for the next bullet.
                spreadAngleIncrement *= -1;
                //Increments the shot counter.
                shotCounter++;
                //Instantiates flipped bullet.
                Instantiate(P1bullet, shotSpawns[0].position, Quaternion.Euler(0, spreadAngleIncrement, 0));
                //Increments shot counter. Should be incremented by two now.
                shotCounter++;
                //IMPORTANT: Flips the rotation again! Otherwise it's adding a negative by a positive for the next bit and cancels itself out.
                spreadAngleIncrement *= -1;
                //Increeases the Y rotation to apply for the next set of rounds to spawn.
                spreadAngleIncrement = spreadAngleIncrement + spreadAngleIncrementDefault;
            }

            //Resets the shot counter so the next volley of shots can go out.
            if (shotCounter == numberOfShots)
            {
                shotCounter = 0;
            }
        }
    }
    //player 2
    private void P2FanFire(int numberOfShots, float spreadAngleIncrementDefault)
    {
        //Contains the incremented shot angle.
        float spreadAngleIncrement;

        //Checks if there is an even number of shots.
        if (numberOfShots % 2 == 0)
        {
            //Tracks the number of shots fired by the loop.
            shotCounter = 0;
            //Still keeps track of when the gun can shoot next.
            nextFire = Time.time + fireRate;
            //Sets the increment at which bullets will be turned.
            spreadAngleIncrement = spreadAngleIncrementDefault;

            while (shotCounter < numberOfShots)
            {
                //Instantiates a bullet at the desired position at the desired Y rotation.
                Instantiate(P2bullet, shotSpawns[0].position, Quaternion.Euler(0, spreadAngleIncrement, 0));
                //Flips the rotation for the next bullet.
                spreadAngleIncrement *= -1;
                //Increments the shot counter.
                shotCounter++;
                //Instantiates flipped bullet.
                Instantiate(P2bullet, shotSpawns[0].position, Quaternion.Euler(0, spreadAngleIncrement, 0));
                //Increments shot counter. Should be incremented by two now.
                shotCounter++;
                //IMPORTANT: Flips the rotation again! Otherwise it's adding a negative by a positive for the next bit and cancels itself out.
                spreadAngleIncrement *= -1;
                //Increeases the Y rotation to apply for the next set of rounds to spawn.
                spreadAngleIncrement = spreadAngleIncrement + spreadAngleIncrementDefault;
            }

            //Resets the shot counter so the next volley of shots can go out.
            if (shotCounter == numberOfShots)
            {
                shotCounter = 0;
            }
        }
        //Uses this if there is an odd number of shots.
        else
        {
            shotCounter = 0;
            nextFire = Time.time + fireRate;

            //Spawns the central bullet
            Instantiate(P2bullet, shotSpawns[0].position, shotSpawns[0].rotation);
            spreadAngleIncrement = spreadAngleIncrementDefault;

            while (shotCounter < numberOfShots - 1)
            {
                //Instantiates a bullet at the desired position at the desired Y rotation.
                Instantiate(P2bullet, shotSpawns[0].position, Quaternion.Euler(0, spreadAngleIncrement, 0));
                //Flips the rotation for the next bullet.
                spreadAngleIncrement *= -1;
                //Increments the shot counter.
                shotCounter++;
                //Instantiates flipped bullet.
                Instantiate(P2bullet, shotSpawns[0].position, Quaternion.Euler(0, spreadAngleIncrement, 0));
                //Increments shot counter. Should be incremented by two now.
                shotCounter++;
                //IMPORTANT: Flips the rotation again! Otherwise it's adding a negative by a positive for the next bit and cancels itself out.
                spreadAngleIncrement *= -1;
                //Increeases the Y rotation to apply for the next set of rounds to spawn.
                spreadAngleIncrement = spreadAngleIncrement + spreadAngleIncrementDefault;
            }

            //Resets the shot counter so the next volley of shots can go out.
            if (shotCounter == numberOfShots)
            {
                shotCounter = 0;
            }
        }
    }

    //Number of shots. Default spread angle. Default increment for shots.
    //player 1
    private void P1SecondaryFanFire(int numberOfShots, float spreadAngleDefault, float spreadAngleIncrementDefault)
    {
        //Contains the incremented shot angle.
        float spreadAngleIncrementL;
        float spreadAngleIncrementR;

        spreadAngleIncrementL = spreadAngleDefault;
        spreadAngleIncrementR = spreadAngleDefault;

        foreach (var secondarySpawn in secondarySpawns)
        {
            //Tracks how many shots have been fired.
            shotCounter = 0;
            //Sets the initial angle at which shots will be fired.

            if(secondarySpawn == secondarySpawns[0])
            {
                while (shotCounter < numberOfShots)
                {
                    Instantiate(P1secondaryBullet, secondarySpawn.position, Quaternion.Euler(0, -spreadAngleIncrementL, 0));
                    spreadAngleIncrementL = spreadAngleIncrementL + spreadAngleIncrementDefault;
                    shotCounter++;
                }
            }
            else if(secondarySpawn == secondarySpawns[1])
            {
                while (shotCounter < numberOfShots)
                {
                    Instantiate(P1secondaryBullet, secondarySpawn.position, Quaternion.Euler(0, +spreadAngleIncrementR, 0));
                    spreadAngleIncrementR = spreadAngleIncrementR + spreadAngleIncrementDefault;
                    shotCounter++;
                }
            }

            if (shotCounter == numberOfShots)
            {
                shotCounter = 0;
            }
        }
    }
    //player 2
    private void P2SecondaryFanFire(int numberOfShots, float spreadAngleDefault, float spreadAngleIncrementDefault)
    {
        //Contains the incremented shot angle.
        float spreadAngleIncrementL;
        float spreadAngleIncrementR;

        spreadAngleIncrementL = spreadAngleDefault;
        spreadAngleIncrementR = spreadAngleDefault;

        foreach (var secondarySpawn in secondarySpawns)
        {
            //Tracks how many shots have been fired.
            shotCounter = 0;
            //Sets the initial angle at which shots will be fired.

            if (secondarySpawn == secondarySpawns[0])
            {
                while (shotCounter < numberOfShots)
                {
                    Instantiate(P2secondaryBullet, secondarySpawn.position, Quaternion.Euler(0, -spreadAngleIncrementL, 0));
                    spreadAngleIncrementL = spreadAngleIncrementL + spreadAngleIncrementDefault;
                    shotCounter++;
                }
            }
            else if (secondarySpawn == secondarySpawns[1])
            {
                while (shotCounter < numberOfShots)
                {
                    Instantiate(P2secondaryBullet, secondarySpawn.position, Quaternion.Euler(0, +spreadAngleIncrementR, 0));
                    spreadAngleIncrementR = spreadAngleIncrementR + spreadAngleIncrementDefault;
                    shotCounter++;
                }
            }

            if (shotCounter == numberOfShots)
            {
                shotCounter = 0;
            }
        }
    }


    //Figures out what player it belongs to?
    private void WhatPlayer()
    {
        //player 1
        if (!whichPlayer)
        {
            //Puts the bullet into a container to modify.
            P1bullet = primaryWeapons[P1primaryWeaponSelector] as GameObject;
            P1secondaryBullet = secondaryWeapons[P1secondaryWeaponSelector] as GameObject;
            P1superBullet = superWeapons[P1superWeaponSelector] as GameObject;

            //PrimaryWeapons
            if (P1primaryWeaponSelector == 0)
            {
                //Takes said container and tells it to let the bullet know what player it belongs to.
                P1bullet.GetComponent<AttackScript>().whoDoIBelongTo = false;
            }
            else if (P1primaryWeaponSelector == 1)
            {
                //Takes said container and tells it to let the bullet know what player it belongs to.
                P1bullet.GetComponent<AttackAoE>().whoDoIBelongTo = false;
            }
            else if (P1primaryWeaponSelector == 2)
            {
                if (P1currentWLevel <= 2)
                {
                    //Uses the standard PAC shot contained within the primaryWeapons array.
                    //Takes said container and tells it to let the bullet know what player it belongs to.
                    P1bullet.GetComponent<AttackPenetrate>().whoDoIBelongTo = false;
                }
                else if (P1currentWLevel >= 3 && P1currentWLevel < 5)
                {
                    //Uses the second tier of PAC shot contained in the plasmaAcceleratorCannon array.
                    P1bullet = plasmaAcceleratorCannon[0] as GameObject;
                    //Takes said container and tells it to let the bullet know what player it belongs to.
                    P1bullet.GetComponent<AttackPenetrate>().whoDoIBelongTo = false;
                }
                else if (P1currentWLevel == 5)
                {
                    //Uses the third tier of PAC shot contained in the plasmaAcceleratorCannon array.
                    P1bullet = plasmaAcceleratorCannon[1] as GameObject;
                    //Takes said container and tells it to let the bullet know what player it belongs to.
                    P1bullet.GetComponent<AttackPenetrate>().whoDoIBelongTo = false;
                }
            }

            //SecondaryWeapons
            if (P1secondaryWeaponSelector == 0)
            {
                P1secondaryBullet.GetComponent<AttackAoE>().whoDoIBelongTo = false;
            }
            else if (P1secondaryWeaponSelector == 1)
            {
                P1secondaryBullet.GetComponent<AttackScript>().whoDoIBelongTo = false;
            }
            else if (P1secondaryWeaponSelector == 2)
            {
                P1secondaryBullet.GetComponent<AttackAoE>().whoDoIBelongTo = false;
            }

            //SuperWeapons
            if (P1superWeaponSelector == 0)
            {
                P1superBullet.GetComponent<SuperBombLauncher>().whoDoIBelongTo = false;
            }
            if (P1superWeaponSelector == 1)
            {
                P1superBullet.GetComponent<BeamCannon>().whoDoIBelongTo = false;
            }
            if (P1superWeaponSelector == 2)
            {
                P1superBullet.GetComponent<MegaShield>().whoDoIBelongTo = false;
            }
        }
        //player2
        if (whichPlayer)
        {
            //Puts the bullet into a container to modify.
            P2bullet = primaryWeapons[P2primaryWeaponSelector] as GameObject;
            P2secondaryBullet = secondaryWeapons[P2secondaryWeaponSelector] as GameObject;
            P2superBullet = superWeapons[P2superWeaponSelector] as GameObject;

            //PrimaryWeapons
            if (P2primaryWeaponSelector == 0)
            {
                //Takes said container and tells it to let the bullet know what player it belongs to.
                P2bullet.GetComponent<AttackScript>().whoDoIBelongTo = true;
            }
            else if (P2primaryWeaponSelector == 1)
            {
                //Takes said container and tells it to let the bullet know what player it belongs to.
                P2bullet.GetComponent<AttackAoE>().whoDoIBelongTo = true;
            }
            else if (P2primaryWeaponSelector == 2)
            {
                if (P2currentWLevel <= 2)
                {
                    //Uses the standard PAC shot contained within the primaryWeapons array.
                    //Takes said container and tells it to let the bullet know what player it belongs to.
                    P2bullet.GetComponent<AttackPenetrate>().whoDoIBelongTo = true;
                }
                else if (P2currentWLevel >= 3 && P1currentWLevel < 5)
                {
                    //Uses the second tier of PAC shot contained in the plasmaAcceleratorCannon array.
                    P2bullet = plasmaAcceleratorCannon[0] as GameObject;
                    //Takes said container and tells it to let the bullet know what player it belongs to.
                    P2bullet.GetComponent<AttackPenetrate>().whoDoIBelongTo = true;
                }
                else if (P2currentWLevel == 5)
                {
                    //Uses the third tier of PAC shot contained in the plasmaAcceleratorCannon array.
                    P2bullet = plasmaAcceleratorCannon[1] as GameObject;
                    //Takes said container and tells it to let the bullet know what player it belongs to.
                    P2bullet.GetComponent<AttackPenetrate>().whoDoIBelongTo = true;
                }
            }

            //SecondaryWeapons
            if (P2secondaryWeaponSelector == 0)
            {
                P2secondaryBullet.GetComponent<AttackAoE>().whoDoIBelongTo = true;
            }
            else if (P2secondaryWeaponSelector == 1)
            {
                P2secondaryBullet.GetComponent<AttackScript>().whoDoIBelongTo = true;
            }
            else if (P2secondaryWeaponSelector == 2)
            {
                P2secondaryBullet.GetComponent<AttackAoE>().whoDoIBelongTo = true;
            }

            //SuperWeapons
            if (P2superWeaponSelector == 0)
            {
                P2superBullet.GetComponent<SuperBombLauncher>().whoDoIBelongTo = true;
            }
            if (P2superWeaponSelector == 1)
            {
                P2superBullet.GetComponent<BeamCannon>().whoDoIBelongTo = true;
            }
            if (P2superWeaponSelector == 2)
            {
                P2superBullet.GetComponent<MegaShield>().whoDoIBelongTo = true;
            }
        }
    }

    public void MorePrimaryGun()
    {
        //player 1
        if (!whichPlayer)
        {
            if (P1currentWLevel >= 5)
            {
                P1currentWLevel = 5;
                return;
            }

            P1currentWLevel += 1;
        }

        //player 2
        if (whichPlayer)
        {
            if (P2currentWLevel >= 5)
            {
                P2currentWLevel = 5;
                return;
            }

            P2currentWLevel += 1;
        }
    }

    public void MoreSecondaryGun()
    {
        //player 1
        if (!whichPlayer)
        {
            if (P1currentSecondaryLevel >= 5)
            {
                P1currentSecondaryLevel = 5;
                return;
            }

            P1currentSecondaryLevel += 1;
        }
        //player 2
        if (whichPlayer)
        {
            if (P2currentSecondaryLevel >= 5)
            {
                P2currentSecondaryLevel = 5;
                return;
            }

            P2currentSecondaryLevel += 1;
        }
    }

    public void MoreSuperAmmo()
    {
        //player 1
        if (!whichPlayer)
        {
            if (P1superAmmo >= superAmmoCap)
            {
                P1superAmmo = superAmmoCap;
                return;
            }

            P1superAmmo += 1;
            P1superAmmoCounter.text = "Super Ammo: " + P1superAmmo;
        }
        //player 2
        if (whichPlayer)
        {
            if (P2superAmmo >= superAmmoCap)
            {
                P2superAmmo = superAmmoCap;
                return;
            }

            P2superAmmo += 1;
            P2superAmmoCounter.text = "Super Ammo: " + P2superAmmo;
        }
    }

    //For When you respawn
    public void LessGun()
    {
        if (!whichPlayer)
        {
            P1currentWLevel = baseWLevel;
            P1currentSecondaryLevel = baseSecondaryLevel;
        }
        if (whichPlayer)
        {
            P2currentWLevel = baseWLevel;
            P2currentSecondaryLevel = baseSecondaryLevel;
        }
    }

    private void SettingUpPlayer1Weapon()
    {
        P1superAmmoCounter.text = "Super Ammo: " + P1superAmmo;

        P1primaryWeaponSelector = SelectionMenuController.P1primaryType - 1;
        P1secondaryWeaponSelector = SelectionMenuController.P1secondaryType - 1;
        P1superWeaponSelector = SelectionMenuController.P1specialType - 1;
    }
    private void SettingUpPlayer2Weapon()
    {
        P2superAmmoCounter.text = "Super Ammo: " + P2superAmmo;

        P2primaryWeaponSelector = SelectionMenuController.P2primaryType - 1;
        P2secondaryWeaponSelector = SelectionMenuController.P2secondaryType - 1;
        P2superWeaponSelector = SelectionMenuController.P2specialType - 1;
    }

    private void Player1WeaponData()
    {
        P1currentWLevel = P1savedWeaponLevel;
        P1currentSecondaryLevel = P1savedSecondaryLevel;
        P1superAmmo = P1savedSuperAmmo;
    }
    private void Player2WeaponData()
    {
        P2currentWLevel = P2savedWeaponLevel;
        P2currentSecondaryLevel = P2savedSecondaryLevel;
        P2superAmmo = P2savedSuperAmmo;
    }
}