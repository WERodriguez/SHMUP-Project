using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTurret : MonoBehaviour
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

    //Target position.
    public Transform target;
    public float range;

    public float rotateSpeed;

    public string playerTag = "Player";

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        nextVolley = Time.time + initialDelay;
        //Name of function. How long before the function is called. How often it will be called.
        InvokeRepeating("UpdateTarget", 0f, 1.0f);
    }

    private void Update()
    {
        if (Time.time > nextVolley)
        {
            nextVolley = Time.time + fireRate;
            StartCoroutine(FireTurret());
        }
    }

    //Renews search for target. 
    //Searches through all objects marked as an enemy, finds the closest and sets it as target.
    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(playerTag);
        //Temporary variable that stores enemy distance.
        //If you don't have an enemy locked on it'll give you an infinite distance and that causes problems.
        //This makes sure that if bad things aren't in range they don't get chased.
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        //Closest enemy to the missile.
        foreach (GameObject enemy in enemies)
        {
            //Gathers a list of all the enemies in the scene.
            float distanceToEnemy = Vector3.Distance(rb.transform.position, enemy.transform.position);
            //Finds the distance to each enemy.
            if (distanceToEnemy < shortestDistance)
            {
                //If an enemy is closer than the closest current enemy it stores their range and who they are
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        //Marks the closest target.
        if (nearestEnemy != null && shortestDistance <= range)
        {
            target = nearestEnemy.transform;
        }
        else
        {
            return;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (target == null)
        {
            return;
        }

        //Target lock on.
        //Takes the target position and substracts it by the missile position.
        Vector3 dir = target.position - rb.transform.position;
        //Figures out how to point itself at the target.
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        //Figures out how to ease into that turn.
        Vector3 rotation = Quaternion.Lerp(rb.rotation, lookRotation, Time.deltaTime * rotateSpeed).eulerAngles;
        //Actually points at the target.
        rb.rotation = Quaternion.Euler(0.0f, rotation.y, 0.0f);
    }

    IEnumerator FireTurret()
    {
        for (int i = 0; i< burstSize; i++)
        {
            if(nextGun > shotSpawns.Length - 1)
            {
                nextGun = 0;
            }
            Instantiate(shot, shotSpawns[nextGun].position, shotSpawns[nextGun].rotation);
            nextGun++;

            yield return new WaitForSeconds(nextFire);
        }

        yield return new WaitForSeconds(1.0f);
        yield return null;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
