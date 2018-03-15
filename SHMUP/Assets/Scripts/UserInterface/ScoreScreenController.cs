using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreScreenController : MonoBehaviour
{
    public Text matchScore;
    public Text personalScore;
    public Text credit;
    public Text hull;
    public Text shield;
    public Text live;
    public Text superAmmo;

    public Text P1matchScore;
    public Text P1personalScore;
    public Text P1credit;
    public Text P1hull;
    public Text P1shield;
    public Text P1live;
    public Text P1superAmmo;

    public Text P2matchScore;
    public Text P2personalScore;
    public Text P2credit;
    public Text P2hull;
    public Text P2shield;
    public Text P2live;
    public Text P2superAmmo;

    private int currentTotalScore;

    private int currentScore_P1;
    private int currentP1credit;
    private float currentP1Health;
    private float currentP1Shields;
    private int currentP1Lives;
    private int currentP1SuperAmmo;

    private int currentScore_P2;
    private int currentP2credit;
    private float currentP2Health;
    private float currentP2Shields;
    private int currentP2Lives;
    private int currentP2SuperAmmo;

    public GameObject hangarButton;
    public GameObject nextButton;

    public GameObject screen;
    public GameObject P1screen;
    public GameObject P2screen;

    private void Awake()
    {
        hangarButton.SetActive(false);
        nextButton.SetActive(false);

        screen.SetActive(false);
        P1screen.SetActive(false);
        P2screen.SetActive(false);
    }

    private void Start()
    {
        hangarButton.SetActive(true);
        nextButton.SetActive(true);

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
        SetPlayerData();

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

        yield return new WaitForSeconds(1f);
        hull.text = "" + currentP1Health;

        yield return new WaitForSeconds(1f);
        shield.text = "" + currentP1Shields;

        yield return new WaitForSeconds(1f);
        live.text = "" + currentP1Lives;

        yield return new WaitForSeconds(1f);
        superAmmo.text = "" + currentP1SuperAmmo;
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

        yield return new WaitForSeconds(1f);
        P1hull.text = "" + currentP1Health;
        P2hull.text = "" + currentP2Health;

        yield return new WaitForSeconds(1f);
        P1shield.text = "" + currentP1Shields;
        P2shield.text = "" + currentP2Shields;

        yield return new WaitForSeconds(1f);
        P1live.text = "" + currentP1Lives;
        P2live.text = "" + currentP2Lives;

        yield return new WaitForSeconds(1f);
        P1superAmmo.text = "" + currentP1SuperAmmo;
        P2superAmmo.text = "" + currentP2SuperAmmo;
    }

    private void SetPlayerData()
    {
        if (ScoreTracker.score_P1 < 0 || ScoreTracker.score_P2 < 0 || ScoreTracker.totalScore < 0 || ScoreTracker.P1credit < 0 || ScoreTracker.P2credit < 0)
        {
            currentTotalScore = 0;

            currentScore_P1 = 0;
            currentP1credit = 0;

            currentScore_P2 = 0;
            currentP2credit = 0;
        }

        currentTotalScore = ScoreTracker.totalScore;

        currentScore_P1 = ScoreTracker.score_P1;
        currentP1credit = ScoreTracker.P1credit;
        currentP1Health = PlayerHealthSystem.P1currentHealth;
        currentP1Shields = PlayerHealthSystem.P1currentShields;
        currentP1Lives = PlayerHealthSystem.P1currentLives;
        currentP1SuperAmmo = PlayerWeaponController.P1superAmmo;

        currentScore_P2 = ScoreTracker.score_P2;
        currentP2credit = ScoreTracker.P2credit;
        currentP2Health = PlayerHealthSystem.P2currentHealth;
        currentP2Shields = PlayerHealthSystem.P2currentShields;
        currentP2Lives = PlayerHealthSystem.P2currentLives;
        currentP2SuperAmmo = PlayerWeaponController.P2superAmmo;
    }

    private void ResetPlayerScore()
    {
        ScoreTracker.score_P1 = 0;
        ScoreTracker.score_P2 = 0;
        ScoreTracker.totalScore = 0;
    }

    public void HangarButton()
    {
        ResetPlayerScore();

        SceneManager.LoadScene("StoreScreen");
    }

    public void NexButton()
    {
        ResetPlayerScore();

        SceneManager.LoadScene("Level1");
    }
}