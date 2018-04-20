using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HUDcontroller : MonoBehaviour
{
    public static bool pauseMenuOn;
    public static bool changePlayer2Sprite;

    private int glowTracker;
    private int maxGlowTracker;
    private int choosingPlayer2Vertical;
    private int choosingPlayer2Horizontal;
    private int maxP2GLowTracker;
    private bool addingPlayer2;
    private bool addingMenu;

    private bool character;
    private bool ship;
    private bool primary;
    private bool secondary;
    private bool special;

    public Image resumeGlow;
    public Image restartGlow;
    public Image mainMenuGlow;
    public Image player2Glow;

    public Image P2returnButtonGlow;
    public Image P2startButtonGlow;
    public Image P2toggleLeftGlow;
    public Image P2toggleRightGlow;

    public Image P2characterButtonGlow;
    public Image P2shipButtonGlow;
    public Image P2primaryButtonGlow;
    public Image P2secondaryButtonGlow;
    public Image P2specialButtonGlow;

    public Image characterChoice;
    public Image shipChoice;
    public Image weaponChoice;
    public Image stat;

    public Sprite character1;
    public Sprite character2;
    public Sprite character3;
    public Sprite character4;

    public Sprite ship1;
    public Sprite ship2;
    public Sprite ship3;
    public Sprite ship4;
    public Sprite ship5;

    public Sprite primary1;
    public Sprite primary2;
    public Sprite primary3;

    public Sprite secondary1;
    public Sprite secondary2;
    public Sprite secondary3;

    public Sprite special1;
    public Sprite special2;
    public Sprite special3;

    public Sprite ship1Stat;
    public Sprite ship2Stat;
    public Sprite ship3Stat;
    public Sprite ship4Stat;
    public Sprite ship5Stat;

    public Sprite primary1Stat;
    public Sprite primary2Stat;
    public Sprite primary3Stat;

    public Sprite secondary1Stat;
    public Sprite secondary2Stat;
    public Sprite secondary3Stat;

    public Sprite special1Stat;
    public Sprite special2Stat;
    public Sprite special3Stat;

    public GameObject P1HUD;
    public GameObject P2HUD;

    public GameObject pauseMenu;
    public GameObject resumeButton;
    public GameObject restartButton;
    public GameObject mainMenuButton;
    public GameObject player2Button;

    public GameObject addingPlayer2Canvas;

    public GameObject P2returnButton;
    public GameObject P2startButton;

    public GameObject P2characterButton;
    public GameObject P2shipButton;
    public GameObject P2primaryButton;
    public GameObject P2secondaryButton;
    public GameObject P2specialButton;
    public GameObject P2characterButtonShader;
    public GameObject P2shipButtonShader;
    public GameObject P2primaryButtonShader;
    public GameObject P2secondaryButtonShader;
    public GameObject P2specialButtonShader;

    public GameObject P2toggleLeft;
    public GameObject P2toggleRight;

    public GameObject P2ship1;
    public GameObject P2ship2;
    public GameObject P2ship3;
    public GameObject P2ship4;
    public GameObject P2ship5;

    private GameObject player2CurrentShip;

    public Text P2characterText;

    public static bool winLevel;

    private void Start()
    {
        DeactivateHUD();
        DeactivatePauseMenu();
        DeactivateAddingVerticalCanvas();
        DeactivateAddingVerticalButton();
        DeactivateAddingVerticalChoices();
        DeactivateAddingHorizontal();
        DeactivateAddingVerticalGlow();
        DeactivateAddingHorizontalGlow();
        DeactivateAddingShader();

        SetBool();
        SetAddingBool();
        ResetPauseMenuGlow();
        ResetAddingGlow();

        maxP2GLowTracker = 6;
        maxGlowTracker = 4;
    }

    private void Update()
    {
        if (pauseMenuOn)
        {
            if (!addingPlayer2)
            {
                if (!MainMenuController.onePlayer)
                {
                    maxGlowTracker = 3;
                    player2Button.SetActive(false);
                }
                if (glowTracker > maxGlowTracker)
                {
                    glowTracker = maxGlowTracker;
                }
                
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

                if (Input.GetButtonDown("P1HorizontalChoiceLeft") || Input.GetButtonDown("P2HorizontalChoiceLeft") || Input.GetKeyDown(KeyCode.Keypad8) || Input.GetKeyDown(KeyCode.Keypad4))
                {
                    glowTracker--;
                }
                if (Input.GetButtonDown("P1HorizontalChoiceRight") || Input.GetButtonDown("P2HorizontalChoiceRight") || Input.GetKeyDown(KeyCode.Keypad5) || Input.GetKeyDown(KeyCode.Keypad6))
                {
                    glowTracker++;
                }

                if (Input.GetButtonDown("Fire_P1") || Input.GetButtonDown("Fire_P2") || Input.GetKeyDown(KeyCode.Keypad0))
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
            else
            {
                if(addingMenu)
                {
                    if(SelectionMenuController.P2characterType > 0 && SelectionMenuController.P2shipType > 0 && SelectionMenuController.P2primaryType > 0 && SelectionMenuController.P2secondaryType > 0 && SelectionMenuController.P2specialType > 0)
                    {
                        maxP2GLowTracker = 7;
                        P2startButton.SetActive(true);
                    }
                    if (choosingPlayer2Vertical > maxP2GLowTracker)
                    {
                        choosingPlayer2Vertical = maxP2GLowTracker;
                    }

                    if (choosingPlayer2Vertical <= 1)
                    {
                        choosingPlayer2Vertical = 1;

                        DeactivateAddingVerticalGlow();
                        P2returnButtonGlow.fillAmount = 1;
                    }
                    if (choosingPlayer2Vertical == 2)
                    {
                        DeactivateAddingVerticalGlow();
                        P2characterButtonGlow.fillAmount = 1;
                    }
                    if (choosingPlayer2Vertical == 3)
                    {
                        DeactivateAddingVerticalGlow();
                        P2shipButtonGlow.fillAmount = 1;
                    }
                    if (choosingPlayer2Vertical == 4)
                    {
                        DeactivateAddingVerticalGlow();
                        P2primaryButtonGlow.fillAmount = 1;
                    }
                    if (choosingPlayer2Vertical == 5)
                    {
                        DeactivateAddingVerticalGlow();
                        P2secondaryButtonGlow.fillAmount = 1;
                    }
                    if (choosingPlayer2Vertical == 6)
                    {
                        DeactivateAddingVerticalGlow();
                        P2specialButtonGlow.fillAmount = 1;
                    }
                    if (choosingPlayer2Vertical >= 7)
                    {
                        choosingPlayer2Vertical = 7;

                        DeactivateAddingVerticalGlow();
                        P2startButtonGlow.fillAmount = 1;
                    }

                    if (Input.GetButtonDown("P2VerticalChoiceUp") || Input.GetKeyDown(KeyCode.Keypad8))
                    {
                        choosingPlayer2Vertical--;
                    }
                    if (Input.GetButtonDown("P2VerticalChoiceDown") || Input.GetKeyDown(KeyCode.Keypad5))
                    {
                        choosingPlayer2Vertical++;
                    }

                    if (Input.GetButtonDown("Fire_P2") || Input.GetKeyDown(KeyCode.Keypad0))
                    {
                        if (choosingPlayer2Vertical == 1)
                        {
                            MainMenuController.onePlayer = true;

                            addingPlayer2 = false;
                            addingMenu = false;

                            ActivatePauseMenu();
                            DeactivateAddingVerticalButton();
                            DeactivateAddingVerticalCanvas();
                            DeactivateAddingVerticalChoices();
                            DeactivateAddingVerticalGlow();
                            ResetAddingGlow();
                            ResetPauseMenuGlow();
                            ResetPlayer2Choices();
                            ResetPlayer2Data();
                        }
                        if (choosingPlayer2Vertical == 2)
                        {
                            addingMenu = false;

                            SetAddingBool();
                            character = true;

                            DeactivateAddingVerticalButton();
                            DeactivateAddingVerticalChoices();
                            ActivateAddingHorizontal();

                            P2characterButton.SetActive(true);
                        }
                        if (choosingPlayer2Vertical == 3)
                        {
                            addingMenu = false;

                            SetAddingBool();
                            ship = true;

                            DeactivateAddingVerticalButton();
                            DeactivateAddingVerticalChoices();
                            ActivateAddingHorizontal();

                            P2shipButton.SetActive(true);
                        }
                        if (choosingPlayer2Vertical == 4)
                        {
                            addingMenu = false;

                            SetAddingBool();
                            primary = true;

                            DeactivateAddingVerticalButton();
                            DeactivateAddingVerticalChoices();
                            ActivateAddingHorizontal();

                            P2primaryButton.SetActive(true);
                        }
                        if (choosingPlayer2Vertical == 5)
                        {
                            addingMenu = false;

                            SetAddingBool();
                            secondary= true;

                            DeactivateAddingVerticalButton();
                            DeactivateAddingVerticalChoices();
                            ActivateAddingHorizontal();

                            P2secondaryButton.SetActive(true);
                        }
                        if (choosingPlayer2Vertical == 6)
                        {
                            addingMenu = false;

                            SetAddingBool();
                            special = true;

                            DeactivateAddingVerticalButton();
                            DeactivateAddingVerticalChoices();
                            ActivateAddingHorizontal();

                            P2specialButton.SetActive(true);
                        }
                        if (choosingPlayer2Vertical == 7)
                        {
                            MainMenuController.onePlayer = false;
                            addingPlayer2 = false;
                            changePlayer2Sprite = true;
                            addingMenu = false;
                            pauseMenuOn = false;

                            ActivateHUD();
                            DeactivateAddingVerticalButton();
                            DeactivateAddingVerticalCanvas();
                            DeactivateAddingVerticalChoices();
                            DeactivateAddingVerticalGlow();
                            ResetAddingGlow();
                            ResetPauseMenuGlow();

                            CheckPlayer2Ship();
                            Invoke("SpawnPlayer2", 0f);

                            Time.timeScale = 1f;
                        }
                    }
                }
                else
                {
                    if (choosingPlayer2Horizontal <= 1)
                    {
                        choosingPlayer2Horizontal = 1;

                        CheckSprite();
                    }
                    if (choosingPlayer2Horizontal == 2)
                    {
                        CheckSprite();
                    }
                    if (choosingPlayer2Horizontal == 3)
                    {
                        CheckSprite();
                    }
                    if (choosingPlayer2Horizontal == 4)
                    {
                        if(primary || secondary || special)
                        {
                            choosingPlayer2Horizontal = 3;
                        }

                        CheckSprite();
                    }
                    if (choosingPlayer2Horizontal >= 5)
                    {
                        choosingPlayer2Horizontal = 5;

                        if (character)
                        {
                            choosingPlayer2Horizontal = 4;
                        }
                        if (primary || secondary || special)
                        {
                            choosingPlayer2Horizontal = 3;
                        }

                        CheckSprite();
                    }

                    if (Input.GetButtonDown("P2HorizontalChoiceLeft") || Input.GetKeyDown(KeyCode.Keypad4))
                    {
                        DeactivateAddingHorizontalGlow();
                        P2toggleLeftGlow.fillAmount = 1;

                        choosingPlayer2Horizontal++;
                    }
                    if (Input.GetButtonDown("P2HorizontalChoiceRight") || Input.GetKeyDown(KeyCode.Keypad6))
                    {
                        DeactivateAddingHorizontalGlow();
                        P2toggleRightGlow.fillAmount = 1;

                        choosingPlayer2Horizontal--;
                    }

                    if (Input.GetButtonDown("Fire_P2") || Input.GetKeyDown(KeyCode.Keypad0))
                    {
                        if (choosingPlayer2Horizontal == 1)
                        {
                            if(character)
                            {
                                SelectionMenuController.P2characterType = 1;
                                P2characterButtonShader.SetActive(true);
                            }
                            if(ship)
                            {
                                SelectionMenuController.P2shipType = 1;
                                P2shipButtonShader.SetActive(true);
                            }
                            if (primary)
                            {
                                SelectionMenuController.P2primaryType = 1;
                                P2primaryButtonShader.SetActive(true);
                            }
                            if(secondary)
                            {
                                SelectionMenuController.P2secondaryType = 1;
                                P2secondaryButtonShader.SetActive(true);
                            }
                            if(special)
                            {
                                SelectionMenuController.P2specialType = 1;
                                P2specialButtonShader.SetActive(true);
                            }
                        }
                        if (choosingPlayer2Horizontal == 2)
                        {
                            if (character)
                            {
                                SelectionMenuController.P2characterType = 2;
                                P2characterButtonShader.SetActive(true);
                            }
                            if (ship)
                            {
                                SelectionMenuController.P2shipType = 2;
                                P2shipButtonShader.SetActive(true);
                            }
                            if (primary)
                            {
                                SelectionMenuController.P2primaryType = 2;
                                P2primaryButtonShader.SetActive(true);
                            }
                            if (secondary)
                            {
                                SelectionMenuController.P2secondaryType = 2;
                                P2secondaryButtonShader.SetActive(true);
                            }
                            if (special)
                            {
                                SelectionMenuController.P2specialType = 2;
                                P2specialButtonShader.SetActive(true);
                            }
                        }
                        if (choosingPlayer2Horizontal == 3)
                        {
                            if (character)
                            {
                                SelectionMenuController.P2characterType = 3;
                                P2characterButtonShader.SetActive(true);
                            }
                            if (ship)
                            {
                                SelectionMenuController.P2shipType = 3;
                                P2shipButtonShader.SetActive(true);
                            }
                            if (primary)
                            {
                                SelectionMenuController.P2primaryType = 3;
                                P2primaryButtonShader.SetActive(true);
                            }
                            if (secondary)
                            {
                                SelectionMenuController.P2secondaryType = 3;
                                P2secondaryButtonShader.SetActive(true);
                            }
                            if (special)
                            {
                                SelectionMenuController.P2specialType = 3;
                                P2specialButtonShader.SetActive(true);
                            }
                        }
                        if (choosingPlayer2Horizontal == 4)
                        {
                            if (character)
                            {
                                SelectionMenuController.P2characterType = 4;
                                P2characterButtonShader.SetActive(true);
                            }
                            if (ship)
                            {
                                SelectionMenuController.P2shipType = 4;
                                P2shipButtonShader.SetActive(true);
                            }
                        }
                        if (choosingPlayer2Horizontal == 5)
                        {
                            if (ship)
                            {
                                SelectionMenuController.P2shipType = 5;
                                P2shipButtonShader.SetActive(true);
                            }
                        }

                        DeactivateAddingHorizontal();
                        ActivateAddingVerticalButton();
                        ActivateAddingVerticalChoices();

                        addingMenu = true;
                        choosingPlayer2Horizontal = 1;
                    }
                }
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.P))
            {
                ActivatePauseMenu();
            }

            if (MainMenuController.onePlayer)
            {
                if (PlayerHealthSystem.P1currentHealth <= 0 && PlayerHealthSystem.P1currentShields <= 0 && PlayerHealthSystem.P1currentLives < 0)
                {
                    StartCoroutine(GameOverTimer());
                }
            }
            else
            {
                if ((PlayerHealthSystem.P1currentHealth <= 0 && PlayerHealthSystem.P1currentShields <= 0 && PlayerHealthSystem.P1currentLives < 0)
                    && (PlayerHealthSystem.P2currentHealth <= 0 && PlayerHealthSystem.P2currentShields <= 0 && PlayerHealthSystem.P2currentLives < 0))
                {
                    StartCoroutine(GameOverTimer());
                }
            }

            if (winLevel)
            {
                StartCoroutine(ScoreScreenTimer());
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

    private void SetBool()
    {
        winLevel = false;
        pauseMenuOn = false;
        addingPlayer2 = false;
        changePlayer2Sprite = false;
        addingMenu = false;
    }
    private void SetAddingBool()
    {
        character = false;
        ship = false;
        primary = false;
        secondary = false;
        special = false;
    }

    private void ResetPauseMenuGlow()
    {
        glowTracker = 1;
    }
    private void ResetAddingGlow()
    {
        choosingPlayer2Vertical = 1;
        choosingPlayer2Horizontal = 1;
    }

    private void DeactivateGlow()
    {
        resumeGlow.fillAmount = 0;
        restartGlow.fillAmount = 0;
        mainMenuGlow.fillAmount = 0;
        player2Glow.fillAmount = 0;
    }

    private void ActivateAddingVerticalCanvas()
    {
        addingPlayer2Canvas.SetActive(true);
        P2returnButton.SetActive(true);
    }
    private void DeactivateAddingVerticalCanvas()
    {
        addingPlayer2Canvas.SetActive(false);
        P2returnButton.SetActive(false);
        P2startButton.SetActive(false);
    }

    private void ActivateAddingVerticalButton()
    {
        P2returnButton.SetActive(true);
    }
    private void DeactivateAddingVerticalButton()
    {
        P2returnButton.SetActive(false);
        P2startButton.SetActive(false);
    }

    private void ActivateAddingVerticalChoices()
    {
        P2characterButton.SetActive(true);
        P2shipButton.SetActive(true);
        P2primaryButton.SetActive(true);
        P2secondaryButton.SetActive(true);
        P2specialButton.SetActive(true);
    }
    private void DeactivateAddingVerticalChoices()
    {
        P2characterButton.SetActive(false);
        P2shipButton.SetActive(false);
        P2primaryButton.SetActive(false);
        P2secondaryButton.SetActive(false);
        P2specialButton.SetActive(false);
    }

    private void ActivateAddingHorizontal()
    {
        P2toggleLeft.SetActive(true);
        P2toggleRight.SetActive(true);
    }
    private void DeactivateAddingHorizontal()
    {
        P2toggleLeft.SetActive(false);
        P2toggleRight.SetActive(false);

        characterChoice.enabled = false;
        shipChoice.enabled = false;
        weaponChoice.enabled = false;
        stat.enabled = false;
        P2characterText.enabled = false;
    }

    private void DeactivateAddingVerticalGlow()
    {
        P2returnButtonGlow.fillAmount = 0;
        P2characterButtonGlow.fillAmount = 0;
        P2shipButtonGlow.fillAmount = 0;
        P2primaryButtonGlow.fillAmount = 0;
        P2secondaryButtonGlow.fillAmount = 0;
        P2specialButtonGlow.fillAmount = 0;
        P2startButtonGlow.fillAmount = 0;
    }
    private void DeactivateAddingHorizontalGlow()
    {
        P2toggleLeftGlow.fillAmount = 0;
        P2toggleRightGlow.fillAmount = 0;
    }

    private void DeactivateAddingShader()
    {
        P2characterButtonShader.SetActive(false);
        P2shipButtonShader.SetActive(false);
        P2primaryButtonShader.SetActive(false);
        P2secondaryButtonShader.SetActive(false);
        P2specialButtonShader.SetActive(false);
    }

    private void ActivatePauseMenu()
    {
        pauseMenuOn = true;
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

    private void ResetType()
    {
        SelectionMenuController.P1characterType = 0;
        SelectionMenuController.P1shipType = 0;
        SelectionMenuController.P1primaryType = 0;
        SelectionMenuController.P1secondaryType = 0;
        SelectionMenuController.P1specialType = 0;

        SelectionMenuController.P2characterType = 0;
        SelectionMenuController.P2shipType = 0;
        SelectionMenuController.P2primaryType = 0;
        SelectionMenuController.P2secondaryType = 0;
        SelectionMenuController.P2specialType = 0;
    }

    private void ResetPlayer2Choices()
    {
        SelectionMenuController.P2characterType = 0;
        SelectionMenuController.P2shipType = 0;
        SelectionMenuController.P1primaryType = 0;
        SelectionMenuController.P1secondaryType = 0;
        SelectionMenuController.P2specialType = 0;
    }
    private void ResetPlayer2Data()
    {
        PlayerHealthSystem.P2currentLives = 0;
        PlayerHealthSystem.P2currentHealth = 0;
        PlayerHealthSystem.P2currentShields = 0;

        PlayerWeaponController.P2savedWeaponLevel = 0;
        PlayerWeaponController.P2savedSecondaryLevel = 0;
        PlayerWeaponController.P2savedSuperAmmo = 0;
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

    private void ResetPlayerScore()
    {
        ScoreTracker.score_P1 = 0;
        ScoreTracker.score_P2 = 0;
        ScoreTracker.totalScore = 0;
        ScoreTracker.P1credit = 0;
        ScoreTracker.P2credit = 0;
    }

    private void CheckSprite()
    {
        if (character)
        {
            if(choosingPlayer2Horizontal == 1)
            {
                characterChoice.sprite = character1;

                P2characterText.text = "Name: Sparky\nDescription: Truck driver turned toaster hunter after losing her truck";
            }
            if (choosingPlayer2Horizontal == 2)
            {
                characterChoice.sprite = character2;

                P2characterText.text = "Name: Nomad\nDescription: A confident, hotshot pilot that hunts the machine menace wherever it goes.";
            }
            if (choosingPlayer2Horizontal == 3)
            {
                characterChoice.sprite = character3;

                P2characterText.text = "Name: Dozer\nDescription: Former truck driver on a quest for vengeance against the machines";
            }
            if (choosingPlayer2Horizontal == 4)
            {
                characterChoice.sprite = character4;

                P2characterText.text = "Name: Jaeger\nDescription: A cocky, hot headed pilot on the hunt for more fame and glory.";
            }

            characterChoice.enabled = true;
            P2characterText.enabled = true;
        }
        if (ship)
        {
            if (choosingPlayer2Horizontal == 1)
            {
                shipChoice.sprite = ship1;
                stat.sprite = ship1Stat;

                P2LightShipData();
                Player2Data();
                Player2WeaponData();
            }
            if (choosingPlayer2Horizontal == 2)
            {
                shipChoice.sprite = ship2;
                stat.sprite = ship2Stat;

                P2MediumShipData();
                Player2Data();
                Player2WeaponData();
            }
            if (choosingPlayer2Horizontal == 3)
            {
                shipChoice.sprite = ship3;
                stat.sprite = ship3Stat;

                P2HeavyShipData();
                Player2Data();
                Player2WeaponData();
            }
            if (choosingPlayer2Horizontal == 4)
            {
                shipChoice.sprite = ship4;
                stat.sprite = ship4Stat;

                P2LamboShooterData();
                Player2Data();
                Player2WeaponData();
            }
            if (choosingPlayer2Horizontal == 5)
            {
                shipChoice.sprite = ship5;
                stat.sprite = ship5Stat;

                P2TruckShooterData();
                Player2Data();
                Player2WeaponData();
            }

            shipChoice.enabled = true;
            stat.enabled = true;
        }
        if (primary)
        {
            if (choosingPlayer2Horizontal == 1)
            {
                weaponChoice.sprite = primary1;
                stat.sprite = primary1Stat;
            }
            if (choosingPlayer2Horizontal == 2)
            {
                weaponChoice.sprite = primary2;
                stat.sprite = primary2Stat;
            }
            if (choosingPlayer2Horizontal == 3)
            {
                weaponChoice.sprite = primary3;
                stat.sprite = primary3Stat;
            }

            weaponChoice.enabled = true;
            stat.enabled = true;
        }
        if (secondary)
        {
            if (choosingPlayer2Horizontal == 1)
            {
                weaponChoice.sprite = secondary1;
                stat.sprite = secondary1Stat;
            }
            if (choosingPlayer2Horizontal == 2)
            {
                weaponChoice.sprite = secondary2;
                stat.sprite = secondary2Stat;
            }
            if (choosingPlayer2Horizontal == 3)
            {
                weaponChoice.sprite = secondary3;
                stat.sprite = secondary3Stat;
            }

            weaponChoice.enabled = true;
            stat.enabled = true;
        }
        if (special)
        {
            if (choosingPlayer2Horizontal == 1)
            {
                weaponChoice.sprite = special1;
                stat.sprite = special1Stat;
            }
            if (choosingPlayer2Horizontal == 2)
            {
                weaponChoice.sprite = special2;
                stat.sprite = special2Stat;
            }
            if (choosingPlayer2Horizontal == 3)
            {
                weaponChoice.sprite = special3;
                stat.sprite = special3Stat;
            }

            weaponChoice.enabled = true;
            stat.enabled = true;
        }
    }

    private void P2LightShipData()
    {
        PlayerHealthSystem.P2maxHealth = 100;
        PlayerHealthSystem.P2maxShields = 75;
        PlayerHealthSystem.P2maxLives = 5;
    }
    private void P2MediumShipData()
    {
        PlayerHealthSystem.P2maxHealth = 125;
        PlayerHealthSystem.P2maxShields = 100;
        PlayerHealthSystem.P2maxLives = 5;
    }
    private void P2HeavyShipData()
    {
        PlayerHealthSystem.P2maxHealth = 150;
        PlayerHealthSystem.P2maxShields = 125;
        PlayerHealthSystem.P2maxLives = 5;
    }
    private void P2LamboShooterData()
    {
        PlayerHealthSystem.P2maxHealth = 75;
        PlayerHealthSystem.P2maxShields = 150;
        PlayerHealthSystem.P2maxLives = 5;
    }
    private void P2TruckShooterData()
    {
        PlayerHealthSystem.P2maxHealth = 200;
        PlayerHealthSystem.P2maxShields = 200;
        PlayerHealthSystem.P2maxLives = 5;
    }

    private void Player2Data()
    {
        PlayerHealthSystem.P2savedHealth = PlayerHealthSystem.P2maxHealth;
        PlayerHealthSystem.P2savedShields = PlayerHealthSystem.P2maxShields;
        PlayerHealthSystem.P2savedLives = 3;
    }
    private void Player2WeaponData()
    {
        PlayerWeaponController.P2savedWeaponLevel = PlayerWeaponController.baseWLevel;
        PlayerWeaponController.P2savedSecondaryLevel = PlayerWeaponController.baseSecondaryLevel;
        PlayerWeaponController.P2savedSuperAmmo = PlayerWeaponController.superAmmoDefault;
    }

    private void DeactivateP2OriginalShips()
    {
        P2ship1.gameObject.SetActive(false);
        P2ship2.gameObject.SetActive(false);
        P2ship3.gameObject.SetActive(false);
        P2ship4.gameObject.SetActive(false);
        P2ship5.gameObject.SetActive(false);
    }

    private void CheckPlayer2Ship()
    {
        if (SelectionMenuController.P2shipType == 1)
        {
            P2ship1.gameObject.SetActive(true);
            player2CurrentShip = P2ship1.gameObject;
        }
        if (SelectionMenuController.P2shipType == 2)
        {
            P2ship2.gameObject.SetActive(true);
            player2CurrentShip = P2ship2.gameObject;
        }
        if (SelectionMenuController.P2shipType == 3)
        {
            P2ship3.gameObject.SetActive(true);
            player2CurrentShip = P2ship3.gameObject;
        }
        if (SelectionMenuController.P2shipType == 4)
        {
            P2ship4.gameObject.SetActive(true);
            player2CurrentShip = P2ship4.gameObject;
        }
        if (SelectionMenuController.P2shipType == 5)
        {
            P2ship5.gameObject.SetActive(true);
            player2CurrentShip = P2ship5.gameObject;
        }
    }

    private void SpawnPlayer2()
    {
        Instantiate(player2CurrentShip, new Vector3(9, 0, 0), Quaternion.identity);
        DeactivateP2OriginalShips();
    }

    private void ResumeButton()
    {
        DeactivatePauseMenu();
        ActivateHUD();
    }

    private void RestartButton()
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

        DeactivatePauseMenu();
        ActivateHUD();

        if (MainMenuController.currentStage <= 1)
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
    }

    private void MainMenuButton()
    {
        ResetPlayerScore();
        ResetType();

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
        addingPlayer2 = true;
        addingMenu = true;

        DeactivatePauseMenu();
        DeactivateHUD();

        Time.timeScale = 0f;
        pauseMenuOn = true;

        ActivateAddingVerticalCanvas();
        ActivateAddingVerticalButton();
        ActivateAddingVerticalChoices();
    }
}
