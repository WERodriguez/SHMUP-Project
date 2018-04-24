using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreScreenController : MonoBehaviour
{
    private int glowTracker;
    private bool waiting;

    public Image nextGlow;
    public Image hangarGlow;

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

    public GameObject hangarButton;
    public GameObject nextButton;

    public GameObject screen;
    public GameObject P1screen;
    public GameObject P2screen;

    public bool myFlexBool;

    private void Awake()
    {
        hangarButton.SetActive(false);
        nextButton.SetActive(false);

        screen.SetActive(false);
        P1screen.SetActive(false);
        P2screen.SetActive(false);

        DeactivateGlow();

        glowTracker = 1;
        waiting = false;
    }

    private void Start()
    {
        StartCoroutine(Timer());
    }

    private void Update()
	{
		if (MainMenuController.arcadeQuit)
		{
			if (Input.GetButtonDown ("ArcadeQuit"))
			{
				Application.Quit ();
			}
		}

        if (waiting)
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

            if (glowTracker <= 1)
            {
                glowTracker = 1;

                DeactivateGlow();

                nextGlow.fillAmount = 1;
            }
            if (glowTracker >= 2)
            {
                glowTracker = 2;

                DeactivateGlow();

                hangarGlow.fillAmount = 1;
            }

            if (Input.GetButtonDown("P1HorizontalChoiceLeft") || Input.GetButtonDown("P2HorizontalChoiceLeft") || Input.GetKeyDown(KeyCode.Keypad4))
            {
                glowTracker--;
            }
            if (Input.GetButtonDown("P1HorizontalChoiceRight") || Input.GetButtonDown("P2HorizontalChoiceRight") || Input.GetKeyDown(KeyCode.Keypad6))
            {
                glowTracker++;
            }

            if (Input.GetButtonDown("Fire_P1") || Input.GetButtonDown("Fire_P2") || Input.GetKeyDown(KeyCode.Keypad0) || FlexToggle.myFlexBool == true)
            {
                if (glowTracker <= 1)
                {
                    NexButton();
                }
                if (glowTracker >= 2)
                {
                    HangarButton();
                }
            }
        }
    }

    IEnumerator Timer()
    {
        MainMenuController.currentStage++;
        HUDcontroller.winLevel = false;

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

        yield return new WaitForSeconds(4f);

        waiting = true;
    }

    IEnumerator SingleTimer()
    {
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

    private void DeactivateGlow()
    {
        nextGlow.fillAmount = 0;
        hangarGlow.fillAmount = 0;
    }

    private void SetPlayerScore()
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

        if (PlayerHealthSystem.P1currentLives < 0)
        {
            currentP1Lives = 0;
        }
        if (PlayerHealthSystem.P2currentLives < 0)
        {
            currentP2Lives = 0;
        }
    }
    private void ResetPlayerScore()
    {
        ScoreTracker.score_P1 = 0;
        ScoreTracker.score_P2 = 0;
        ScoreTracker.totalScore = 0;
    }

    private void SetPlayer1Value()
    {
        PlayerHealthSystem.P1savedHealth = PlayerHealthSystem.P1currentHealth;
        PlayerHealthSystem.P1savedShields = PlayerHealthSystem.P1currentShields;
        PlayerHealthSystem.P1savedLives = PlayerHealthSystem.P1currentLives;

        PlayerWeaponController.P1savedWeaponLevel = PlayerWeaponController.P1currentWLevel;
        PlayerWeaponController.P1savedSecondaryLevel = PlayerWeaponController.P1currentSecondaryLevel;
        PlayerWeaponController.P1savedSuperAmmo = PlayerWeaponController.P1superAmmo;
    }
    private void SetPlayer2Value()
    {
        PlayerHealthSystem.P2savedHealth = PlayerHealthSystem.P2currentHealth;
        PlayerHealthSystem.P2savedShields = PlayerHealthSystem.P2currentShields;
        PlayerHealthSystem.P2savedLives = PlayerHealthSystem.P2currentLives;

        PlayerWeaponController.P2savedWeaponLevel = PlayerWeaponController.P2currentWLevel;
        PlayerWeaponController.P2savedSecondaryLevel = PlayerWeaponController.P2currentSecondaryLevel;
        PlayerWeaponController.P2savedSuperAmmo = PlayerWeaponController.P2superAmmo;
    }

    public void NexButton()
    {
        ResetPlayerScore();

        if (MainMenuController.onePlayer)
        {
            SetPlayer1Value();
        }
        else
        {
            SetPlayer1Value();
            SetPlayer2Value();

            if(PlayerHealthSystem.P1currentLives < 0)
            {
                PlayerHealthSystem.P1savedHealth = PlayerHealthSystem.P1maxHealth;
                PlayerHealthSystem.P1savedShields = PlayerHealthSystem.P1maxShields;
                PlayerHealthSystem.P1savedLives = 0;

                PlayerWeaponController.P1savedWeaponLevel = 1;
                PlayerWeaponController.P1savedSecondaryLevel = 0;
                PlayerWeaponController.P1savedSuperAmmo = PlayerWeaponController.P1superAmmo;
            }
            if (PlayerHealthSystem.P2currentLives < 0)
            {
                PlayerHealthSystem.P2savedHealth = PlayerHealthSystem.P1maxHealth;
                PlayerHealthSystem.P2savedShields = PlayerHealthSystem.P1maxShields;
                PlayerHealthSystem.P2savedLives = 0;
                
                PlayerWeaponController.P2savedWeaponLevel = 1;
                PlayerWeaponController.P2savedSecondaryLevel = 0;
                PlayerWeaponController.P2savedSuperAmmo = PlayerWeaponController.P2superAmmo;
            }
        }

        if(MainMenuController.currentStage <= 1)
        {
            SceneManager.LoadScene("Level1");
        }
        if (MainMenuController.currentStage == 2)
        {
            SceneManager.LoadScene("Level2");
        }
        if (MainMenuController.currentStage == 3)
        {
            SceneManager.LoadScene("Level3");
        }
        if (MainMenuController.currentStage > 3)
        {
            SceneManager.LoadScene("Credit");
        }
    }

    public void HangarButton()
    {
        ResetPlayerScore();

        SceneManager.LoadScene("Hangar");
    }

    //Registers flex as true.
    public void SetFlexTrue()
    {
        myFlexBool = true;
    }

    //Registers flex as false.
    public void SetFlexFalse()
    {
        myFlexBool = false;
    }
}