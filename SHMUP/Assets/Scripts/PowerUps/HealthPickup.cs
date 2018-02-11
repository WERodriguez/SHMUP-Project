﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{

    private PlayerHealthSystem health;
    private PlayerController whatPlayer;
    private Points addScore;

    public float healingAmmount;

    private void Start()
    {
        addScore = gameObject.GetComponent<Points>();
    }

    //Just checks if a collider overlaps with a trigger. The thing that is in you. Overlap.
    private void OnTriggerEnter(Collider other)
    {
        bool whoDunIt;

        if (other.CompareTag("Boundary") || other.CompareTag("Enemy"))
        {
            return;
        }

        whatPlayer = other.GetComponent<PlayerController>();
        health = other.GetComponent<PlayerHealthSystem>();

        if (health == null)
        {
            return;
        }

        whoDunIt = whatPlayer.whichPlayer;
        addScore.AddPoints(whoDunIt);
        health.Healing(healingAmmount);

        Destroy(gameObject);
    }
}
