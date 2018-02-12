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

        if(!whichPlayer)
        {
            if (Input.GetButton("Fire_P1"))
            {
                //Calls the PlayerWeaponController script to use its fire function.
                weaponController.Fire();
            }
        }
        else if (whichPlayer)
        {
            if (Input.GetButton("Fire_P2"))
            {
                //Calls the PlayerWeaponController script to use its fire function.
                weaponController.Fire();
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
