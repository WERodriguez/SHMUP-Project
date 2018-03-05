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

    private void Start()
    {
        DeactivatePauseMenu();
        DeactivateScoreScreen();
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

        if (Input.GetKeyDown(KeyCode.O) || (PlayerHealthSystem.currentHealth <= 0 && PlayerHealthSystem.currentShields <= 0 && PlayerHealthSystem.currentLives <= 0))
        {
            SceneManager.LoadScene("GameOver");
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

    private void ResetValue()
    {
        /*
        PlayerHealthSystem.currentLives = PlayerHealthSystem.maxLives;
        PlayerHealthSystem.currentHealth = PlayerHealthSystem.maxHealth;
        PlayerHealthSystem.currentShields = PlayerHealthSystem.maxShields;
        */
    }

    public void ResumeButton()
    {
        DeactivatePauseMenu();
        Time.timeScale = 1f;
    }

    public void RestartButton()
    {
        DeactivatePauseMenu();
        ResetValue();
        SceneManager.LoadScene("(Testing)TheRange");
    }

    public void MainMenuButton()
    {
        DeactivatePauseMenu();
        ResetValue();
        SceneManager.LoadScene("Start");
    }

    public void ContinueButton()
    {
        Time.timeScale = 0f;
        SceneManager.LoadScene("Hangar");
    }
}
