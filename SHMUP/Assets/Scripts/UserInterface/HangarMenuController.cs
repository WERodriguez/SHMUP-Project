using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HangarMenuController : MonoBehaviour
{
    private bool P1warning;
    private bool P1verticalSelect;
    private int P1horizontalGlowTracker;
    private int P1verticalGlowTracker;

    private bool P2warning;
    private bool P2versticalSelect;
    private int P2horizontalGlowTracker;
    private int P2verticalGlowTracker;

    private bool P1healthCheck;
    private bool P1shieldCheck;
    private bool P1primaryCheck;
    private bool P1secondaryCheck;

    private bool P2healthCheck;
    private bool P2shieldCheck;
    private bool P2primaryCheck;
    private bool P2secondaryCheck;

    public Text P1Credit;
    public Text P2Credit;

    public Text P1WarningText;
    public Text P2WarningText;

    public GameObject P1Warning;
    public GameObject P2Warning;

    public GameObject restartButton;
    public GameObject nextButton;

    public GameObject P1menu;
    public GameObject P1health;
    public GameObject P1shield;
    public GameObject P1live;
    public GameObject P1primary;
    public GameObject P1secondary;
    public GameObject P1special;
    public GameObject P1healthShader;
    public GameObject P1shieldShader;
    public GameObject P1liveShader;
    public GameObject P1primaryShader;
    public GameObject P1secondaryShader;
    public GameObject P1specialShader;
    public GameObject P1healthGlow;
    public GameObject P1shieldGlow;
    public GameObject P1liveGlow;
    public GameObject P1primaryGlow;
    public GameObject P1secondaryGlow;
    public GameObject P1specialGlow;
    
    public GameObject P1ship1;
    public GameObject P1ship2;
    public GameObject P1ship3;
    public GameObject P1ship4;
    public GameObject P1ship5;

    public GameObject P1beamCannon;

    public GameObject P1menuHorizontal;
    public GameObject P1shipHorizontal;
    public GameObject P1primaryHorizontal;
    public GameObject P1secondaryHorizontal;
    public GameObject P1specialHorizontal;
    public GameObject P1toggleLeft;
    public GameObject P1toggleRight;
    public GameObject P1shipGlowHorizontal;
    public GameObject P1primaryGlowHorizontal;
    public GameObject P1secondaryGlowHorizontal;
    public GameObject P1specialGlowHorizontal;
    public GameObject P1toggleLeftGlow;
    public GameObject P1toggleRightGlow;

    public GameObject P2menu;
    public GameObject P2health;
    public GameObject P2shield;
    public GameObject P2live;
    public GameObject P2primary;
    public GameObject P2secondary;
    public GameObject P2special;
    public GameObject P2healthShader;
    public GameObject P2shieldShader;
    public GameObject P2liveShader;
    public GameObject P2primaryShader;
    public GameObject P2secondaryShader;
    public GameObject P2specialShader;
    public GameObject P2healthGlow;
    public GameObject P2shieldGlow;
    public GameObject P2liveGlow;
    public GameObject P2primaryGlow;
    public GameObject P2secondaryGlow;
    public GameObject P2specialGlow;

    public GameObject P2ship1;
    public GameObject P2ship2;
    public GameObject P2ship3;
    public GameObject P2ship4;
    public GameObject P2ship5;

    public GameObject P2beamCannon;

    public GameObject P2menuHorizontal;
    public GameObject P2shipHorizontal;
    public GameObject P2primaryHorizontal;
    public GameObject P2secondaryHorizontal;
    public GameObject P2specialHorizontal;
    public GameObject P2toggleLeft;
    public GameObject P2toggleRight;
    public GameObject P2shipGlowHorizontal;
    public GameObject P2primaryGlowHorizontal;
    public GameObject P2secondaryGlowHorizontal;
    public GameObject P2specialGlowHorizontal;
    public GameObject P2toggleLeftGlow;
    public GameObject P2toggleRightGlow;

    private void Awake()
    {
    }

    private void Start()
    {
    }

    private void Update()
    {
        if (MainMenuController.onePlayer)
        {
            P1Credit.text = "Player 1 has: " + ScoreTracker.P1credit;
        }
        if (!MainMenuController.onePlayer)
        {
            P1Credit.text = "Player 1 has: " + ScoreTracker.P1credit;
            P2Credit.text = "Player 2 has: " + ScoreTracker.P2credit;
        }
    }

    private void SetBool()
    {
        P1healthCheck = false;
        P1shieldCheck = false;
        P1primaryCheck = false;
        P1secondaryCheck = false;

        P2healthCheck = false;
        P2shieldCheck = false;
        P2primaryCheck = false;
        P2secondaryCheck = false;
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
        PlayerHealthSystem.P1currentHealth = PlayerHealthSystem.P1maxShields;
        PlayerHealthSystem.P1currentShields = PlayerHealthSystem.P1maxHealth;
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

    private void SetPlayer1Value()
    {
        PlayerHealthSystem.P1savedHealth = PlayerHealthSystem.P1currentHealth;
        PlayerHealthSystem.P1savedShields = PlayerHealthSystem.P1currentShields;
        PlayerHealthSystem.P1savedLives = PlayerHealthSystem.P1currentLives;

        PlayerWeaponController.P1savedWeaponLevel = PlayerWeaponController.P1currentWLevel;
        PlayerWeaponController.P1savedSecondaryLevel = PlayerWeaponController.P1currentSecondaryLevel;
        PlayerWeaponController.P1savedSuperAmmo = PlayerWeaponController.P1currentSuperAmmo;
    }
    private void SetPlayer2Value()
    {
        PlayerHealthSystem.P2savedHealth = PlayerHealthSystem.P2currentHealth;
        PlayerHealthSystem.P2savedShields = PlayerHealthSystem.P2currentShields;
        PlayerHealthSystem.P2savedLives = PlayerHealthSystem.P2currentLives;

        PlayerWeaponController.P2savedWeaponLevel = PlayerWeaponController.P2currentWLevel;
        PlayerWeaponController.P2savedSecondaryLevel = PlayerWeaponController.P2currentSecondaryLevel;
        PlayerWeaponController.P2savedSuperAmmo = PlayerWeaponController.P2currentSuperAmmo;
    }
    
    public void RestartButton()
    {
        MainMenuController.currentStage--;

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

    public void NextButton()
    {
        if (MainMenuController.onePlayer)
        {
            SetPlayer1Value();
        }
        else
        {
            SetPlayer1Value();
            SetPlayer2Value();
        }

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
}
