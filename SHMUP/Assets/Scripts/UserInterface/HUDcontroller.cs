using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HUDcontroller : MonoBehaviour
{
    public GameObject HUD;

    public GameObject pauseMenu;
    public GameObject resumeButton;
    public GameObject restartButton;
    public GameObject mainMenuButton;

    public GameObject scoreScreen;
    public GameObject onePlayerScoreScreen;
    public GameObject twoPlayersScoreScreen;
    public GameObject continueButton;

    public static bool winLevel;

    private void Start()
    {
        DeactivatePauseMenu();
        DeactivateScoreScreen();

        winLevel = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            ActivatePauseMenu();
        }

        if (Input.GetKeyDown(KeyCode.I))
        {
            ActivateScoreScreen();
        }

        if (Input.GetKeyDown(KeyCode.O))
        {
            SceneManager.LoadScene("GameOver");
        }

        if(UIController.onePlayer)
        {
            if(PlayerHealthSystem.P1currentHealth <= 0 && PlayerHealthSystem.P1currentShields <= 0 && PlayerHealthSystem.P1currentLives <= 0)
            {
                SceneManager.LoadScene("GameOver");
            }
        }
        else
        {
            if((PlayerHealthSystem.P1currentHealth <= 0 && PlayerHealthSystem.P1currentShields <= 0 && PlayerHealthSystem.P1currentLives <= 0)
                && (PlayerHealthSystem.P2currentHealth <= 0 && PlayerHealthSystem.P2currentShields <= 0 && PlayerHealthSystem.P2currentLives <= 0))
            {
                SceneManager.LoadScene("GameOver");
            }
        }

        if(winLevel)
        {
            ActivateScoreScreen();
        }
    }

    private void ActivatePauseMenu()
    {
        Time.timeScale = 0f;

        HUD.SetActive(false);

        pauseMenu.SetActive(true);
        resumeButton.SetActive(true);
        restartButton.SetActive(true);
        mainMenuButton.SetActive(true);
    }
    private void DeactivatePauseMenu()
    {
        Time.timeScale = 1f;

        HUD.SetActive(true);

        pauseMenu.SetActive(false);
        resumeButton.SetActive(false);
        restartButton.SetActive(false);
        mainMenuButton.SetActive(false);
    }

    private void ActivateScoreScreen()
    {
        Time.timeScale = 0f;

        HUD.SetActive(false);

        scoreScreen.SetActive(true);
        continueButton.SetActive(true);

        CheckNumberOfPlayer();
    }
    private void DeactivateScoreScreen()
    {
        Time.timeScale = 1f;

        HUD.SetActive(true);

        scoreScreen.SetActive(false);
        continueButton.SetActive(false);

        CheckNumberOfPlayer();
    }

    private void CheckNumberOfPlayer()
    {
        if (UIController.onePlayer)
        {
            onePlayerScoreScreen.SetActive(true);
            twoPlayersScoreScreen.SetActive(false);
        }
        else
        {
            onePlayerScoreScreen.SetActive(false);
            twoPlayersScoreScreen.SetActive(true);
        }
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

    public void ResumeButton()
    {
        DeactivatePauseMenu();
        Time.timeScale = 1f;
    }

    public void RestartButton()
    {
        if (UIController.onePlayer)
        {
            ResetPlayer1Value();
        }
        else
        {
            ResetPlayer1Value();
            ResetPlayer2Value();
        }

        DeactivatePauseMenu();
        SceneManager.LoadScene("(Testing)TheRange");
    }

    public void MainMenuButton()
    {
        if (UIController.onePlayer)
        {
            ResetPlayer1Value();
        }
        else
        {
            ResetPlayer1Value();
            ResetPlayer2Value();
        }

        DeactivatePauseMenu();
        SceneManager.LoadScene("Start");
    }

    public void ContinueButton()
    {
        Time.timeScale = 0f;
        SceneManager.LoadScene("Hangar");
    }
}
