using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlakScatterGun : MonoBehaviour
{
    //Weapon Controls
    //How many shots in a burst.
    public int burstSize;
    //How fast the gun shoots a volley.
    public float fireRate;
    //Next time guns can fire a shot in a volley.
    public float nextFire;
    //How often the turret is called to fire.
    public float nextVolley;
    public float initialDelay;
    //Angle at which bullets can spawn.
    public float firingConeAngle;
    //The guns will fire off their rotation based on global rather than local rotation without this.
    public Quaternion shotSpawnFacing;
    //Bullet spawn points.
    public Transform shotSpawn;
    //Enemy shot.
    public GameObject shot;

    private void Start()
    {
        nextVolley = Time.time + initialDelay;
        shotSpawnFacing = shotSpawn.localRotation;
    }

    private void Update()
    {
        shotSpawnFacing = shotSpawn.localRotation;
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
            //Uses the shotspawn transform and rotation to track where the guns should shoot from.
            //The Y axis is added or subtracted by the firing cone angle so it shoots off in the direction the gun is facing.
            //Instantiate(shot, shotSpawn.position, shotSpawn.rotation);

            Instantiate(shot, shotSpawn.position, Quaternion.Euler(shotSpawn.transform.eulerAngles.x, shotSpawn.transform.eulerAngles.y + Random.Range(-firingConeAngle, firingConeAngle), shotSpawn.transform.eulerAngles.z));
            //Instantiate(shot, shotSpawn.position, Quaternion.Euler(shotSpawnFacing.x, shotSpawnFacing.y + Random.Range(-firingConeAngle, firingConeAngle), shotSpawnFacing.z));
            yield return new WaitForSeconds(nextFire);
        }

        yield return new WaitForSeconds(1.0f);
        yield return null;
    }
}
