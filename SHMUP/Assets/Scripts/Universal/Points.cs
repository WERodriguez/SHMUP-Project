using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Points : MonoBehaviour {

    //Score value for this object.
    public int points;


    private GameController gameController;
    private ScoreTracker scoreTracker;
    private HealthSystem doILive;
    private bool amIBad;
    private bool whoPickedMeUp;

    private void Start()
    {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        gameController = gameControllerObject.GetComponent<GameController>();
        doILive = gameObject.GetComponent<HealthSystem>();
        scoreTracker = gameController.GetComponent<ScoreTracker>();
        if (doILive == null)
        {
            amIBad = false;
        }
        else
        {
            amIBad = true;
        }
    }

    public void AddPoints(bool whatPlayer)
    {
        scoreTracker.AddScore(points, whatPlayer);
    }

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

            if (health == null)
            {
                return;
            }

            whoPickedMeUp = other.GetComponent<PlayerController>().whichPlayer;
            AddPoints(whoPickedMeUp);
            Destroy(gameObject);
        }
    }
}
