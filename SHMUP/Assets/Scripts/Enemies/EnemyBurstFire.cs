using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBurstFire : MonoBehaviour
{
    //Weapon Controls
    //Next gun to fire.
    private int nextGun = 0;
    //How many shots in a burst.
    public int burstSize;
    //How fast the gun shoots.
    public float fireRate;
    //Next time guns can fire.
    public float nextFire;
    //How often the turret is called to fire.
    public float nextVolley;
    public float initialDelay;
    //Bullet spawn points.
    public Transform[] shotSpawns;
    //Enemy shot.
    public GameObject shot;
    public GameObject childWeapon;

    public bool isBeamCannon;

    private void Start()
    {
        nextVolley = Time.time + initialDelay;
    }

    private void Update()
    {
        if (Time.time > nextVolley)
        {
            nextVolley = Time.time + fireRate;
            StartCoroutine(BurstFire());
        }
    }

    IEnumerator BurstFire()
    {
        for (int i = 0; i < burstSize; i++)
        {
            if(isBeamCannon)
            {
                if (nextGun > shotSpawns.Length - 1)
                {
                    nextGun = 0;
                }
                //childWeapon = Instantiate(shot, gameObject.transform.position, gameObject.transform.rotation) as GameObject;
                childWeapon = Instantiate(shot, shotSpawns[nextGun].transform.position, gameObject.transform.rotation) as GameObject;
                childWeapon.transform.parent = gameObject.transform;
                nextGun++;
            }
            else
            {
                if (nextGun > shotSpawns.Length - 1)
                {
                    nextGun = 0;
                }
                Instantiate(shot, shotSpawns[nextGun].position, shotSpawns[nextGun].rotation);
                nextGun++;
            }            

            yield return new WaitForSeconds(nextFire);
        }

        yield return new WaitForSeconds(1.0f);
        yield return null;
    }
}
