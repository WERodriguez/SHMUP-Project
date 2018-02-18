using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackExplosion : MonoBehaviour
{

    private HealthSystem health;

    //For experimenting with multiple projectiles later. Shrapnel basically.
    //public GameObject projectiles;

    public float damageAmmount;
    public int explosionDuration;

    //What player the bullet belongs to.
    public bool whoDoIBelongTo;

    void Start()
    {
        //Destroys the explosion after a duration.
        Destroy(gameObject, explosionDuration);
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
