using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackExplosion : MonoBehaviour
{

    private HealthSystem health;

    //For experimenting with multiple projectiles later. Shrapnel basically.
    //public GameObject projectiles;

    public float damageAmmount;
    public float explosionDuration;

    //What player the bullet belongs to.
    public bool whoDoIBelongTo;
    private bool whichPlayer;

    public bool hasShrapnel;

    public int shrapnelCount;
    public GameObject shrapnel;
    private GameObject bullet;

    void Start()
    {
        //Destroys the explosion after a duration.
        Destroy(gameObject, explosionDuration);

        if(hasShrapnel)
        {
            whichPlayer = whoDoIBelongTo;

            bullet = shrapnel as GameObject;
            bullet.GetComponent<AttackScript>().whoDoIBelongTo = whichPlayer;

            for (int i = 0; i < shrapnelCount; i++)
            {
                Instantiate(shrapnel, gameObject.transform.position, Quaternion.Euler(0, Random.Range(0, 360), 0));
            }
        }
        

    }

    private void OnTriggerEnter(Collider other)
    {
        //Does nothing to boundary or player tags.
        if (other.CompareTag("Boundary") || other.CompareTag("Player"))
        {
            return;
        }

        //Grabs a refference to the other object's health system
        health = other.GetComponent<HealthSystem>();
        if (health == null)
        {
            return;
        }

        //Tells that health system to deal X damage.
        health.Damage(damageAmmount, whoDoIBelongTo);
    }
}
