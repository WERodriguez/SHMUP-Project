using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponDisplay : MonoBehaviour
{
    //False = Player 1. True = Player 2
    public bool whichPlayer;

    //PlayerWeaponController specifically refferences that class. weaponController is how we call it here.
    private PlayerWeaponController weaponController;

    // Use this for initialization
    void Start()
    {
        weaponController = GetComponent<PlayerWeaponController>();
    }

    // Update is called once per frame
    void Update()
    {
        //Player 1 Fire Control.
        if (!whichPlayer)
        {
            if (HangarMenuController.P1gunTest)
            {
                if(HangarMenuController.P1finalPrimary)
                {
                    PlayerWeaponController.P1currentWLevel = 5;
                }
                if (HangarMenuController.P1finalSecondary)
                {
                    PlayerWeaponController.P2currentSecondaryLevel = 5;
                }

                StartCoroutine(GunTest());

            }

            //Increments the number of taps a player has done.
            if (HangarMenuController.P1majestic)
            {
                StartCoroutine(SpecialTest());
            }
        }
        //Player 2 Fire Control
        else if (whichPlayer)
        {
            if (HangarMenuController.P2gunTest)
            {
                if (HangarMenuController.P2finalPrimary)
                {
                    PlayerWeaponController.P2currentWLevel = 5;
                }
                if (HangarMenuController.P2finalSecondary)
                {
                    PlayerWeaponController.P2currentSecondaryLevel = 5;
                }

                StartCoroutine(GunTest());
            }

            //Checks if player has tapped the button once.
            if (HangarMenuController.P1majestic)
            {
                StartCoroutine(SpecialTest());
            }
        }
    }

    IEnumerator GunTest()
    {
        yield return new WaitForSeconds(1f);

        weaponController.Fire();

        yield return new WaitForSeconds(6f);

        PlayerWeaponController.P1currentWLevel = PlayerWeaponController.P1savedWeaponLevel;
        PlayerWeaponController.P2currentWLevel = PlayerWeaponController.P2savedWeaponLevel;

        PlayerWeaponController.P1currentSecondaryLevel = PlayerWeaponController.P1savedSecondaryLevel;
        PlayerWeaponController.P2currentSecondaryLevel = PlayerWeaponController.P2savedSecondaryLevel;

        HangarMenuController.P1gunTest = false;
        HangarMenuController.P1finalPrimary = false;
        HangarMenuController.P1finalSecondary = false;

        HangarMenuController.P2gunTest = false;
        HangarMenuController.P2finalPrimary = false;
        HangarMenuController.P2finalSecondary = false;
    }

    IEnumerator SpecialTest()
    {
        yield return new WaitForSeconds(1f);

        weaponController.SuperWeapon();

        yield return new WaitForSeconds(6f);

        HangarMenuController.P1majestic = false;
        HangarMenuController.P2majestic = false;
    }
}
