using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreTracker : MonoBehaviour
{
    //Can't figure out how to make the game keep track of player scores separately.

    public Text scoreText_P1;
    public Text scoreText_P2;
    public Text levelScoreText;

    public static int score_P1;
    public static int score_P2;
    public static int totalScore;
    public static int P1credit;
    public static int P2credit;

    //False = P1. True = P2
    private bool player;

    private void Start()
    {
        score_P1 = 0;
        score_P2 = 0;
        totalScore = 0;
    }

    public void AddScore(int newScoreValue, bool whatPlayer)
    {
        player = whatPlayer;
        
        //Updates P1 Score
        //Adds P1 score to total score
        if (!player)
        {
            score_P1 += newScoreValue;
            totalScore += newScoreValue;
            P1credit = totalScore / 2 + score_P1;
        }
        //Updates P2 Score
        //Adds P2 score to total score
        else if (player)
        {
            score_P2 += newScoreValue;
            totalScore += newScoreValue;
            P2credit = totalScore / 2 + score_P2;
        }

        UpdateScore();
    }

    private void UpdateScore()
    {
        
        //Updates P1 Score
        if (!player)
        {
            scoreText_P1.text = "" + score_P1;
        }
        //Updates P2 Score
        else if (player)
        {
            scoreText_P2.text = "" + score_P2;
        }
        //Updates Level Score
        levelScoreText.text = "" + totalScore;
    }
}
