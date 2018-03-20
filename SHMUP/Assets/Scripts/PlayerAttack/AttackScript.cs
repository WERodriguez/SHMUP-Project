using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackScript : MonoBehaviour
{
    private HealthSystem health;

    public float damageAmmount;
    public GameObject impactSparks;

    //What player the bullet belongs to.
    public bool whoDoIBelongTo;

    //Just checks if a collider overlaps with a trigger. The thing that is in you. Overlap.
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Boundary") || other.CompareTag("Player"))
        {
            return;
        }

        health = other.GetComponent<HealthSystem>();

        if (health == null)
        {
            return;
        }

        health.Damage(damageAmmount, whoDoIBelongTo);
        Instantiate(impactSparks, gameObject.transform.position, gameObject.transform.rotation);
        Destroy(gameObject);
    }
}