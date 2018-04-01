using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HangarMenuController : MonoBehaviour
{
    private bool P1warning;
    private bool P1verticalSelect;
    private bool P1healthCheck;
    private bool P1shieldCheck;
    private bool P1primaryCheck;
    private bool P1secondaryCheck;

    private int P1horizontalGlowTracker;
    private int P1verticalGlowTracker;
    private int P1toggleData;

    private bool P2warning;
    private bool P2versticalSelect;
    private bool P2healthCheck;
    private bool P2shieldCheck;
    private bool P2primaryCheck;
    private bool P2secondaryCheck;

    private int P2horizontalGlowTracker;
    private int P2verticalGlowTracker;
    private int P2toggleData;

    public Text P1Credit;
    public Text P2Credit;

    public Text P1WarningText;
    public Text P2WarningText;

    public GameObject P1Warning;
    public GameObject P2Warning;

    public GameObject restartButton;
    public GameObject nextButton;

    public GameObject restartButtonGlow;
    public GameObject nextButtonGlow;

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

    public GameObject P1menuHorizontal;
    public GameObject P1shipHorizontal;
    public GameObject P1primaryHorizontal;
    public GameObject P1secondaryHorizontal;
    public GameObject P1toggleLeft;
    public GameObject P1toggleRight;
    public GameObject P1shipGlowHorizontal;
    public GameObject P1primaryGlowHorizontal;
    public GameObject P1secondaryGlowHorizontal;
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

    public GameObject P2menuHorizontal;
    public GameObject P2shipHorizontal;
    public GameObject P2primaryHorizontal;
    public GameObject P2secondaryHorizontal;
    public GameObject P2toggleLeft;
    public GameObject P2toggleRight;
    public GameObject P2shipGlowHorizontal;
    public GameObject P2primaryGlowHorizontal;
    public GameObject P2secondaryGlowHorizontal;
    public GameObject P2toggleLeftGlow;
    public GameObject P2toggleRightGlow;

    public Animator P1healthStartingAnimation;
    public Animator P1shieldStartingAnimation;
    public Animator P1liveStartingAnimation;
    public Animator P1primaryStartingAnimation;
    public Animator P1secondaryStartingAnimation;
    public Animator P1specialStartingAnimation;

    public Animator P2healthStartingAnimation;
    public Animator P2shieldStartingAnimation;
    public Animator P2liveStartingAnimation;
    public Animator P2primaryStartingAnimation;
    public Animator P2secondaryStartingAnimation;
    public Animator P2specialStartingAnimation;

    public Animator P1Ships;
    public Animator P2Ships;

    private void Awake()
    {
        DeactivateButton();
        DeactivateButtonGlow();

        DeactivateP1Menu();
        DeactivateP1Glow();
        DeactivateP1Shader();
        DeactivateP1Ships();

        DeactivateP1HorizontalMenu();
        DeactivateP1HorizontalMenuGlow();
        DeactivateP1Toggle();
        DeactivateP1ToggleGlow();

        ResetP1ToggleData();
        ResetP1Warning();
        ResetP1Bool();

        DeactivateP1CreditText();
        DeactivateP1WarningPanel();

        DeactivateP2Menu();
        DeactivateP2Glow();
        DeactivateP2Shader();
        DeactivateP2Ships();

        DeactivateP2HorizontalMenu();
        DeactivateP2HorizontalMenuGlow();
        DeactivateP2Toggle();
        DeactivateP2ToggleGlow();

        ResetP2ToggleData();
        ResetP2Warning();
        ResetP2Bool();

        DeactivateP2CreditText();
        DeactivateP2WarningPanel();
    }

    private void Start()
    {
        StartCoroutine(Timer());
    }

    private void Update()
    {
        if (MainMenuController.onePlayer)
        {
            P1Credit.text = "Player 1 has: " + ScoreTracker.P1credit;
        }
        else
        {
            P1Credit.text = "Player 1 has: " + ScoreTracker.P1credit;
            P2Credit.text = "Player 2 has: " + ScoreTracker.P2credit;
        }
    }

    IEnumerator Timer()
    {
        if (MainMenuController.onePlayer)
        {
            SetPlayer1Value();

            ActivateButton();

            ActivateP1Toggle();
            P1toggleLeftGlow.SetActive(true);
            P1toggleRightGlow.SetActive(true);
            ActivateP1HorizontalMenu();
            ActivateP1HorizontalMenuGlow();

            P1menu.SetActive(true);
            P1menuHorizontal.SetActive(true);
        }
        else
        {
            SetPlayer1Value();
            SetPlayer2Value();

            ActivateButton();

            ActivateP1Toggle();
            P1toggleLeftGlow.SetActive(true);
            P1toggleRightGlow.SetActive(true);
            ActivateP1HorizontalMenu();
            ActivateP1HorizontalMenuGlow();

            ActivateP2Toggle();
            P2toggleLeftGlow.SetActive(true);
            P2toggleRightGlow.SetActive(true);
            ActivateP2HorizontalMenu();
            ActivateP2HorizontalMenuGlow();

            P1menu.SetActive(true);
            P1menuHorizontal.SetActive(true);

            P2menu.SetActive(true);
            P2menuHorizontal.SetActive(true);
        }
        
        yield return new WaitForSeconds(1f);

        if (MainMenuController.onePlayer)
        {
            ActivateP1Ships();
            P1Ships.SetBool("StartAnimation", true);
        }
        else
        {
            ActivateP1Ships();
            P1Ships.SetBool("StartAnimation", true);

            P1health.SetActive(true);
            P1healthStartingAnimation.SetBool("StartAnimation", true);

            ActivateP2Ships();
            P2Ships.SetBool("StartAnimation", true);

            P2health.SetActive(true);
            P2healthStartingAnimation.SetBool("StartAnimation", true);
        }

        yield return new WaitForSeconds(.5f);

        if (MainMenuController.onePlayer)
        {
            ActivateP1CreditText();

            P1shield.SetActive(true);
            P1shieldStartingAnimation.SetBool("StartAnimation", true);
        }
        else
        {
            ActivateP1CreditText();
            ActivateP2CreditText();

            P1shield.SetActive(true);
            P1shieldStartingAnimation.SetBool("StartAnimation", true);

            P2shield.SetActive(true);
            P2shieldStartingAnimation.SetBool("StartAnimation", true);
        }

        yield return new WaitForSeconds(.5f);

        if (MainMenuController.onePlayer)
        {
            P1live.SetActive(true);
            P1liveStartingAnimation.SetBool("StartAnimation", true);
        }
        else
        {
            P1live.SetActive(true);
            P1liveStartingAnimation.SetBool("StartAnimation", true);

            P2live.SetActive(true);
            P2liveStartingAnimation.SetBool("StartAnimation", true);
        }

        yield return new WaitForSeconds(.5f);

        if (MainMenuController.onePlayer)
        {
            P1primary.SetActive(true);
            P1primaryStartingAnimation.SetBool("StartAnimation", true);
        }
        else
        {
            P1primary.SetActive(true);
            P1primaryStartingAnimation.SetBool("StartAnimation", true);

            P2primary.SetActive(true);
            P2primaryStartingAnimation.SetBool("StartAnimation", true);
        }

        yield return new WaitForSeconds(.5f);

        if (MainMenuController.onePlayer)
        {
            P1secondary.SetActive(true);
            P1secondaryStartingAnimation.SetBool("StartAnimation", true);
        }
        else
        {
            P1secondary.SetActive(true);
            P1secondaryStartingAnimation.SetBool("StartAnimation", true);

            P2secondary.SetActive(true);
            P2secondaryStartingAnimation.SetBool("StartAnimation", true);
        }

        yield return new WaitForSeconds(.5f);

        if (MainMenuController.onePlayer)
        {
            DeactivateP1ToggleGlow();
            DeactivateP1Glow();

            P1special.SetActive(true);
            P1specialStartingAnimation.SetBool("StartAnimation", true);
        }
        else
        {
            DeactivateP1ToggleGlow();
            DeactivateP1HorizontalMenuGlow();

            P1special.SetActive(true);
            P1specialStartingAnimation.SetBool("StartAnimation", true);

            DeactivateP2ToggleGlow();
            DeactivateP2HorizontalMenuGlow();

            P2special.SetActive(true);
            P2specialStartingAnimation.SetBool("StartAnimation", true);
        }

        yield return new WaitForSeconds(.5f);

        if (MainMenuController.onePlayer)
        {
            P1shipGlowHorizontal.SetActive(true);
        }
        else
        {
            P1shipGlowHorizontal.SetActive(true);
            P2shipGlowHorizontal.SetActive(true);
        }
    }

    private void ActivateButton()
    {
        restartButton.SetActive(true);
        nextButton.SetActive(true);
    }
    private void DeactivateButton()
    {
        restartButton.SetActive(false);
        nextButton.SetActive(false);
    }

    private void DeactivateButtonGlow()
    {
        restartButtonGlow.SetActive(false);
        nextButtonGlow.SetActive(false);
    }

    private void ActivateP1Menu()
    {
        P1menu.SetActive(true);
        P1health.SetActive(true);
        P1shield.SetActive(true);
        P1live.SetActive(true);
        P1primary.SetActive(true);
        P1secondary.SetActive(true);
        P1special.SetActive(true);
    }
    private void DeactivateP1Menu()
    {
        P1menu.SetActive(false);
        P1health.SetActive(false);
        P1shield.SetActive(false);
        P1live.SetActive(false);
        P1primary.SetActive(false);
        P1secondary.SetActive(false);
        P1special.SetActive(false);
    }

    private void ActivateP2Menu()
    {
        P2menu.SetActive(true);
        P2health.SetActive(true);
        P2shield.SetActive(true);
        P2live.SetActive(true);
        P2primary.SetActive(true);
        P2secondary.SetActive(true);
        P2special.SetActive(true);
    }
    private void DeactivateP2Menu()
    {
        P2menu.SetActive(false);
        P2health.SetActive(false);
        P2shield.SetActive(false);
        P2live.SetActive(false);
        P2primary.SetActive(false);
        P2secondary.SetActive(false);
        P2special.SetActive(false);
    }

    private void DeactivateP1Glow()
    {
        P1healthGlow.SetActive(false);
        P1shieldGlow.SetActive(false);
        P1liveGlow.SetActive(false);
        P1primaryGlow.SetActive(false);
        P1secondaryGlow.SetActive(false);
        P1specialGlow.SetActive(false);
    }
    private void DeactivateP2Glow()
    {
        P2healthGlow.SetActive(false);
        P2shieldGlow.SetActive(false);
        P2liveGlow.SetActive(false);
        P2primaryGlow.SetActive(false);
        P2secondaryGlow.SetActive(false);
        P2specialGlow.SetActive(false);
    }

    private void DeactivateP1Shader()
    {
        P1healthShader.SetActive(false);
        P1shieldShader.SetActive(false);
        P1liveShader.SetActive(false);
        P1primaryShader.SetActive(false);
        P1secondaryShader.SetActive(false);
        P1specialShader.SetActive(false);
    }
    private void DeactivateP2Shader()
    {
        P2healthShader.SetActive(false);
        P2shieldShader.SetActive(false);
        P2liveShader.SetActive(false);
        P2primaryShader.SetActive(false);
        P2secondaryShader.SetActive(false);
        P2specialShader.SetActive(false);
    }

    private void ActivateP1Ships()
    {
        if(SelectionMenuController.P1shipType == 1)
        {
            P1ship1.SetActive(true);
        }
        if (SelectionMenuController.P1shipType == 2)
        {
            P1ship2.SetActive(true);
        }
        if (SelectionMenuController.P1shipType == 3)
        {
            P1ship3.SetActive(true);
        }
        if (SelectionMenuController.P1shipType == 4)
        {
            P1ship4.SetActive(true);
        }
        if (SelectionMenuController.P1shipType == 5)
        {
            P1ship5.SetActive(true);
        }
    }
    private void DeactivateP1Ships()
    {
        P1ship1.SetActive(false);
        P1ship2.SetActive(false);
        P1ship3.SetActive(false);
        P1ship4.SetActive(false);
        P1ship5.SetActive(false);
    }

    private void ActivateP2Ships()
    {
        //if (SelectionMenuController.P2shipType == 1)
        //{
            P2ship1.SetActive(true);
        //}
        if (SelectionMenuController.P2shipType == 2)
        {
            P2ship2.SetActive(true);
        }
        if (SelectionMenuController.P2shipType == 3)
        {
            P2ship3.SetActive(true);
        }
        if (SelectionMenuController.P2shipType == 4)
        {
            P2ship4.SetActive(true);
        }
        if (SelectionMenuController.P2shipType == 5)
        {
            P2ship5.SetActive(true);
        }
    }
    private void DeactivateP2Ships()
    {
        P2ship1.SetActive(false);
        P2ship2.SetActive(false);
        P2ship3.SetActive(false);
        P2ship4.SetActive(false);
        P2ship5.SetActive(false);
    }

    private void ActivateP1HorizontalMenu()
    {
        P1menuHorizontal.SetActive(true);
        P1shipHorizontal.SetActive(true);
        P1primaryHorizontal.SetActive(true);
        P1secondaryHorizontal.SetActive(true);
    }
    private void DeactivateP1HorizontalMenu()
    {
        P1menuHorizontal.SetActive(false);
        P1shipHorizontal.SetActive(false);
        P1primaryHorizontal.SetActive(false);
        P1secondaryHorizontal.SetActive(false);
    }

    private void ActivateP2HorizontalMenu()
    {
        P2menuHorizontal.SetActive(true);
        P2shipHorizontal.SetActive(true);
        P2primaryHorizontal.SetActive(true);
        P2secondaryHorizontal.SetActive(true);
    }
    private void DeactivateP2HorizontalMenu()
    {
        P2menuHorizontal.SetActive(false);
        P2shipHorizontal.SetActive(false);
        P2primaryHorizontal.SetActive(false);
        P2secondaryHorizontal.SetActive(false);
    }

    private void ActivateP1HorizontalMenuGlow()
    {
        P1shipGlowHorizontal.SetActive(true);
        P1primaryGlowHorizontal.SetActive(true);
        P1secondaryGlowHorizontal.SetActive(true);
    }
    private void DeactivateP1HorizontalMenuGlow()
    {
        P1shipGlowHorizontal.SetActive(false);
        P1primaryGlowHorizontal.SetActive(false);
        P1secondaryGlowHorizontal.SetActive(false);
    }

    private void ActivateP2HorizontalMenuGlow()
    {
        P2shipGlowHorizontal.SetActive(true);
        P2primaryGlowHorizontal.SetActive(true);
        P2secondaryGlowHorizontal.SetActive(true);
    }
    private void DeactivateP2HorizontalMenuGlow()
    {
        P2shipGlowHorizontal.SetActive(false);
        P2primaryGlowHorizontal.SetActive(false);
        P2secondaryGlowHorizontal.SetActive(false);
    }

    private void ActivateP1Toggle()
    {
        P1toggleLeft.SetActive(true);
        P1toggleRight.SetActive(true);
    }
    private void DeactivateP1Toggle()
    {
        P1toggleLeft.SetActive(false);
        P1toggleRight.SetActive(false);
    }

    private void ActivateP2Toggle()
    {
        P2toggleLeft.SetActive(true);
        P2toggleRight.SetActive(true);
    }
    private void DeactivateP2Toggle()
    {
        P2toggleLeft.SetActive(false);
        P2toggleRight.SetActive(false);
    }
    
    private void DeactivateP1ToggleGlow()
    {
        P1toggleLeftGlow.SetActive(false);
        P1toggleRightGlow.SetActive(false);
    }
    private void DeactivateP2ToggleGlow()
    {
        P2toggleLeftGlow.SetActive(false);
        P2toggleRightGlow.SetActive(false);
    }

    private void ActivateP1WarningPanel()
    {
        P1Warning.SetActive(true);
    }
    private void DeactivateP1WarningPanel()
    {
        P1Warning.SetActive(false);
    }

    private void ActivateP2WarningPanel()
    {
        P2Warning.SetActive(true);
    }
    private void DeactivateP2WarningPanel()
    {
        P2Warning.SetActive(false);
    }

    private void ActivateP1CreditText()
    {
        P1Credit.enabled = true;
    }
    private void DeactivateP1CreditText()
    {
        P1Credit.enabled = false;
    }

    private void ActivateP2CreditText()
    {
        P2Credit.enabled = true;
    }
    private void DeactivateP2CreditText()
    {
        P2Credit.enabled = false;
    }

    private void ResetP1ToggleData()
    {
        P1toggleData = 1;
    }
    private void ResetP2ToggleData()
    {
        P2toggleData = 1;
    }

    private void ResetP1Warning()
    {
        P1warning = false;
    }
    private void ResetP2Warning()
    {
        P2warning = false;
    }

    private void ResetP1Bool()
    {
        P1healthCheck = false;
        P1shieldCheck = false;
        P1primaryCheck = false;
        P1secondaryCheck = false;
    }
    private void ResetP2Bool()
    {
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
    }

    private void ResetPlayerCredit()
    {
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
        ResetPlayerScore();
        ResetPlayerCredit();

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
        ResetPlayerScore();

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
