﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperAmmoPickUp : MonoBehaviour
{
    private PlayerWeaponController playerWeaponController;
    private PlayerController whatPlayer;
    private Points addScore;

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
        playerWeaponController = other.GetComponent<PlayerWeaponController>();

        if (playerWeaponController == null)
        {
            return;
        }

        whoDunIt = whatPlayer.whichPlayer;
        addScore.AddPoints(whoDunIt);
        playerWeaponController.MoreSuperAmmo();

        Destroy(gameObject);
    }
}