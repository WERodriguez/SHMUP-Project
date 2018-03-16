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
            if (HangarMenuController.)
            {
                //Calls the PlayerWeaponController script to use its fire function.
                weaponController.Fire();
            }

            //Increments the number of taps a player has done.
            if (HangarMenuController.)
            {
                weaponController.SuperWeapon();
            }
        }
        //Player 2 Fire Control
        else if (whichPlayer)
        {
            if (HangarMenuController.)
            {
                //Calls the PlayerWeaponController script to use its fire function.
                weaponController.Fire();
            }

            //Checks if player has tapped the button once.
            if (HangarMenuController.)
            {
                weaponController.SuperWeapon();
            }

            if (Input.GetButtonUp("Fire_P2"))
            {
                weaponController.nextGun = 0;
            }
        }

    }

    private void FixedUpdate()
    {
        if (P1isDead)
        {
            MovePlayer1();
            return;
        }

        if (P2isDead)
        {
            MovePlayer2();
            return;
        }

        //Player 1 Movement Controls
        if (!whichPlayer)
        {
            moveHorizontal = Input.GetAxis("Horizontal_P1");
            moveVertical = Input.GetAxis("Vertical_P1");

            MovePlayer1();
        }
        //Player 2 Movement Controls
        else if (whichPlayer)
        {
            moveHorizontal = Input.GetAxis("Horizontal_P2");
            moveVertical = Input.GetAxis("Vertical_P2");

            MovePlayer2();
        }

        //Clamps the player position to the boundary settings. Keeps them from going past those points.
        //Also remember it's parenthesis not curly brackets you derp.
        rb.position = new Vector3
            (
                Mathf.Clamp(rb.position.x, xMin, xMax),
                Mathf.Clamp(rb.position.y, yMin, yMax),
                Mathf.Clamp(rb.position.z, zMin, zMax)
            );

        rb.rotation = Quaternion.Euler(0.0f, 0.0f, rb.velocity.x * -tilt);
    }

    //Moves the player.
    void MovePlayer1()
    {
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.velocity = movement * speed;

        //Stops the player from moving when they're dead.
        if (P1isDead)
        {
            rb.velocity = new Vector3(0, 0, 0);
        }
    }
    void MovePlayer2()
    {
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.velocity = movement * speed;

        //Stops the player from moving when they're dead.
        if (P2isDead)
        {
            rb.velocity = new Vector3(0, 0, 0);
        }
    }
}
