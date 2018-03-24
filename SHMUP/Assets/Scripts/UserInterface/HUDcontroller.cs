using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HUDcontroller : MonoBehaviour
{
    private int glowTracker;
    private bool pauseMenuOn;

    public Image resumeGlow;
    public Image restartGlow;
    public Image mainMenuGlow;
    public Image player2Glow;

    public GameObject P1HUD;
    public GameObject P2HUD;

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
        pauseMenuOn = false;
        glowTracker = 1;
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

        if (pauseMenuOn)
        {
            if (glowTracker <= 1)
            {
                glowTracker = 1;

                DeactivateGlow();
                resumeGlow.fillAmount = 1;
            }
            if (glowTracker == 2)
            {
                DeactivateGlow();
                restartGlow.fillAmount = 1;
            }
            if (glowTracker == 3)
            {
                DeactivateGlow();
                mainMenuGlow.fillAmount = 1;
            }
            if (glowTracker >= 4)
            {
                glowTracker = 4;

                DeactivateGlow();
                player2Glow.fillAmount = 1;
            }

            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.Alpha8) || Input.GetKeyDown(KeyCode.Alpha4))
            {
                glowTracker--;
            }
            if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.Alpha5) || Input.GetKeyDown(KeyCode.Alpha6))
            {
                glowTracker++;
            }

            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Alpha0))
            {
                if (glowTracker <= 1)
                {
                    ResumeButton();
                }
                if (glowTracker == 2)
                {
                    RestartButton();
                }
                if (glowTracker == 3)
                {
                    MainMenuButton();
                }
                if (glowTracker == 4)
                {
                    Player2Button();
                }

                glowTracker = 1;
            }
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

    private void DeactivateGlow()
    {
        resumeGlow.fillAmount = 0;
        restartGlow.fillAmount = 0;
        mainMenuGlow.fillAmount = 0;
        player2Glow.fillAmount = 0;
    }

    private void ActivatePauseMenu()
    {
        Time.timeScale = 0f;
        pauseMenuOn = true;

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
        pauseMenuOn = false;

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
    }
    private void DeactivateHUD()
    {
        P1HUD.SetActive(false);
        P2HUD.SetActive(false);
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

    private void ResumeButton()
    {
        DeactivatePauseMenu();
        ActivateHUD();

        Time.timeScale = 1f;
    }

    private void RestartButton()
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

    private void MainMenuButton()
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

    private void Player2Button()
    {
        MainMenuController.onePlayer = false;

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

        SceneManager.LoadScene("SelectionMenu");
    }
}
