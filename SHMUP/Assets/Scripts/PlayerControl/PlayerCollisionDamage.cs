﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionDamage : MonoBehaviour
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

        if (health == null)
        {
            return;
        }

        health = other.GetComponent<HealthSystem>();
        health.Damage(damageAmmount);
    }

}
