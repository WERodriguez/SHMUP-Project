using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverController : MonoBehaviour
{
    private int glowTracker;
	private bool waiting;

    public Image restartGlow;
    public Image mainMenuGlow;

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

    private AudioClip[] soundEffect;
    private AudioSource[] buttonSoundEffect;

    public bool myFlexBool;

    private void Awake()
    {
        hangarButton.SetActive(false);
        restartButton.SetActive(false);

        screen.SetActive(false);
        P1screen.SetActive(false);
        P2screen.SetActive(false);

        glowTracker = 1;
		waiting = false;
    }

    private void Start()
    {
		StartCoroutine (Timer ());
    }

    private void Update()
	{
		if (TitleController.arcadeQuit)
		{
			if (Input.GetButtonDown ("ArcadeQuit"))
			{
				Application.Quit ();
			}
		}

		if (waiting)
		{
			SetPlayerScore ();

			if (MainMenuController.onePlayer)
			{
				StartCoroutine (SingleTimer ());
			}
			else
			{
				StartCoroutine (DoubleTimer ());
			}

			if (glowTracker <= 1)
			{
				glowTracker = 1;

				DeactivateGlow ();

				restartGlow.fillAmount = 1;
			}
			if (glowTracker >= 2)
			{
				glowTracker = 2;

				DeactivateGlow ();

				mainMenuGlow.fillAmount = 1;
			}

            if (Input.GetButtonDown("P1HorizontalChoiceLeft") || Input.GetButtonDown("P2HorizontalChoiceLeft") || Input.GetKeyDown(KeyCode.Keypad4))
            {
                ScrollingSound();

                glowTracker--;
			}
            if (Input.GetButtonDown("P1HorizontalChoiceRight") || Input.GetButtonDown("P2HorizontalChoiceRight") || Input.GetKeyDown(KeyCode.Keypad6))
            {
                ScrollingSound();

                glowTracker++;
			}

            if (Input.GetButtonDown("Fire_P1") || Input.GetButtonDown("Fire_P2") || Input.GetKeyDown(KeyCode.Keypad0) || FlexToggle.myFlexBool == true)
            {
				if (glowTracker <= 1)
				{
					RestartButton ();
				}
				if (glowTracker >= 2)
				{
					MainMenuButton ();
				}
			}
		}
    }

	IEnumerator Timer()
    {
        buttonSoundEffect = GetComponents<AudioSource>();
        soundEffect = new AudioClip[]
        {
            (AudioClip)Resources.Load("Music/MenuSound/ScrollingSound"),
        };

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

		DeactivateGlow ();

		yield return new WaitForSeconds (2.5f);

		waiting = true;
	}
    IEnumerator SingleTimer()
    {
        matchScore.text = "" + currentTotalScore;

        yield return new WaitForSeconds(1f);
        personalScore.text = "" + currentScore_P1;

        yield return new WaitForSeconds(1f);
        credit.text = "" + currentP1credit;
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
    }

    private void DeactivateGlow()
    {
        restartGlow.fillAmount = 0;
        mainMenuGlow.fillAmount = 0;
    }

    private void SetPlayerScore()
    {
        if (ScoreTracker.score_P1 < 0 || ScoreTracker.score_P2 < 0 || ScoreTracker.totalScore < 0 || ScoreTracker.P1credit < 0 || ScoreTracker.P2credit < 0)
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
        PlayerHealthSystem.P1currentHealth = PlayerHealthSystem.P1maxHealth;
        PlayerHealthSystem.P1currentShields = PlayerHealthSystem.P1maxShields;
        PlayerHealthSystem.P1currentLives = 3;

        PlayerWeaponController.P1savedWeaponLevel = PlayerWeaponController.baseWLevel;
        PlayerWeaponController.P1savedSecondaryLevel = PlayerWeaponController.baseSecondaryLevel;
        PlayerWeaponController.P1savedSuperAmmo = PlayerWeaponController.superAmmoDefault;
    }
    private void ResetPlayer2Value()
    {
        PlayerHealthSystem.P2currentHealth = PlayerHealthSystem.P2maxHealth;
        PlayerHealthSystem.P2currentShields = PlayerHealthSystem.P2maxShields;
        PlayerHealthSystem.P2currentLives = 3;

        PlayerWeaponController.P2savedWeaponLevel = PlayerWeaponController.baseWLevel;
        PlayerWeaponController.P2savedSecondaryLevel = PlayerWeaponController.baseSecondaryLevel;
        PlayerWeaponController.P2savedSuperAmmo = PlayerWeaponController.superAmmoDefault;
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

        if (MainMenuController.currentStage <= 1)
        {
            SceneManager.LoadScene("Level1");
        }
        if (MainMenuController.currentStage == 2)
        {
            SceneManager.LoadScene("Level2");
        }
        if (MainMenuController.currentStage >= 3)
        {
            SceneManager.LoadScene("Level3");
        }
    }

    public void MainMenuButton()
    {
        ResetPlayerScore();

        if (MainMenuController.onePlayer)
        {
            ResetPlayer1Value();
        }
        else
        {
            ResetPlayer1Value();
            ResetPlayer2Value();
        }

        SceneManager.LoadScene("MainMenu");
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

    private void ScrollingSound()
    {
        buttonSoundEffect[0].Stop();
        buttonSoundEffect[0].clip = soundEffect[0];
        buttonSoundEffect[0].Play();
    }
}