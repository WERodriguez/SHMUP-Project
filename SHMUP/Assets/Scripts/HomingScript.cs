using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Makes sure you have a rigid body for this. You need it.
[RequireComponent(typeof(Rigidbody))]
public class HomingScript : MonoBehaviour
{
    //Target position.
    public Transform target;
    public float range;

    public float speed;
    public float rotateSpeed;

    public string enemyTag = "Enemy";

    private Rigidbody rb;

	void Start ()
    {
        rb = GetComponent<Rigidbody>();

        InvokeRepeating("UpdateTarget", 0f, 0.5f);
		
	}

    //Renews search for target. 
    //Searches through all objects marked as an enemy, finds the closest and sets it as target.
    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        //Temporary variable that stores enemy distance.
        //If you don't have an enemy locked on it'll give you an infinite distance and that causes problems.
        //This makes sure that if bad things aren't in range they don't get chased.
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        //Closest enemy to the missile.
        foreach(GameObject enemy in enemies)
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
        if(nearestEnemy != null && shortestDistance <= range)
        {
            target = nearestEnemy.transform;
        }
        else
        {
            return;
        }
    }

    private void Update()
    {

    }

    // Update is called once per frame
    void FixedUpdate ()
    {
        rb.velocity = transform.forward * speed;

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

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
