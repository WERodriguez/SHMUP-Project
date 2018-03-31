﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackScript : MonoBehaviour
{
    private PlayerHealthSystem health;

    public float damageAmmount;
    public GameObject impactSparks;

    //Just checks if a collider overlaps with a trigger. The thing that is in you. Overlap.
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Boundary") || other.CompareTag("LightEnemy") || other.CompareTag("MediumEnemy") || other.CompareTag("HeavyEnemy") || other.CompareTag("OverEnemy") || other.CompareTag("EnemyBullet"))
        {
            return;
        }

        health = other.GetComponent<PlayerHealthSystem>();

        if (health == null)
        {
            return;
        }

        health.Damage(damageAmmount);
        Instantiate(impactSparks, gameObject.transform.position, gameObject.transform.rotation);
        Destroy(gameObject);
    }
}
