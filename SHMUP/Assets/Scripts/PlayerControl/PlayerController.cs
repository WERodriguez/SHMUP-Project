using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Player Movement.
    public float speed;
    public float tilt;
    private float moveHorizontal;
    private float moveVertical;

    //Movement Constraints
    private float 
        xMin = -12, xMax = 12, 
        yMin = -40, yMax = 20, 
        zMin = -6, zMax = 12;

    //False = Player 1. True = Player 2
    public bool whichPlayer;
    //Checks if player is dead.
    public bool isDead;

    //PlayerWeaponController specifically refferences that class. weaponController is how we call it here.
    private PlayerWeaponController weaponController;

    private Rigidbody rb;

    //Figuring out Doubletap
    //Counts how many times the player tapped their fire key.
    public int p1Total = 0;
    //How long players have until tap counter resets.
    public float p1Delay = 0;
    public int p2Total = 0;
    public float p2Delay = 0;

	// Use this for initialization
	void Start ()
    {
        rb = GetComponent<Rigidbody>();
        weaponController = GetComponent<PlayerWeaponController>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(isDead)
        {
            return;
            
        }

        //Player 1 Fire Control.
        if(!whichPlayer)
        {
            if (Input.GetButton("Fire_P1"))
            {
                //Calls the PlayerWeaponController script to use its fire function.
                weaponController.Fire();

                //Super goes here
            }

            //Increments the number of taps a player has done.
            if(Input.GetButtonDown("Fire_P1"))
            {
                p1Total++;
            }

            //If player has tapped the fire button once it starts to track time between taps.
            //If it's less than half a second keep tracking time. Otherwise reset it.
            if ((p1Total == 1) && (p1Delay < .5))
            {
                p1Delay += Time.deltaTime;
            }

            //Resets tap and time counter if player has taken longer than half a second.
            if ((p1Total == 1) && (p1Delay > .5))
            {
                p1Delay = 0;
                p1Total = 0;
            }

            if ((p1Total == 2) && (p1Delay < .5))
            {
                //CallSuper Here
                Debug.Log("I'MA FIRIN MUH LAZOOOOOOOR");
                weaponController.SuperWeapon();
                p1Delay = 0;
                p1Total = 0;
            }

            if ((p1Total == 2) && (p1Delay > .5))
            {
                p1Delay = 0;
                p1Total = 0;
            }

            //Makes sure chain fire weapons revert to the main gun when they start firing again.
            if (Input.GetButtonUp("Fire_P1"))
            {
                weaponController.nextGun = 0;
            }

        }
        //Player 2 Fire Control
        else if (whichPlayer)
        {
            if (Input.GetButton("Fire_P2"))
            {
                //Calls the PlayerWeaponController script to use its fire function.
                weaponController.Fire();
            }

            //Checks if player has tapped the button once.
            if (Input.GetButtonDown("Fire_P2"))
            {
                p2Total++;
            }

            //If player has tapped the fire button once it starts to track time between taps.
            //If it's less than half a second keep tracking time. Otherwise reset it.
            if ((p2Total == 1) && (p2Delay < .5))
            {
                p2Delay += Time.deltaTime;
            }

            //Resets tap and time counter if player has taken longer than half a second.
            if ((p2Total == 1) && (p2Delay > .5))
            {
                p2Delay = 0;
                p2Total = 0;
            }

            if ((p2Total == 2) && (p2Delay < .5))
            {
                //CallSuper Here
                Debug.Log("I'MA FIRIN MUH LAZOOOOOOOR TOOOOO");
                weaponController.SuperWeapon();
                p2Delay = 0;
                p2Total = 0;
            }

            if ((p2Total == 2) && (p1Delay > .5))
            {
                p2Delay = 0;
                p2Total = 0;
            }

            if (Input.GetButtonUp("Fire_P2"))
            {
                weaponController.nextGun = 0;
            }
        }

    }

    private void FixedUpdate()
    {
        if (isDead)
        {
            MovePlayer();
            return;
        }

        //Player 1 Movement Controls
        if (!whichPlayer)
        {
            moveHorizontal = Input.GetAxis("Horizontal_P1");
            moveVertical = Input.GetAxis("Vertical_P1");

            MovePlayer();
        }
        //Player 2 Movement Controls
        else if (whichPlayer)
        {
            moveHorizontal = Input.GetAxis("Horizontal_P2");
            moveVertical = Input.GetAxis("Vertical_P2");

            MovePlayer();
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
    void MovePlayer()
    {
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.velocity = movement * speed;

        //Stops the player from moving when they're dead.
        if(isDead)
        {
            rb.velocity = new Vector3(0, 0, 0);
        }
    }
}
