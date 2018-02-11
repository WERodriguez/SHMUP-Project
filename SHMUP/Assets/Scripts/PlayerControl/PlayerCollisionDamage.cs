using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionDamage : MonoBehaviour
{

    private HealthSystem health;
    private bool whoAmI;

    public float damageAmmount;

    private void Start()
    {
        whoAmI = gameObject.GetComponent<PlayerController>().whichPlayer;
    }

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

        health.Damage(damageAmmount, whoAmI);
    }

}
