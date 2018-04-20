using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Points : MonoBehaviour
{

    //Score value for this object.
    public int points;

    //Access the game controller and score tracker.
    private GameController gameController;
    private ScoreTracker scoreTracker;
    //Checks if the thing has a health system
    private HealthSystem doILive;
    //Tells the code to not handle like a pick up if it's bad dude bro.
    private bool amIBad;
    //Which of the players picked up the thing.
    private bool whoPickedMeUp;

    //Game object that plays the pick up sound to avoid the sound not playing or cutting itself off.
    public GameObject pickUpSoundPlayer;

    private void Start()
    {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        gameController = gameControllerObject.GetComponent<GameController>();
        doILive = gameObject.GetComponent<HealthSystem>();
        scoreTracker = gameController.GetComponent<ScoreTracker>();

        //If it has no health system it is not an enemy.
        if (doILive == null)
        {
            amIBad = false;
        }
        //If it has a health system it is an enemy.
        else
        {
            amIBad = true;
        }
    }

    //Adds points to the designated player when called.
    public void AddPoints(bool whatPlayer)
    {
        scoreTracker.AddScore(points, whatPlayer);
    }

    //For pick ups.
    //Adds points on trigger enter.
    private void OnTriggerEnter(Collider other)
    {
        PlayerHealthSystem health;
        if(!amIBad)
        {
            if (other.CompareTag("Boundary") || other.CompareTag("Enemy"))
            {
                return;
            }

            health = other.GetComponent<PlayerHealthSystem>();

            if (gameObject.CompareTag("PowerUp") || health == null)
            {
                return;
            }

            Instantiate(pickUpSoundPlayer, gameObject.transform.position, gameObject.transform.rotation);
            whoPickedMeUp = other.GetComponent<PlayerController>().whichPlayer;
            AddPoints(whoPickedMeUp);
            Destroy(gameObject);
        }
    }
}
