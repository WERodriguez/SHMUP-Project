using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Points : MonoBehaviour {

    //Score value for this object.
    public int points;


    private GameController gameController;
    private ScoreTracker scoreTracker;

    private void Start()
    {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        gameController = gameControllerObject.GetComponent<GameController>();
        scoreTracker = gameController.GetComponent<ScoreTracker>();
    }

    public void AddPoints()
    {
        scoreTracker.AddScore(points);
    }
}
