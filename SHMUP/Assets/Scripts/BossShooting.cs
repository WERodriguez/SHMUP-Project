using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossShooting : MonoBehaviour
{
    public GameObject[] bulletList;

    public Transform thisSpawnPointPosition;

    private HealthSystem healthSystem;
    private PlayerController playerController;

    private Transform targetPosition;

    //lowest value = 15
    public float waitTime;
    
    private bool spawnBullet;

    private float activationCheck;
    private float chooseWeapon;

    private void Start()
    {
        healthSystem = GetComponent<HealthSystem>();
        playerController = GetComponent<PlayerController>();

        StartCoroutine(CheckActivate());
    }

    private void Update()
    {
        targetPosition = GameObject.FindGameObjectWithTag("Player").transform;
        thisSpawnPointPosition.rotation = Quaternion.Slerp(thisSpawnPointPosition.rotation, Quaternion.LookRotation(targetPosition.position - thisSpawnPointPosition.position), 30 * Time.deltaTime);

        if (activationCheck >= 50)
        {
            StartCoroutine(Fire());
        }
    }

    IEnumerator CheckActivate()
    {
        while (!HUDcontroller.winLevel)
        {
            activationCheck = Random.Range(0f, 100f);

            yield return new WaitForSeconds(waitTime);
        }
    }
    IEnumerator Fire()
    {
        chooseWeapon = Random.Range(0f, 100f);

        yield return new WaitForSeconds(1f);

        if (chooseWeapon < 10)
        {
            //machine gun
            for (int counter = 0; counter < 15; counter++)
            {
                Instantiate(bulletList[0], thisSpawnPointPosition.position, thisSpawnPointPosition.rotation);

                yield return new WaitForSeconds(.3f);
            }
        }
        if (chooseWeapon >= 10 && chooseWeapon < 20)
        {
            //pak cannon
            for (int counter = 0; counter < 6; counter++)
            {
                Instantiate(bulletList[1], thisSpawnPointPosition.position, thisSpawnPointPosition.rotation);

                yield return new WaitForSeconds(1f);
            }
        }
        if (chooseWeapon >= 20 && chooseWeapon < 30)
        {
            //pac
            for (int counter = 0; counter < 9; counter++)
            {
                Instantiate(bulletList[2], thisSpawnPointPosition.position, thisSpawnPointPosition.rotation);

                yield return new WaitForSeconds(.75f);
            }
        }
        if (chooseWeapon >= 30 && chooseWeapon < 40)
        {
            //homing missiles
            for (int counter = 0; counter < 3; counter++)
            {
                Instantiate(bulletList[3], thisSpawnPointPosition.position, thisSpawnPointPosition.rotation);

                yield return new WaitForSeconds(.6f);
                
                Instantiate(bulletList[3], thisSpawnPointPosition.position, thisSpawnPointPosition.rotation);

                yield return new WaitForSeconds(3f);
            }
        }
        if (chooseWeapon >= 40 && chooseWeapon < 50)
        {
            //sweeper popds
            for (int counter = 0; counter < 4; counter++)
            {
                Instantiate(bulletList[4], thisSpawnPointPosition.position, thisSpawnPointPosition.rotation);

                yield return new WaitForSeconds(.6f);

                Instantiate(bulletList[4], thisSpawnPointPosition.position, thisSpawnPointPosition.rotation);

                yield return new WaitForSeconds(3f);
            }
        }
        if (chooseWeapon >= 50 && chooseWeapon < 60)
        {
            //plasma
            for (int counter = 0; counter < 9; counter++)
            {
                Instantiate(bulletList[5], thisSpawnPointPosition.position, thisSpawnPointPosition.rotation);

                yield return new WaitForSeconds(.3f);

                Instantiate(bulletList[5], thisSpawnPointPosition.position, thisSpawnPointPosition.rotation);

                yield return new WaitForSeconds(1f);
            }
        }
        if (chooseWeapon >= 60 && chooseWeapon < 70)
        {
            //mega bomb
            for (int counter = 0; counter < 12; counter++)
            {
                Instantiate(bulletList[6], thisSpawnPointPosition.position, thisSpawnPointPosition.rotation);

                yield return new WaitForSeconds(.6f);
            }
        }
        if (chooseWeapon >= 70 && chooseWeapon < 80)
        {
            //super beam
            Instantiate(bulletList[7], thisSpawnPointPosition.position, thisSpawnPointPosition.rotation);

            yield return new WaitForSeconds(12f);
        }
        if (chooseWeapon >= 80)
        {
            //shield
            Instantiate(bulletList[8], thisSpawnPointPosition.position, thisSpawnPointPosition.rotation);

            yield return new WaitForSeconds(9f);
        }
    }
}
