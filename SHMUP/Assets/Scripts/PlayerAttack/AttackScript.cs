using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackScript : MonoBehaviour
{
    private HealthSystem health;

    public float damageAmmount;

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

        health.Damage(damageAmmount);

        Destroy(gameObject);
    }
}
