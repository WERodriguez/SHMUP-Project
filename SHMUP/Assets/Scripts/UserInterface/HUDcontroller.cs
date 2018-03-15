using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HUDcontroller : MonoBehaviour
{
    public GameObject P1HUD;
    public GameObject P2HUD;
    public GameObject pauseText;

    public GameObject pauseMenu;
    public GameObject resumeButton;
    public GameObject restartButton;
    public GameObject mainMenuButton;
    public GameObject player2Button;

    public static bool winLevel;

    private void Start()
    {
        DeactivateHUD();
        DeactivatePauseMenu();

        winLevel = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            ActivatePauseMenu();
        }

        if(MainMenuController.onePlayer)
        {
            if(PlayerHealthSystem.P1currentHealth <= 0 && PlayerHealthSystem.P1currentShields <= 0 && PlayerHealthSystem.P1currentLives <= 0)
            {
                StartCoroutine(GameOverTimer());
            }
        }
        else
        {
            if((PlayerHealthSystem.P1currentHealth <= 0 && PlayerHealthSystem.P1currentShields <= 0 && PlayerHealthSystem.P1currentLives <= 0)
                && (PlayerHealthSystem.P2currentHealth <= 0 && PlayerHealthSystem.P2currentShields <= 0 && PlayerHealthSystem.P2currentLives <= 0))
            {
                StartCoroutine(GameOverTimer());
            }
        }

        if(winLevel)
        {
            StartCoroutine(ScoreScreenTimer());
        }
    }

    IEnumerator GameOverTimer()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("GameOver");
    }
    IEnumerator ScoreScreenTimer()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("ScoreScreen");
    }

    private void ActivatePauseMenu()
    {
        Time.timeScale = 0f;

        DeactivateHUD();

        pauseMenu.SetActive(true);
        resumeButton.SetActive(true);
        restartButton.SetActive(true);
        mainMenuButton.SetActive(true);
        player2Button.SetActive(true);
    }
    private void DeactivatePauseMenu()
    {
        Time.timeScale = 1f;

        ActivateHUD();

        pauseMenu.SetActive(false);
        resumeButton.SetActive(false);
        restartButton.SetActive(false);
        mainMenuButton.SetActive(false);
        player2Button.SetActive(false);
    }

    private void ActivateHUD()
    {
        if(MainMenuController.onePlayer)
        {
            P1HUD.SetActive(true);
        }
        else
        {
            P1HUD.SetActive(true);
            P2HUD.SetActive(true);
        }

        pauseText.SetActive(true);
    }
    private void DeactivateHUD()
    {
        P1HUD.SetActive(false);
        P2HUD.SetActive(false);
        pauseText.SetActive(false);
    }

    private void ResetPlayer1Value()
    {
        PlayerHealthSystem.P1currentLives = PlayerHealthSystem.P1maxLives;
        PlayerHealthSystem.P1currentHealth = PlayerHealthSystem.P1maxHealth;
        PlayerHealthSystem.P1currentShields = PlayerHealthSystem.P1maxShields;

        PlayerWeaponController.P1savedWeaponLevel = PlayerWeaponController.baseWLevel;
        PlayerWeaponController.P1savedSecondaryLevel = PlayerWeaponController.baseSecondaryLevel;
        PlayerWeaponController.P1savedSuperAmmo = PlayerWeaponController.superAmmoDefault;
    }
    private void ResetPlayer2Value()
    {
        PlayerHealthSystem.P2currentLives = PlayerHealthSystem.P2maxLives;
        PlayerHealthSystem.P2currentHealth = PlayerHealthSystem.P2maxHealth;
        PlayerHealthSystem.P2currentShields = PlayerHealthSystem.P2maxShields;

        PlayerWeaponController.P2savedWeaponLevel = PlayerWeaponController.baseWLevel;
        PlayerWeaponController.P2savedSecondaryLevel = PlayerWeaponController.baseSecondaryLevel;
        PlayerWeaponController.P2savedSuperAmmo = PlayerWeaponController.superAmmoDefault;
    }

    public void ResumeButton()
    {
        DeactivatePauseMenu();
        ActivateHUD();
        Time.timeScale = 1f;
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

        DeactivatePauseMenu();
        ActivateHUD();
        SceneManager.LoadScene("Level1");
    }

    public void MainMenuButton()
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

        DeactivatePauseMenu();
        DeactivateHUD();
        SceneManager.LoadScene("MainMenu");
    }

    public void Player2Button()
    {
        MainMenuController.onePlayer = false;

        ResetPlayer1Value();
        ResetPlayer2Value();
        DeactivatePauseMenu();

        SceneManager.LoadScene("SelectionMenu");
    }
}
