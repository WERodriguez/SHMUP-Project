using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Makes this a drop down menu in the inspector.
[System.Serializable]
//Player movement boundary variables.
public class Boundary { public float xMin, xMax, zMin, zMax; }

public class PlayerController : MonoBehaviour
{
    //Player Movement.
    public float speed;
    public float tilt;
    public Boundary boundary;
    private float moveHorizontal;
    private float moveVertical;

    //False = Player 1. True = Player 2
    public bool whichPlayer;

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
        //Player 1 Movement Controls
        if(!whichPlayer)
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
                Mathf.Clamp(rb.position.x, boundary.xMin, boundary.xMax),
                0.0f,
                Mathf.Clamp(rb.position.z, boundary.zMin, boundary.zMax)
            );

        rb.rotation = Quaternion.Euler(0.0f, 0.0f, rb.velocity.x * -tilt);
    }

    //Moves the player.
    void MovePlayer()
    {
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.velocity = movement * speed;
    }
}
