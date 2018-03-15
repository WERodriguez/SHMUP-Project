using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverController : MonoBehaviour
{
    public Text matchScore;
    public Text personalScore;
    public Text credit;
    public Text P1matchScore;
    public Text P1personalScore;
    public Text P1credit;
    public Text P2matchScore;
    public Text P2personalScore;
    public Text P2credit;

    private int currentScore_P1;
    private int currentScore_P2;
    private int currentTotalScore;
    private int currentP1credit;
    private int currentP2credit;

    public GameObject hangarButton;
    public GameObject restartButton;

    public GameObject screen;
    public GameObject P1screen;
    public GameObject P2screen;

    private void Awake()
    {
        hangarButton.SetActive(false);
        restartButton.SetActive(false);

        screen.SetActive(false);
        P1screen.SetActive(false);
        P2screen.SetActive(false);
    }

    private void Start()
    {
        hangarButton.SetActive(true);
        restartButton.SetActive(true);

        if (MainMenuController.onePlayer)
        {
            screen.SetActive(true);
        }
        else
        {
            P1screen.SetActive(true);
            P2screen.SetActive(true);
        }
    }

    private void Update()
    {
        SetPlayerScore();

        if (MainMenuController.onePlayer)
        {
            StartCoroutine(SingleTimer());
        }
        else
        {
            StartCoroutine(DoubleTimer());
        }
    }

    IEnumerator SingleTimer()
    {
        yield return new WaitForSeconds(4f);
        matchScore.text = "" + currentTotalScore;

        yield return new WaitForSeconds(1f);
        personalScore.text = "" + currentScore_P1;

        yield return new WaitForSeconds(1f);
        credit.text = "" + currentP1credit;
    }

    IEnumerator DoubleTimer()
    {
        yield return new WaitForSeconds(4f);
        P1matchScore.text = "" + currentTotalScore;
        P2matchScore.text = "" + currentTotalScore;

        yield return new WaitForSeconds(1f);
        P1personalScore.text = "" + currentScore_P1;
        P2personalScore.text = "" + currentScore_P2;

        yield return new WaitForSeconds(1f);
        P1credit.text = "" + currentP1credit;
        P2credit.text = "" + currentP2credit;
    }

    private void SetPlayerScore()
    {
        if(ScoreTracker.score_P1 < 0 || ScoreTracker.score_P2 < 0 || ScoreTracker.totalScore < 0 || ScoreTracker.P1credit < 0 || ScoreTracker.P2credit < 0)
        {
            currentScore_P1 = 0;
            currentScore_P2 = 0;
            currentTotalScore = 0;
            currentP1credit = 0;
            currentP2credit = 0;
        }

        currentScore_P1 = ScoreTracker.score_P1;
        currentScore_P2 = ScoreTracker.score_P2;
        currentTotalScore = ScoreTracker.totalScore;
        currentP1credit = ScoreTracker.P1credit;
        currentP2credit = ScoreTracker.P2credit;
}
    private void ResetPlayerScore()
    {
        ScoreTracker.score_P1 = 0;
        ScoreTracker.score_P2 = 0;
        ScoreTracker.totalScore = 0;
        ScoreTracker.P1credit = 0;
        ScoreTracker.P2credit = 0;
    }

    private void ResetPlayer1Value()
    {
        PlayerHealthSystem.P1currentLives = PlayerHealthSystem.P1maxLives;
        PlayerHealthSystem.P1currentHealth = PlayerHealthSystem.P1maxHealth;
        PlayerHealthSystem.P1currentShields = PlayerHealthSystem.P1maxShields;
    }
    private void ResetPlayer2Value()
    {
        PlayerHealthSystem.P2currentLives = PlayerHealthSystem.P2maxLives;
        PlayerHealthSystem.P2currentHealth = PlayerHealthSystem.P2maxHealth;
        PlayerHealthSystem.P2currentShields = PlayerHealthSystem.P2maxShields;
    }

    public void HangarButton()
    {
        SceneManager.LoadScene("StoreScreen");
    }

    public void RestartButton()
    {
        if (MainMenuController.onePlayer)
        {
            ResetPlayer1Value();
        }
        else
        {
            ResetPlayer1Value();
            ResetPlayer2Value();
        }

        ResetPlayerScore();

        SceneManager.LoadScene("Level1");
    }
}