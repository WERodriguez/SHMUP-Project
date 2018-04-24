using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HangarMenuController : MonoBehaviour
{
    private bool waiting;
    private bool P1buy;
    private bool P2buy;

    private bool P1warning;
    private bool P1verticalSelect;
    private bool P1switch;
    private bool P1testing;
    private bool P1testingDone;

    private bool P1healthCheck;
    private bool P1shieldCheck;
    private bool P1primaryCheck;
    private bool P1secondaryCheck;
    private bool P1shipSwitch;
    private bool P1primarySwitch;
    private bool P1secondarySwitch;

    private int P1horizontalGlowTracker;
    private int P1verticalGlowTracker;
    private int P1toggleData;

    private bool P2warning;
    private bool P2verticalSelect;
    private bool P2switch;
    private bool P2testing;
    private bool P2testingDone;

    private bool P2healthCheck;
    private bool P2shieldCheck;
    private bool P2primaryCheck;
    private bool P2secondaryCheck;
    private bool P2shipSwitch;
    private bool P2primarySwitch;
    private bool P2secondarySwitch;

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

    public Animator P1menuAnimation;
    public Animator nextButtonAnimation;

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

    public Transform[] P1primarySpawnPoint;
    public Transform[] P1secondarySpawnPoint;

    public Transform[] P2primarySpawnPoint;
    public Transform[] P2secondarySpawnPoint;

    public GameObject machineGunBullet;
    public GameObject flakCannonBullet;
    public GameObject pacBullet;
    public GameObject homingMissiles;
    public GameObject sweeperPods;
    public GameObject plasmaBullet;

    private AudioClip[] soundEffect;
    private AudioSource[] buttonSoundEffect;

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
        DeactivateP1WarningPanel();
        ResetP1Bool();
        ResetP1SwitchBool();

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
        DeactivateP2WarningPanel();
        ResetP2Bool();
        ResetP2SwitchBool();

        DeactivateP2WarningPanel();

        waiting = true;
        P1buy = false;
        P2buy = false;

        P1Credit.enabled = false;
        P1verticalSelect = true;
        P1switch = false;
        P1testing = false;
        P1testingDone = true;

        P2Credit.enabled = false;
        P2verticalSelect = true;
        P2switch = false;
        P2testing = false;
        P2testingDone = true;
    }

    private void Start()
    {
        StartCoroutine(Timer());
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

        if (MainMenuController.onePlayer)
        {
            P1Credit.text = "Player 1 has: " + ScoreTracker.P1credit;
        }
        else
        {
            P1Credit.text = "Player 1 has: " + ScoreTracker.P1credit;
            P2Credit.text = "Player 2 has: " + ScoreTracker.P2credit;
        }

        if (!waiting)
        {
            if (MainMenuController.onePlayer)
            {
                if (!P1warning)
                {
                    if (P1switch)
                    {
                        if (P1testingDone)
                        {
                            if (Input.GetButtonDown("P1HorizontalChoiceLeft"))
                            {
                                ScrollingSound();

                                P1testing = false;
                                P1toggleData--;

                                DeactivateP1ToggleGlow();
                                P1toggleLeftGlow.SetActive(true);
                            }
                            if (Input.GetButtonDown("P1HorizontalChoiceRight"))
                            {
                                ScrollingSound();

                                P1testing = false;
                                P1toggleData++;

                                DeactivateP1ToggleGlow();
                                P1toggleRightGlow.SetActive(true);
                            }

                            if (P1shipSwitch)
                            {
                                if (P1toggleData <= 1)
                                {
                                    P1toggleData = 1;

                                    DeactivateP1Ships();
                                    P1ship1.SetActive(true);
                                }
                                if (P1toggleData == 2)
                                {
                                    DeactivateP1Ships();
                                    P1ship2.SetActive(true);
                                }
                                if (P1toggleData == 3)
                                {
                                    DeactivateP1Ships();
                                    P1ship3.SetActive(true);
                                }
                                if (P1toggleData == 4)
                                {
                                    DeactivateP1Ships();
                                    P1ship4.SetActive(true);
                                }
                                if (P1toggleData >= 5)
                                {
                                    P1toggleData = 5;

                                    DeactivateP1Ships();
                                    P1ship5.SetActive(true);
                                }
                            }
                            if (!P1testing)
                            {
                                if (P1primarySwitch)
                                {
                                    if (P1toggleData <= 1)
                                    {
                                        StartCoroutine(P1TestMachineGun());
                                    }
                                    if (P1toggleData == 2)
                                    {
                                        StartCoroutine(P1TestFlakCannon());
                                    }
                                    if (P1toggleData >= 3)
                                    {
                                        StartCoroutine(P1TestPAC());
                                    }
                                }
                                if (P1secondarySwitch)
                                {
                                    if (P1toggleData <= 1)
                                    {
                                        StartCoroutine(P1TestHomingMissiles());
                                    }
                                    if (P1toggleData == 2)
                                    {
                                        StartCoroutine(P1TestSweeperPods());
                                    }
                                    if (P1toggleData >= 3)
                                    {
                                        StartCoroutine(P1TestPlasmaBullet());
                                    }
                                }
                            }

                            if (Input.GetButtonDown("Fire_P1") || FlexToggle.myFlexBool == true)
                            {
                                FlexToggle.myFlexBool = false;
                                if (P1shipSwitch)
                                {
                                    StartCoroutine(P1ShipChange());
                                }
                                if (P1primarySwitch)
                                {
                                    StartCoroutine(P1PrimaryChange());
                                }
                                if (P1secondarySwitch)
                                {
                                    StartCoroutine(P1SecondaryChange());
                                }

                                P1testing = false;
                                ResetP1ToggleData();
                                DeactivateP1ToggleGlow();
                            }
                        }
                    }
                    else
                    {
                        if (Input.GetButtonDown("P1VerticalChoiceUp"))
                        {
                            ScrollingSound();

                            P1verticalSelect = true;
                            P1verticalGlowTracker--;
                        }
                        if (Input.GetButtonDown("P1VerticalChoiceDown"))
                        {
                            ScrollingSound();

                            P1verticalSelect = true;
                            P1verticalGlowTracker++;
                        }

                        if (Input.GetButtonDown("P1HorizontalChoiceLeft"))
                        {
                            ScrollingSound();

                            P1verticalSelect = false;
                            P1horizontalGlowTracker--;
                        }
                        if (Input.GetButtonDown("P1HorizontalChoiceRight"))
                        {
                            ScrollingSound();

                            P1verticalSelect = false;
                            P1horizontalGlowTracker++;
                        }


                        if (P1verticalSelect)
                        {
                            DeactivateP1HorizontalMenuGlow();

                            P1horizontalGlowTracker = 0;

                            if (P1verticalGlowTracker <= 1)
                            {
                                P1verticalGlowTracker = 1;

                                DeactivateButtonGlow();
                                DeactivateP1Glow();
                                restartButtonGlow.SetActive(true);
                            }
                            if (P1verticalGlowTracker == 2)
                            {
                                DeactivateButtonGlow();
                                DeactivateP1Glow();
                                P1healthGlow.SetActive(true);
                            }
                            if (P1verticalGlowTracker == 3)
                            {
                                DeactivateButtonGlow();
                                DeactivateP1Glow();
                                P1shieldGlow.SetActive(true);
                            }
                            if (P1verticalGlowTracker == 4)
                            {
                                DeactivateButtonGlow();
                                DeactivateP1Glow();
                                P1liveGlow.SetActive(true);
                            }
                            if (P1verticalGlowTracker == 5)
                            {
                                DeactivateButtonGlow();
                                DeactivateP1Glow();
                                P1primaryGlow.SetActive(true);
                            }
                            if (P1verticalGlowTracker == 6)
                            {
                                DeactivateButtonGlow();
                                DeactivateP1Glow();
                                P1secondaryGlow.SetActive(true);
                            }
                            if (P1verticalGlowTracker == 7)
                            {
                                DeactivateButtonGlow();
                                DeactivateP1Glow();
                                P1specialGlow.SetActive(true);
                            }
                            if (P1verticalGlowTracker >= 8)
                            {
                                P1verticalGlowTracker = 8;

                                DeactivateButtonGlow();
                                DeactivateP1Glow();
                                nextButtonGlow.SetActive(true);
                            }

                            if (Input.GetButtonDown("Fire_P1") || FlexToggle.myFlexBool == true)
                            {
                                FlexToggle.myFlexBool = false;
                                if (P1verticalGlowTracker == 1)
                                {
                                    RestartButton();
                                }
                                if (P1verticalGlowTracker == 2)
                                {
                                    StartCoroutine(P1HealthRestore());
                                }
                                if (P1verticalGlowTracker == 3)
                                {
                                    StartCoroutine(P1ShieldRestore());
                                }
                                if (P1verticalGlowTracker == 4)
                                {
                                    StartCoroutine(P1LiveAdd());
                                }
                                if (P1verticalGlowTracker == 5)
                                {
                                    StartCoroutine(P1PrimaryUpgrade());
                                }
                                if (P1verticalGlowTracker == 6)
                                {
                                    StartCoroutine(P1SecondaryUpgrade());
                                }
                                if (P1verticalGlowTracker == 7)
                                {
                                    StartCoroutine(P1AmmoAdd());
                                }
                                if (P1verticalGlowTracker == 8)
                                {
                                    NextButton();
                                }
                            }
                        }
                        else
                        {
                            DeactivateButtonGlow();
                            DeactivateP1Glow();

                            P1verticalGlowTracker = 0;

                            if (P1horizontalGlowTracker <= 1)
                            {
                                P1horizontalGlowTracker = 1;

                                DeactivateP1HorizontalMenuGlow();
                                P1shipGlowHorizontal.SetActive(true);
                            }
                            if (P1horizontalGlowTracker == 2)
                            {
                                DeactivateP1HorizontalMenuGlow();
                                P1primaryGlowHorizontal.SetActive(true);
                            }
                            if (P1horizontalGlowTracker >= 3)
                            {
                                P1horizontalGlowTracker = 3;

                                DeactivateP1HorizontalMenuGlow();
                                P1secondaryGlowHorizontal.SetActive(true);
                            }

                            if (Input.GetButtonDown("Fire_P1") || FlexToggle.myFlexBool == true)
                            {
                                FlexToggle.myFlexBool = false;
                                if (P1horizontalGlowTracker <= 1)
                                {
                                    StartCoroutine(P1ShipSwitch());
                                }
                                if (P1horizontalGlowTracker == 2)
                                {
                                    StartCoroutine(P1PrimarySwitch());
                                }
                                if (P1horizontalGlowTracker >= 3)
                                {
                                    StartCoroutine(P1SecondarySwitch());
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                if (!P1warning)
                {
                    if (P1switch)
                    {
                        if (P1testingDone)
                        {
                            if (Input.GetButtonDown("P1HorizontalChoiceLeft"))
                            {
                                ScrollingSound();

                                P1testing = false;
                                P1toggleData--;

                                DeactivateP1ToggleGlow();
                                P1toggleLeftGlow.SetActive(true);
                            }
                            if (Input.GetButtonDown("P1HorizontalChoiceRight"))
                            {
                                ScrollingSound();

                                P1testing = false;
                                P1toggleData++;

                                DeactivateP1ToggleGlow();
                                P1toggleRightGlow.SetActive(true);
                            }

                            if (P1shipSwitch)
                            {
                                if (P1toggleData <= 1)
                                {
                                    P1toggleData = 1;

                                    DeactivateP1Ships();
                                    P1ship1.SetActive(true);
                                }
                                if (P1toggleData == 2)
                                {
                                    DeactivateP1Ships();
                                    P1ship2.SetActive(true);
                                }
                                if (P1toggleData == 3)
                                {
                                    DeactivateP1Ships();
                                    P1ship3.SetActive(true);
                                }
                                if (P1toggleData == 4)
                                {
                                    DeactivateP1Ships();
                                    P1ship4.SetActive(true);
                                }
                                if (P1toggleData >= 5)
                                {
                                    P1toggleData = 5;

                                    DeactivateP1Ships();
                                    P1ship5.SetActive(true);
                                }
                            }
                            if (!P1testing)
                            {
                                if (P1primarySwitch)
                                {
                                    if (P1toggleData <= 1)
                                    {
                                        StartCoroutine(P1TestMachineGun());
                                    }
                                    if (P1toggleData == 2)
                                    {
                                        StartCoroutine(P1TestFlakCannon());
                                    }
                                    if (P1toggleData >= 3)
                                    {
                                        StartCoroutine(P1TestPAC());
                                    }
                                }
                                if (P1secondarySwitch)
                                {
                                    if (P1toggleData <= 1)
                                    {
                                        StartCoroutine(P1TestHomingMissiles());
                                    }
                                    if (P1toggleData == 2)
                                    {
                                        StartCoroutine(P1TestSweeperPods());
                                    }
                                    if (P1toggleData >= 3)
                                    {
                                        StartCoroutine(P1TestPlasmaBullet());
                                    }
                                }
                            }

                            if (Input.GetButtonDown("Fire_P1") || FlexToggle.myFlexBool == true)
                            {
                                FlexToggle.myFlexBool = false;
                                if (P1shipSwitch)
                                {
                                    StartCoroutine(P1ShipChange());
                                }
                                if (P1primarySwitch)
                                {
                                    StartCoroutine(P1PrimaryChange());
                                }
                                if (P1secondarySwitch)
                                {
                                    StartCoroutine(P1SecondaryChange());
                                }

                                P1testing = false;
                                ResetP1ToggleData();
                                DeactivateP1ToggleGlow();
                            }
                        }
                    }
                    else
                    {
                        if (Input.GetButtonDown("P1VerticalChoiceUp"))
                        {
                            ScrollingSound();

                            P1verticalSelect = true;
                            P1verticalGlowTracker--;
                        }
                        if (Input.GetButtonDown("P1VerticalChoiceDown"))
                        {
                            ScrollingSound();

                            P1verticalSelect = true;
                            P1verticalGlowTracker++;
                        }

                        if (Input.GetButtonDown("P1HorizontalChoiceLeft"))
                        {
                            ScrollingSound();

                            P1verticalSelect = false;
                            P1horizontalGlowTracker--;
                        }
                        if (Input.GetButtonDown("P1HorizontalChoiceRight"))
                        {
                            ScrollingSound();

                            P1verticalSelect = false;
                            P1horizontalGlowTracker++;
                        }

                        if (P1verticalSelect)
                        {
                            DeactivateP1HorizontalMenuGlow();

                            P1horizontalGlowTracker = 0;

                            if (P1verticalGlowTracker <= 1)
                            {
                                P1verticalGlowTracker = 1;

                                DeactivateButtonGlow();
                                DeactivateP1Glow();
                                restartButtonGlow.SetActive(true);
                            }
                            if (P1verticalGlowTracker == 2)
                            {
                                DeactivateButtonGlow();
                                DeactivateP1Glow();
                                P1healthGlow.SetActive(true);
                            }
                            if (P1verticalGlowTracker == 3)
                            {
                                DeactivateButtonGlow();
                                DeactivateP1Glow();
                                P1shieldGlow.SetActive(true);
                            }
                            if (P1verticalGlowTracker == 4)
                            {
                                DeactivateButtonGlow();
                                DeactivateP1Glow();
                                P1liveGlow.SetActive(true);
                            }
                            if (P1verticalGlowTracker == 5)
                            {
                                DeactivateButtonGlow();
                                DeactivateP1Glow();
                                P1primaryGlow.SetActive(true);
                            }
                            if (P1verticalGlowTracker == 6)
                            {
                                DeactivateButtonGlow();
                                DeactivateP1Glow();
                                P1secondaryGlow.SetActive(true);
                            }
                            if (P1verticalGlowTracker >= 7)
                            {
                                P1verticalGlowTracker = 7;

                                DeactivateButtonGlow();
                                DeactivateP1Glow();
                                P1specialGlow.SetActive(true);
                            }

                            if (Input.GetButtonDown("Fire_P1") || FlexToggle.myFlexBool == true)
                            {
                                FlexToggle.myFlexBool = false;
                                if (P1verticalGlowTracker == 1)
                                {
                                    RestartButton();
                                }
                                if (P1verticalGlowTracker == 2)
                                {
                                    StartCoroutine(P1HealthRestore());
                                }
                                if (P1verticalGlowTracker == 3)
                                {
                                    StartCoroutine(P1ShieldRestore());
                                }
                                if (P1verticalGlowTracker == 4)
                                {
                                    StartCoroutine(P1LiveAdd());
                                }
                                if (P1verticalGlowTracker == 5)
                                {
                                    StartCoroutine(P1PrimaryUpgrade());
                                }
                                if (P1verticalGlowTracker == 6)
                                {
                                    StartCoroutine(P1SecondaryUpgrade());
                                }
                                if (P1verticalGlowTracker == 7)
                                {
                                    StartCoroutine(P1AmmoAdd());
                                }

                            }
                        }
                        else
                        {
                            restartButtonGlow.SetActive(false);
                            DeactivateP1Glow();

                            P1verticalGlowTracker = 0;

                            if (P1horizontalGlowTracker <= 1)
                            {
                                P1horizontalGlowTracker = 1;

                                DeactivateP1HorizontalMenuGlow();
                                P1shipGlowHorizontal.SetActive(true);
                            }
                            if (P1horizontalGlowTracker == 2)
                            {
                                DeactivateP1HorizontalMenuGlow();
                                P1primaryGlowHorizontal.SetActive(true);
                            }
                            if (P1horizontalGlowTracker >= 3)
                            {
                                P1horizontalGlowTracker = 3;

                                DeactivateP1HorizontalMenuGlow();
                                P1secondaryGlowHorizontal.SetActive(true);
                            }

                            if (Input.GetButtonDown("Fire_P1") || FlexToggle.myFlexBool == true)
                            {
                                FlexToggle.myFlexBool = false;
                                if (P1horizontalGlowTracker <= 1)
                                {
                                    StartCoroutine(P1ShipSwitch());
                                }
                                if (P1horizontalGlowTracker == 2)
                                {
                                    StartCoroutine(P1PrimarySwitch());
                                }
                                if (P1horizontalGlowTracker >= 3)
                                {
                                    StartCoroutine(P1SecondarySwitch());
                                }
                            }
                        }
                    }
                }

                if (!P2warning)
                {
                    if (P2switch)
                    {
                        if (P2testingDone)
                        {
                            if (Input.GetButtonDown("P2HorizontalChoiceLeft") || Input.GetKeyDown(KeyCode.Keypad4))
                            {
                                ScrollingSound();

                                P2testing = false;
                                P2toggleData++;

                                DeactivateP2ToggleGlow();
                                P2toggleLeftGlow.SetActive(true);
                            }
                            if (Input.GetButtonDown("P2HorizontalChoiceRight") || Input.GetKeyDown(KeyCode.Keypad6))
                            {
                                ScrollingSound();

                                P2testing = false;
                                P2toggleData--;

                                DeactivateP2ToggleGlow();
                                P2toggleRightGlow.SetActive(true);
                            }

                            if (P2shipSwitch)
                            {
                                if (P2toggleData <= 1)
                                {
                                    P2toggleData = 1;

                                    DeactivateP2Ships();
                                    P2ship1.SetActive(true);
                                }
                                if (P2toggleData == 2)
                                {
                                    DeactivateP2Ships();
                                    P2ship2.SetActive(true);
                                }
                                if (P2toggleData == 3)
                                {
                                    DeactivateP2Ships();
                                    P2ship3.SetActive(true);
                                }
                                if (P2toggleData == 4)
                                {
                                    DeactivateP2Ships();
                                    P2ship4.SetActive(true);
                                }
                                if (P2toggleData >= 5)
                                {
                                    P2toggleData = 5;

                                    DeactivateP2Ships();
                                    P2ship5.SetActive(true);
                                }
                            }
                            if (!P2testing)
                            {
                                if (P2primarySwitch)
                                {
                                    if (P2toggleData <= 1)
                                    {
                                        StartCoroutine(P2TestMachineGun());
                                    }
                                    if (P2toggleData == 2)
                                    {
                                        StartCoroutine(P2TestFlakCannon());
                                    }
                                    if (P2toggleData >= 3)
                                    {
                                        StartCoroutine(P2TestPAC());
                                    }
                                }
                                if (P2secondarySwitch)
                                {
                                    if (P2toggleData <= 1)
                                    {
                                        StartCoroutine(P2TestHomingMissiles());
                                    }
                                    if (P2toggleData == 2)
                                    {
                                        StartCoroutine(P2TestSweeperPods());
                                    }
                                    if (P2toggleData >= 3)
                                    {
                                        StartCoroutine(P2TestPlasmaBullet());
                                    }
                                }
                            }

                            if (Input.GetButtonDown("Fire_P2"))
                            {
                                if (P2shipSwitch)
                                {
                                    StartCoroutine(P2ShipChange());
                                }
                                if (P2primarySwitch)
                                {
                                    StartCoroutine(P2PrimaryChange());
                                }
                                if (P2secondarySwitch)
                                {
                                    StartCoroutine(P2SecondaryChange());
                                }

                                P2testing = false;

                                ResetP2ToggleData();
                                DeactivateP2ToggleGlow();
                            }
                        }
                    }
                    else
                    {
                        if (Input.GetButtonDown("P2VerticalChoiceUp") || Input.GetKeyDown(KeyCode.Keypad8))
                        {
                            ScrollingSound();

                            P2verticalSelect = true;
                            P2verticalGlowTracker--;
                        }
                        if (Input.GetButtonDown("P2VerticalChoiceDown") || Input.GetKeyDown(KeyCode.Keypad5))
                        {
                            ScrollingSound();

                            P2verticalSelect = true;
                            P2verticalGlowTracker++;
                        }

                        if (Input.GetButtonDown("P2HorizontalChoiceLeft") || Input.GetKeyDown(KeyCode.Keypad4))
                        {
                            ScrollingSound();

                            P2verticalSelect = false;
                            P2horizontalGlowTracker++;
                        }
                        if (Input.GetButtonDown("P2HorizontalChoiceRight") || Input.GetKeyDown(KeyCode.Keypad6))
                        {
                            ScrollingSound();

                            P2verticalSelect = false;
                            P2horizontalGlowTracker--;
                        }


                        if (P2verticalSelect)
                        {
                            DeactivateP2HorizontalMenuGlow();

                            P2horizontalGlowTracker = 0;

                            if (P2verticalGlowTracker <= 1)
                            {
                                P2verticalGlowTracker = 1;

                                DeactivateP2Glow();
                                nextButtonGlow.SetActive(true);
                            }
                            if (P2verticalGlowTracker == 2)
                            {
                                nextButtonGlow.SetActive(false);
                                DeactivateP2Glow();
                                P2healthGlow.SetActive(true);
                            }
                            if (P2verticalGlowTracker == 3)
                            {
                                DeactivateP2Glow();
                                P2shieldGlow.SetActive(true);
                            }
                            if (P2verticalGlowTracker == 4)
                            {
                                DeactivateP2Glow();
                                P2liveGlow.SetActive(true);
                            }
                            if (P2verticalGlowTracker == 5)
                            {
                                DeactivateP2Glow();
                                P2primaryGlow.SetActive(true);
                            }
                            if (P2verticalGlowTracker == 6)
                            {
                                DeactivateP2Glow();
                                P2secondaryGlow.SetActive(true);
                            }
                            if (P2verticalGlowTracker >= 7)
                            {
                                P2verticalGlowTracker = 7;

                                DeactivateP2Glow();
                                P2specialGlow.SetActive(true);
                            }

                            if (Input.GetButtonDown("Fire_P2") || Input.GetKeyDown(KeyCode.Keypad0))
                            {
                                if (P2verticalGlowTracker == 1)
                                {
                                    NextButton();
                                }
                                if (P2verticalGlowTracker == 2)
                                {
                                    StartCoroutine(P2HealthRestore());
                                }
                                if (P2verticalGlowTracker == 3)
                                {
                                    StartCoroutine(P2ShieldRestore());
                                }
                                if (P2verticalGlowTracker == 4)
                                {
                                    StartCoroutine(P2LiveAdd());
                                }
                                if (P2verticalGlowTracker == 5)
                                {
                                    StartCoroutine(P2PrimaryUpgrade());
                                }
                                if (P2verticalGlowTracker == 6)
                                {
                                    StartCoroutine(P2SecondaryUpgrade());
                                }
                                if (P2verticalGlowTracker == 7)
                                {
                                    StartCoroutine(P2AmmoAdd());
                                }
                            }
                        }
                        else
                        {
                            nextButtonGlow.SetActive(false);
                            DeactivateP2Glow();

                            P2verticalGlowTracker = 0;

                            if (P2horizontalGlowTracker <= 1)
                            {
                                P2horizontalGlowTracker = 1;

                                DeactivateP2HorizontalMenuGlow();
                                P2shipGlowHorizontal.SetActive(true);
                            }
                            if (P2horizontalGlowTracker == 2)
                            {
                                DeactivateP2HorizontalMenuGlow();
                                P2primaryGlowHorizontal.SetActive(true);
                            }
                            if (P2horizontalGlowTracker >= 3)
                            {
                                P2horizontalGlowTracker = 3;

                                DeactivateP2HorizontalMenuGlow();
                                P2secondaryGlowHorizontal.SetActive(true);
                            }

                            if (Input.GetButtonDown("Fire_P2") || Input.GetKeyDown(KeyCode.Keypad0))
                            {
                                if (P2horizontalGlowTracker <= 1)
                                {
                                    StartCoroutine(P2ShipSwitch());
                                }
                                if (P2horizontalGlowTracker == 2)
                                {
                                    StartCoroutine(P2PrimarySwitch());
                                }
                                if (P2horizontalGlowTracker >= 3)
                                {
                                    StartCoroutine(P2SecondarySwitch());
                                }
                            }
                        }
                    }
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

            P1menuAnimation.SetBool("singlePlayer", true);
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

            P1health.SetActive(true);
            P1healthStartingAnimation.SetBool("StartAnimation", true);
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
            P1Credit.enabled = true;

            P1shield.SetActive(true);
            P1shieldStartingAnimation.SetBool("StartAnimation", true);
        }
        else
        {
            P1Credit.enabled = true;
            P2Credit.enabled = true;

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
            nextButtonAnimation.SetBool("bottomMove", true);
        }

        yield return new WaitForSeconds(.5f);

        waiting = false;
    }

    IEnumerator P1HealthRestore()
    {
        if (PlayerHealthSystem.P1currentHealth >= PlayerHealthSystem.P1maxHealth)
        {
            P1WarningText.text = "You already have full health";
            ActivateP1WarningPanel();

            yield return new WaitForSeconds(1.5f);

            DeactivateP1WarningPanel();

            P1healthShader.SetActive(true);
        }

        if (P1healthCheck)
        {
            P1WarningText.text = "You already restore your health";
            ActivateP1WarningPanel();

            yield return new WaitForSeconds(1.5f);

            DeactivateP1WarningPanel();
        }

        if (PlayerHealthSystem.P1currentHealth < PlayerHealthSystem.P1maxHealth && !P1healthCheck)
        {
            if (ScoreTracker.P1credit < 100)
            {
                P1WarningText.text = "You don't have enough credit";
                ActivateP1WarningPanel();

                yield return new WaitForSeconds(1.5f);

                DeactivateP1WarningPanel();
                ActivateP1Shader();
            }
            if (ScoreTracker.P1credit >= 100)
            {
                ScoreTracker.P1credit -= 100;

                P1WarningText.text = "Our ship builders are the best, aren't they!!!";
                ActivateP1WarningPanel();

                yield return new WaitForSeconds(1.5f);

                DeactivateP1WarningPanel();

                PlayerHealthSystem.P1currentHealth = PlayerHealthSystem.P1maxHealth;

                P1healthShader.SetActive(true);
                P1healthCheck = true;
            }
        }
    }
    IEnumerator P1ShieldRestore()
    {
        if (PlayerHealthSystem.P1currentShields >= PlayerHealthSystem.P1maxShields)
        {
            P1WarningText.text = "Your shield was fully charged";
            ActivateP1WarningPanel();

            yield return new WaitForSeconds(1.5f);

            DeactivateP1WarningPanel();

            P1shieldShader.SetActive(true);
        }

        if (P1shieldCheck)
        {
            P1WarningText.text = "You already recharge your shield";
            ActivateP1WarningPanel();

            yield return new WaitForSeconds(1.5f);

            DeactivateP1WarningPanel();
        }

        if (PlayerHealthSystem.P1currentShields < PlayerHealthSystem.P1maxShields && !P1shieldCheck)
        {
            if (ScoreTracker.P1credit < 100)
            {
                P1WarningText.text = "You don't have enough credit";
                ActivateP1WarningPanel();

                yield return new WaitForSeconds (1.5f);

                DeactivateP1WarningPanel();
                ActivateP1Shader();
            }
            if (ScoreTracker.P1credit >= 100)
            {
                ScoreTracker.P1credit -= 100;

                P1WarningText.text = "It will take double that amount if you don't bring back scrap next time!!!";
                ActivateP1WarningPanel();

                yield return new WaitForSeconds(1.5f);

                DeactivateP1WarningPanel();

                PlayerHealthSystem.P1currentShields = PlayerHealthSystem.P1maxShields;

                P1shieldShader.SetActive(true);
                P1shieldCheck = true;
            }
        }
    }
    IEnumerator P1LiveAdd()
    {
        if (PlayerHealthSystem.P1currentLives >= 5)
        {
            PlayerHealthSystem.P1currentLives = 5;

            P1WarningText.text = "You can only have 5 Spares";
            ActivateP1WarningPanel();

            yield return new WaitForSeconds(1.5f);

            DeactivateP1WarningPanel();

            P1liveShader.SetActive(true);
        }

        if (PlayerHealthSystem.P1currentLives < 5)
        {
            if (ScoreTracker.P1credit < 100)
            {
                P1WarningText.text = "You don't have enough credit";
                ActivateP1WarningPanel();

                yield return new WaitForSeconds(1.5f);

                DeactivateP1WarningPanel();
                ActivateP1Shader();
            }
            if (ScoreTracker.P1credit >= 100)
            {
                ScoreTracker.P1credit -= 100;

                P1WarningText.text = "Why need so many spares";
                ActivateP1WarningPanel();

                yield return new WaitForSeconds(1.5f);

                DeactivateP1WarningPanel();

                PlayerHealthSystem.P1currentLives++;

                P1buy = true;
            }
        }
    }
    IEnumerator P1PrimaryUpgrade()
    {
        if (PlayerWeaponController.P1currentWLevel >= 5)
        {
            PlayerWeaponController.P1currentWLevel = 5;

            P1WarningText.text = "Your primary weapon is at max level";
            ActivateP1WarningPanel();

            yield return new WaitForSeconds(1.5f);

            DeactivateP1WarningPanel();

            P1primaryShader.SetActive(true);
        }

        if (P1primaryCheck)
        {
            P1WarningText.text = "You can only upgrade your primary once";
            ActivateP1WarningPanel();

            yield return new WaitForSeconds(1.5f);

            DeactivateP1WarningPanel();
        }

        if (PlayerWeaponController.P1currentWLevel < 5 && !P1primaryCheck)
        {
            if (ScoreTracker.P1credit < 100)
            {
                P1WarningText.text = "You don't have enough credit";
                ActivateP1WarningPanel();

                yield return new WaitForSeconds(1.5f);

                DeactivateP1WarningPanel();
                ActivateP1Shader();
            }
            if (ScoreTracker.P1credit >= 100)
            {
                ScoreTracker.P1credit -= 100;

                P1WarningText.text = "Spend more for a better discount";
                ActivateP1WarningPanel();

                yield return new WaitForSeconds(1.5f);

                DeactivateP1WarningPanel();

                PlayerWeaponController.P1currentWLevel++;

                P1primaryShader.SetActive(true);
                P1primaryCheck = true;
            }
        }
    }
    IEnumerator P1SecondaryUpgrade()
    {
        if (PlayerWeaponController.P1currentSecondaryLevel >= 5)
        {
            PlayerWeaponController.P1currentSecondaryLevel = 5;

            P1WarningText.text = "Your secondary weapon is at max level";
            ActivateP1WarningPanel();

            yield return new WaitForSeconds(1.5f);

            DeactivateP1WarningPanel();

            P1secondaryShader.SetActive(true);
        }

        if (P1secondaryCheck)
        {
            P1WarningText.text = "You can only upgrade your secondary once";
            ActivateP1WarningPanel();

            yield return new WaitForSeconds(1.5f);

            DeactivateP1WarningPanel();
        }

        if (PlayerWeaponController.P1currentSecondaryLevel < 5 && !P1secondaryCheck)
        {
            if (ScoreTracker.P1credit < 100)
            {
                P1WarningText.text = "You don't have enough credit";
                ActivateP1WarningPanel();

                yield return new WaitForSeconds(1.5f);

                DeactivateP1WarningPanel();
                ActivateP1Shader();
            }
            if (ScoreTracker.P1credit >= 100)
            {
                ScoreTracker.P1credit -= 100;

                P1WarningText.text = "Lucky you these stocks just came in";
                ActivateP1WarningPanel();

                yield return new WaitForSeconds(1.5f);

                DeactivateP1WarningPanel();

                PlayerWeaponController.P1currentSecondaryLevel++;

                P1secondaryShader.SetActive(true);
                P1secondaryCheck = true;
            }
        }
    }
    IEnumerator P1AmmoAdd()
    {
        if (PlayerWeaponController.P1superAmmo >= 5)
        {
            PlayerWeaponController.P1superAmmo = 5;

            P1WarningText.text = "Your ship only have sapce for 5 super charge";
            ActivateP1WarningPanel();

            yield return new WaitForSeconds(1.5f);

            DeactivateP1WarningPanel();

            P1specialShader.SetActive(true);
        }

        if (PlayerWeaponController.P1superAmmo < 5)
        {
            if (ScoreTracker.P1credit < 100)
            {
                P1WarningText.text = "You don't have enough credit";
                ActivateP1WarningPanel();

                yield return new WaitForSeconds(1.5f);

                DeactivateP1WarningPanel();
                ActivateP1Shader();
            }
            if (ScoreTracker.P1credit >= 100)
            {
                ScoreTracker.P1credit -= 100;

                P1WarningText.text = "Your ship has enough space to store these";
                ActivateP1WarningPanel();

                yield return new WaitForSeconds(1.5f);

                DeactivateP1WarningPanel();

                PlayerWeaponController.P1superAmmo++;
            }
        }
    }
    IEnumerator P1ShipSwitch()
    {
        P1WarningText.text = "It cost 1000 credit to swapping out your current ship";
        ActivateP1WarningPanel();

        yield return new WaitForSeconds(1.5f);

        DeactivateP1WarningPanel();

        ResetP1SwitchBool();
        P1switch = true;
        P1shipSwitch = true;
    }
    IEnumerator P1PrimarySwitch()
    {
        P1WarningText.text = "Your current primary level is: " + PlayerWeaponController.P1currentWLevel + ". It cost 1000 credit to swapping out your current primary";
        ActivateP1WarningPanel();

        yield return new WaitForSeconds(1.5f);

        DeactivateP1WarningPanel();

        ResetP1SwitchBool();
        P1switch = true;
        P1primarySwitch = true;
    }
    IEnumerator P1SecondarySwitch()
    {
        P1WarningText.text = "Your current secondary level is: " + PlayerWeaponController.P1currentSecondaryLevel + ". It cost 1000 credit to swapping out your current secondary";
        ActivateP1WarningPanel();

        yield return new WaitForSeconds(1.5f);

        DeactivateP1WarningPanel();

        ResetP1SwitchBool();
        P1switch = true;
        P1secondarySwitch = true;
    }

    IEnumerator P2HealthRestore()
    {
        if (PlayerHealthSystem.P2currentHealth >= PlayerHealthSystem.P2maxHealth)
        {
            P2WarningText.text = "You already have full health";
            ActivateP2WarningPanel();

            yield return new WaitForSeconds(1.5f);

            DeactivateP2WarningPanel();

            P2healthShader.SetActive(true);
        }

        if (P2healthCheck)
        {
            P2WarningText.text = "You already restore your health";
            ActivateP2WarningPanel();

            yield return new WaitForSeconds(1.5f);

            DeactivateP2WarningPanel();
        }

        if (PlayerHealthSystem.P2currentHealth < PlayerHealthSystem.P2maxHealth && !P2healthCheck)
        {
            if (ScoreTracker.P2credit < 100)
            {
                P2WarningText.text = "You don't have enough credit";
                ActivateP2WarningPanel();

                yield return new WaitForSeconds(1.5f);

                DeactivateP2WarningPanel();
                ActivateP2Shader();
            }
            if (ScoreTracker.P2credit >= 100)
            {
                ScoreTracker.P2credit -= 100;

                P2WarningText.text = "Our ship builders are the best, aren't they!!!";
                ActivateP2WarningPanel();

                yield return new WaitForSeconds(1.5f);

                DeactivateP2WarningPanel();

                PlayerHealthSystem.P2currentHealth = PlayerHealthSystem.P2maxHealth;

                P2healthShader.SetActive(true);
                P2healthCheck = true;
            }
        }
    }
    IEnumerator P2ShieldRestore()
    {
        if (PlayerHealthSystem.P2currentShields >= PlayerHealthSystem.P2maxShields)
        {
            P2WarningText.text = "Your shield was fully charged";
            ActivateP2WarningPanel();

            yield return new WaitForSeconds(1.5f);

            DeactivateP2WarningPanel();

            P2shieldShader.SetActive(true);
        }

        if (P2shieldCheck)
        {
            P2WarningText.text = "You already recharge your shield";
            ActivateP2WarningPanel();

            yield return new WaitForSeconds(1.5f);

            DeactivateP2WarningPanel();
        }

        if (PlayerHealthSystem.P2currentShields < PlayerHealthSystem.P2maxShields && !P2shieldCheck)
        {
            if (ScoreTracker.P2credit < 100)
            {
                P2WarningText.text = "You don't have enough credit";
                ActivateP2WarningPanel();

                yield return new WaitForSeconds(1.5f);

                DeactivateP2WarningPanel();
                ActivateP2Shader();
            }
            if (ScoreTracker.P2credit >= 100)
            {
                ScoreTracker.P2credit -= 100;

                P2WarningText.text = "It will take double that amount if you don't bring back scrap next time!!!";
                ActivateP2WarningPanel();

                yield return new WaitForSeconds(1.5f);

                DeactivateP2WarningPanel();

                PlayerHealthSystem.P2currentShields = PlayerHealthSystem.P2maxShields;

                P2shieldShader.SetActive(true);
                P2shieldCheck = true;
            }
        }
    }
    IEnumerator P2LiveAdd()
    {
        if (PlayerHealthSystem.P2currentLives >= 5)
        {
            PlayerHealthSystem.P2currentLives = 5;

            P2WarningText.text = "You can only have 5 Spares";
            ActivateP2WarningPanel();

            yield return new WaitForSeconds(1.5f);

            DeactivateP2WarningPanel();

            P2liveShader.SetActive(true);
        }

        if (PlayerHealthSystem.P2currentLives < 5)
        {
            if (ScoreTracker.P2credit < 100)
            {
                P2WarningText.text = "You don't have enough credit";
                ActivateP2WarningPanel();

                yield return new WaitForSeconds(1.5f);

                DeactivateP2WarningPanel();
                ActivateP2Shader();
            }
            if (ScoreTracker.P2credit >= 100)
            {
                ScoreTracker.P2credit -= 100;

                P2WarningText.text = "Why need so many spares";
                ActivateP2WarningPanel();

                yield return new WaitForSeconds(1.5f);

                DeactivateP2WarningPanel();

                PlayerHealthSystem.P2currentLives++;
                P2buy = true;
            }
        }
    }
    IEnumerator P2PrimaryUpgrade()
    {
        if (PlayerWeaponController.P2currentWLevel >= 5)
        {
            PlayerWeaponController.P2currentWLevel = 5;

            P2WarningText.text = "Your primary weapon is at max level";
            ActivateP2WarningPanel();

            yield return new WaitForSeconds(1.5f);

            DeactivateP2WarningPanel();

            P2primaryShader.SetActive(true);
        }

        if (P2primaryCheck)
        {
            P2WarningText.text = "You can only upgrade your primary once";
            ActivateP2WarningPanel();

            yield return new WaitForSeconds(1.5f);

            DeactivateP2WarningPanel();
        }

        if (PlayerWeaponController.P2currentWLevel < 5 && !P2primaryCheck)
        {
            if (ScoreTracker.P2credit < 100)
            {
                P2WarningText.text = "You don't have enough credit";
                ActivateP2WarningPanel();

                yield return new WaitForSeconds(1.5f);

                DeactivateP2WarningPanel();
                ActivateP2Shader();
            }
            if (ScoreTracker.P2credit >= 100)
            {
                ScoreTracker.P2credit -= 100;

                P2WarningText.text = "Spend more for a better discount";
                ActivateP2WarningPanel();

                yield return new WaitForSeconds(1.5f);

                DeactivateP2WarningPanel();

                PlayerWeaponController.P2currentWLevel++;

                P2primaryShader.SetActive(true);
                P2primaryCheck = true;
            }
        }
    }
    IEnumerator P2SecondaryUpgrade()
    {
        if (PlayerWeaponController.P2currentSecondaryLevel >= 5)
        {
            PlayerWeaponController.P2currentSecondaryLevel = 5;

            P2WarningText.text = "Your secondary weapon is at max level";
            ActivateP2WarningPanel();

            yield return new WaitForSeconds(1.5f);

            DeactivateP2WarningPanel();

            P2secondaryShader.SetActive(true);
        }

        if (P2secondaryCheck)
        {
            P2WarningText.text = "You can only upgrade your secondary once";
            ActivateP2WarningPanel();

            yield return new WaitForSeconds(1.5f);

            DeactivateP2WarningPanel();
        }

        if (PlayerWeaponController.P2currentSecondaryLevel < 5 && !P2secondaryCheck)
        {
            if (ScoreTracker.P2credit < 100)
            {
                P2WarningText.text = "You don't have enough credit";
                ActivateP2WarningPanel();

                yield return new WaitForSeconds(1.5f);

                DeactivateP2WarningPanel();
                ActivateP2Shader();
            }
            if (ScoreTracker.P2credit >= 100)
            {
                ScoreTracker.P2credit -= 100;

                P2WarningText.text = "Lucky you these stocks just came in";
                ActivateP2WarningPanel();

                yield return new WaitForSeconds(1.5f);

                DeactivateP2WarningPanel();

                PlayerWeaponController.P2currentSecondaryLevel++;

                P2secondaryShader.SetActive(true);
                P2secondaryCheck = true;
            }
        }
    }
    IEnumerator P2AmmoAdd()
    {
        if (PlayerWeaponController.P2superAmmo >= 5)
        {
            PlayerWeaponController.P2superAmmo = 5;

            P2WarningText.text = "Your ship only have sapce for 5 super charge";
            ActivateP2WarningPanel();

            yield return new WaitForSeconds(1.5f);

            DeactivateP2WarningPanel();

            P2specialShader.SetActive(true);
        }

        if (PlayerWeaponController.P2superAmmo < 5)
        {
            if (ScoreTracker.P2credit < 100)
            {
                P2WarningText.text = "You don't have enough credit";
                ActivateP2WarningPanel();

                yield return new WaitForSeconds(1.5f);

                DeactivateP2WarningPanel();
                ActivateP2Shader();
            }
            if (ScoreTracker.P2credit >= 100)
            {
                ScoreTracker.P2credit -= 100;

                P2WarningText.text = "Your ship has enough space to store these";
                ActivateP2WarningPanel();

                yield return new WaitForSeconds(1.5f);

                DeactivateP2WarningPanel();

                PlayerWeaponController.P2superAmmo++;
            }
        }
    }
    IEnumerator P2ShipSwitch()
    {
        P2WarningText.text = "It cost 1000 credit to swapping out your current ship";
        ActivateP2WarningPanel();

        yield return new WaitForSeconds(1.5f);

        DeactivateP2WarningPanel();

        ResetP2SwitchBool();
        P2switch = true;
        P2shipSwitch = true;
    }
    IEnumerator P2PrimarySwitch()
    {
        P2WarningText.text = "Your current primary level is: " + PlayerWeaponController.P2currentWLevel + ". It cost 1000 credit to swapping out your current primary";
        ActivateP2WarningPanel();

        yield return new WaitForSeconds(1.5f);

        DeactivateP2WarningPanel();

        ResetP2SwitchBool();
        P2switch = true;
        P2primarySwitch = true;
    }
    IEnumerator P2SecondarySwitch()
    {
        P2WarningText.text = "Your current secondary level is: " + PlayerWeaponController.P2currentSecondaryLevel + ". It cost 1000 credit to swapping out your current secondary";
        ActivateP2WarningPanel();

        yield return new WaitForSeconds(1.5f);

        DeactivateP2WarningPanel();

        ResetP2SwitchBool();
        P2switch = true;
        P2secondarySwitch = true;
    }

    IEnumerator P1TestMachineGun()
    {
        P1testingDone = false;
        P1testing = true;
        P1toggleData = 1;

        for (int counter = 0; counter < 4; counter++)
        {
            CheckP1Primary();
            yield return new WaitForSeconds(.5f);
        }

        P1testingDone = true;
    }
    IEnumerator P1TestFlakCannon()
    {
        P1testingDone = false;
        P1testing = true;

        CheckP1Primary();
        yield return new WaitForSeconds(1f);

        P1testingDone = true;
    }
    IEnumerator P1TestPAC()
    {
        P1testingDone = false;
        P1testing = true;
        P1toggleData = 3;

        CheckP1Primary();
        yield return new WaitForSeconds(1f);

        P1testingDone = true;
    }
    IEnumerator P1TestHomingMissiles()
    {
        P1testingDone = false;
        P1testing = true;
        P1toggleData = 1;

        if(PlayerWeaponController.P1currentSecondaryLevel % 2 == 1)
        {
            for (int counter = 0; counter < 2; counter++)
            {
                CheckP1Secondary();
                yield return new WaitForSeconds(3f);
            }
        }
        if (PlayerWeaponController.P1currentSecondaryLevel % 2 == 0)
        {
            for (int counter = 0; counter < 2; counter++)
            {
                CheckP1Secondary();
                yield return new WaitForSeconds(1f);
            }
        }

        P1testingDone = true;
    }
    IEnumerator P1TestSweeperPods()
    {
        P1testingDone = false;
        P1testing = true;

        if (PlayerWeaponController.P1currentSecondaryLevel % 2 == 1)
        {
            for (int counter = 0; counter < 2; counter++)
            {
                CheckP1Secondary();
                yield return new WaitForSeconds(3f);
            }
        }
        if (PlayerWeaponController.P1currentSecondaryLevel % 2 == 0)
        {
            for (int counter = 0; counter < 2; counter++)
            {
                CheckP1Secondary();
                yield return new WaitForSeconds(1f);
            }
        }

        P1testingDone = true;
    }
    IEnumerator P1TestPlasmaBullet()
    {
        P1testingDone = false;
        P1testing = true;
        P1toggleData = 3;

        if (PlayerWeaponController.P1currentSecondaryLevel % 2 == 1)
        {
            for (int counter = 0; counter < 2; counter++)
            {
                CheckP1Secondary();
                yield return new WaitForSeconds(3f);
            }
        }
        if (PlayerWeaponController.P1currentSecondaryLevel % 2 == 0)
        {
            for (int counter = 0; counter < 2; counter++)
            {
                CheckP1Secondary();
                yield return new WaitForSeconds(1f);
            }
        }

        P1testingDone = true;
    }

    IEnumerator P2TestMachineGun()
    {
        P2testingDone = false;
        P2testing = true;
        P2toggleData = 1;

        for (int counter = 0; counter < 4; counter++)
        {
            CheckP2Primary();
            yield return new WaitForSeconds(.5f);
        }

        P2testingDone = true;
    }
    IEnumerator P2TestFlakCannon()
    {
        P2testingDone = false;
        P2testing = true;

        CheckP2Primary();
        yield return new WaitForSeconds(1f);

        P2testingDone = true;
    }
    IEnumerator P2TestPAC()
    {
        P2testingDone = false;
        P2testing = true;
        P2toggleData = 3;

        CheckP2Primary();
        yield return new WaitForSeconds(1f);

        P2testingDone = true;
    }
    IEnumerator P2TestHomingMissiles()
    {
        P2testingDone = false;
        P2testing = true;
        P2toggleData = 1;

        if (PlayerWeaponController.P2currentSecondaryLevel % 2 == 1)
        {
            for (int counter = 0; counter < 2; counter++)
            {
                CheckP2Secondary();
                yield return new WaitForSeconds(3f);
            }
        }
        if (PlayerWeaponController.P2currentSecondaryLevel % 2 == 0)
        {
            for (int counter = 0; counter < 2; counter++)
            {
                CheckP2Secondary();
                yield return new WaitForSeconds(1f);
            }
        }

        P2testingDone = true;
    }
    IEnumerator P2TestSweeperPods()
    {
        P2testingDone = false;
        P2testing = true;

        if (PlayerWeaponController.P2currentSecondaryLevel % 2 == 1)
        {
            for (int counter = 0; counter < 2; counter++)
            {
                CheckP2Secondary();
                yield return new WaitForSeconds(3f);
            }
        }
        if (PlayerWeaponController.P2currentSecondaryLevel % 2 == 0)
        {
            for (int counter = 0; counter < 2; counter++)
            {
                CheckP2Secondary();
                yield return new WaitForSeconds(1f);
            }
        }

        P2testingDone = true;
    }
    IEnumerator P2TestPlasmaBullet()
    {
        P2testingDone = false;
        P2testing = true;
        P2toggleData = 3;

        if (PlayerWeaponController.P2currentSecondaryLevel % 2 == 1)
        {
            for (int counter = 0; counter < 2; counter++)
            {
                CheckP2Secondary();
                yield return new WaitForSeconds(3f);
            }
        }
        if (PlayerWeaponController.P2currentSecondaryLevel % 2 == 0)
        {
            for (int counter = 0; counter < 2; counter++)
            {
                CheckP2Secondary();
                yield return new WaitForSeconds(1f);
            }
        }

        P2testingDone = true;
    }

    IEnumerator P1ShipChange()
    {
        if (ScoreTracker.P1credit < 1000)
        {
            P1WarningText.text = "You don't have enough credit";
            ActivateP1WarningPanel();

            yield return new WaitForSeconds(2.5f);

            DeactivateP1WarningPanel();
        }
        if (ScoreTracker.P1credit >= 1000)
        {
            ScoreTracker.P1credit -= 1000;
            SelectionMenuController.P1shipType = P1toggleData;

            P1WarningText.text = "Thank you for your purchases";
            ActivateP1WarningPanel();

            yield return new WaitForSeconds(2.5f);

            DeactivateP1WarningPanel();
        }

        DeactivateP1Ships();
        ActivateP1Ships();

        P1switch = false;
    }
    IEnumerator P1PrimaryChange()
    {
        if (ScoreTracker.P1credit < 1000)
        {
            P1WarningText.text = "You don't have enough credit";
            ActivateP1WarningPanel();

            yield return new WaitForSeconds(2.5f);

            DeactivateP1WarningPanel();
        }
        if (ScoreTracker.P1credit >= 1000)
        {
            ScoreTracker.P1credit -= 1000;
            SelectionMenuController.P1primaryType = P1toggleData;

            P1WarningText.text = "Thank you for your purchases";
            ActivateP1WarningPanel();

            yield return new WaitForSeconds(2.5f);

            DeactivateP1WarningPanel();
        }

        P1switch = false;
    }
    IEnumerator P1SecondaryChange()
    {
        if (ScoreTracker.P1credit < 1000)
        {
            P1WarningText.text = "You don't have enough credit";
            ActivateP1WarningPanel();

            yield return new WaitForSeconds(2.5f);

            DeactivateP1WarningPanel();
        }
        if (ScoreTracker.P1credit >= 1000)
        {
            ScoreTracker.P1credit -= 1000;
            SelectionMenuController.P1secondaryType = P1toggleData;

            P1WarningText.text = "Thank you for your purchases";
            ActivateP1WarningPanel();

            yield return new WaitForSeconds(2.5f);

            DeactivateP1WarningPanel();
        }

        P1switch = false;
    }

    IEnumerator P2ShipChange()
    {
        if (ScoreTracker.P2credit < 1000)
        {
            P2WarningText.text = "You don't have enough credit";
            ActivateP2WarningPanel();

            yield return new WaitForSeconds(2.5f);

            DeactivateP2WarningPanel();
        }
        if (ScoreTracker.P2credit >= 1000)
        {
            ScoreTracker.P2credit -= 1000;
            SelectionMenuController.P2shipType = P2toggleData;

            P2WarningText.text = "Thank you for your purchases";
            ActivateP2WarningPanel();

            yield return new WaitForSeconds(2.5f);

            DeactivateP2WarningPanel();
        }

        DeactivateP2Ships();
        ActivateP2Ships();

        P2switch = false;
    }
    IEnumerator P2PrimaryChange()
    {
        if (ScoreTracker.P2credit < 1000)
        {
            P2WarningText.text = "You don't have enough credit";
            ActivateP2WarningPanel();

            yield return new WaitForSeconds(2.5f);

            DeactivateP2WarningPanel();
        }
        if (ScoreTracker.P2credit >= 1000)
        {
            ScoreTracker.P2credit -= 1000;
            SelectionMenuController.P2primaryType = P2toggleData;

            P2WarningText.text = "Thank you for your purchases";
            ActivateP2WarningPanel();

            yield return new WaitForSeconds(2.5f);

            DeactivateP2WarningPanel();
        }

        P2switch = false;
    }
    IEnumerator P2SecondaryChange()
    {
        if (ScoreTracker.P2credit < 1000)
        {
            P2WarningText.text = "You don't have enough credit";
            ActivateP2WarningPanel();

            yield return new WaitForSeconds(2.5f);

            DeactivateP2WarningPanel();
        }
        if (ScoreTracker.P2credit >= 1000)
        {
            ScoreTracker.P2credit -= 1000;
            SelectionMenuController.P2secondaryType = P2toggleData;

            P2WarningText.text = "Thank you for your purchases";
            ActivateP2WarningPanel();

            yield return new WaitForSeconds(2.5f);

            DeactivateP2WarningPanel();
        }

        P2switch = false;
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

    private void ActivateP1Shader()
    {
        P1healthShader.SetActive(true);
        P1shieldShader.SetActive(true);
        P1liveShader.SetActive(true);
        P1primaryShader.SetActive(true);
        P1secondaryShader.SetActive(true);
        P1specialShader.SetActive(true);
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

    private void ActivateP2Shader()
    {
        P2healthShader.SetActive(true);
        P2shieldShader.SetActive(true);
        P2liveShader.SetActive(true);
        P2primaryShader.SetActive(true);
        P2secondaryShader.SetActive(true);
        P2specialShader.SetActive(true);
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
        if (SelectionMenuController.P1shipType == 1)
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
        if (SelectionMenuController.P2shipType == 1)
        {
            P2ship1.SetActive(true);
        }
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
        P1WarningText.enabled = true;
        P1warning = true;
        P1Warning.SetActive(true);
    }
    private void DeactivateP1WarningPanel()
    {
        P1WarningText.enabled = false;
        P1warning = false;
        P1Warning.SetActive(false);
    }

    private void ActivateP2WarningPanel()
    {
        P2WarningText.enabled = true;
        P2warning = true;
        P2Warning.SetActive(true);
    }
    private void DeactivateP2WarningPanel()
    {
        P2WarningText.enabled = false;
        P2warning = false;
        P2Warning.SetActive(false);
    }

    private void ResetP1ToggleData()
    {
        P1toggleData = 1;
    }
    private void ResetP2ToggleData()
    {
        P2toggleData = 1;
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

    private void ResetP1SwitchBool()
    {
        P1shipSwitch = false;
        P1primarySwitch = false;
        P1secondarySwitch = false;
    }
    private void ResetP2SwitchBool()
    {
        P2shipSwitch = false;
        P2primarySwitch = false;
        P2secondarySwitch = false;
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

    private void CheckP1Primary()
    {
        if (P1toggleData == 1)
        {
            if (PlayerWeaponController.P1currentWLevel <= 1)
            {
                Instantiate(machineGunBullet, P1primarySpawnPoint[0].position, P1primarySpawnPoint[0].rotation);
            }
            if (PlayerWeaponController.P1currentWLevel == 2)
            {
                Instantiate(machineGunBullet, P1primarySpawnPoint[1].position, P1primarySpawnPoint[1].rotation);
                Instantiate(machineGunBullet, P1primarySpawnPoint[2].position, P1primarySpawnPoint[2].rotation);
            }
            if (PlayerWeaponController.P1currentWLevel == 3)
            {
                Instantiate(machineGunBullet, P1primarySpawnPoint[0].position, P1primarySpawnPoint[0].rotation);
                Instantiate(machineGunBullet, P1primarySpawnPoint[1].position, P1primarySpawnPoint[1].rotation);
                Instantiate(machineGunBullet, P1primarySpawnPoint[2].position, P1primarySpawnPoint[2].rotation);
            }
            if (PlayerWeaponController.P1currentWLevel == 4)
            {
                Instantiate(machineGunBullet, P1primarySpawnPoint[0].position, P1primarySpawnPoint[0].rotation);
                Instantiate(machineGunBullet, P1primarySpawnPoint[1].position, P1primarySpawnPoint[1].rotation);
                Instantiate(machineGunBullet, P1primarySpawnPoint[2].position, P1primarySpawnPoint[2].rotation);
                Instantiate(machineGunBullet, P1primarySpawnPoint[3].position, P1primarySpawnPoint[3].rotation);
                Instantiate(machineGunBullet, P1primarySpawnPoint[4].position, P1primarySpawnPoint[4].rotation);
            }
            if (PlayerWeaponController.P1currentWLevel >= 5)
            {
                Instantiate(machineGunBullet, P1primarySpawnPoint[0].position, P1primarySpawnPoint[0].rotation);
                Instantiate(machineGunBullet, P1primarySpawnPoint[1].position, P1primarySpawnPoint[1].rotation);
                Instantiate(machineGunBullet, P1primarySpawnPoint[2].position, P1primarySpawnPoint[2].rotation);
                Instantiate(machineGunBullet, P1primarySpawnPoint[3].position, P1primarySpawnPoint[3].rotation);
                Instantiate(machineGunBullet, P1primarySpawnPoint[4].position, P1primarySpawnPoint[4].rotation);
                Instantiate(machineGunBullet, P1primarySpawnPoint[5].position, P1primarySpawnPoint[5].rotation);
                Instantiate(machineGunBullet, P1primarySpawnPoint[6].position, P1primarySpawnPoint[6].rotation);
            }
        }
        if (P1toggleData == 2)
        {
            if (PlayerWeaponController.P1currentWLevel <= 1)
            {
                Instantiate(flakCannonBullet, P1primarySpawnPoint[0].position, P1primarySpawnPoint[0].rotation);
            }
            if (PlayerWeaponController.P1currentWLevel == 2)
            {
                Instantiate(flakCannonBullet, P1primarySpawnPoint[1].position, P1primarySpawnPoint[1].rotation);
                Instantiate(flakCannonBullet, P1primarySpawnPoint[2].position, P1primarySpawnPoint[2].rotation);
            }
            if (PlayerWeaponController.P1currentWLevel == 3)
            {
                Instantiate(flakCannonBullet, P1primarySpawnPoint[0].position, P1primarySpawnPoint[0].rotation);
                Instantiate(flakCannonBullet, P1primarySpawnPoint[1].position, P1primarySpawnPoint[1].rotation);
                Instantiate(flakCannonBullet, P1primarySpawnPoint[2].position, P1primarySpawnPoint[2].rotation);
            }
            if (PlayerWeaponController.P1currentWLevel == 4)
            {
                Instantiate(flakCannonBullet, P1primarySpawnPoint[0].position, P1primarySpawnPoint[0].rotation);
                Instantiate(flakCannonBullet, P1primarySpawnPoint[1].position, P1primarySpawnPoint[1].rotation);
                Instantiate(flakCannonBullet, P1primarySpawnPoint[2].position, P1primarySpawnPoint[2].rotation);
                Instantiate(flakCannonBullet, P1primarySpawnPoint[3].position, P1primarySpawnPoint[3].rotation);
                Instantiate(flakCannonBullet, P1primarySpawnPoint[4].position, P1primarySpawnPoint[4].rotation);
            }
            if (PlayerWeaponController.P1currentWLevel >= 5)
            {
                Instantiate(flakCannonBullet, P1primarySpawnPoint[0].position, P1primarySpawnPoint[0].rotation);
                Instantiate(flakCannonBullet, P1primarySpawnPoint[1].position, P1primarySpawnPoint[1].rotation);
                Instantiate(flakCannonBullet, P1primarySpawnPoint[2].position, P1primarySpawnPoint[2].rotation);
                Instantiate(flakCannonBullet, P1primarySpawnPoint[3].position, P1primarySpawnPoint[3].rotation);
                Instantiate(flakCannonBullet, P1primarySpawnPoint[4].position, P1primarySpawnPoint[4].rotation);
                Instantiate(flakCannonBullet, P1primarySpawnPoint[5].position, P1primarySpawnPoint[5].rotation);
                Instantiate(flakCannonBullet, P1primarySpawnPoint[6].position, P1primarySpawnPoint[6].rotation);
            }
        }
        if (P1toggleData == 3)
        {
            if (PlayerWeaponController.P1currentWLevel <= 1)
            {
                Instantiate(pacBullet, P1primarySpawnPoint[0].position, P1primarySpawnPoint[0].rotation);
            }
            if (PlayerWeaponController.P1currentWLevel == 2)
            {
                Instantiate(pacBullet, P1primarySpawnPoint[1].position, P1primarySpawnPoint[1].rotation);
                Instantiate(pacBullet, P1primarySpawnPoint[2].position, P1primarySpawnPoint[2].rotation);
            }
            if (PlayerWeaponController.P1currentWLevel == 3)
            {
                Instantiate(pacBullet, P1primarySpawnPoint[0].position, P1primarySpawnPoint[0].rotation);
                Instantiate(pacBullet, P1primarySpawnPoint[1].position, P1primarySpawnPoint[1].rotation);
                Instantiate(pacBullet, P1primarySpawnPoint[2].position, P1primarySpawnPoint[2].rotation);
            }
            if (PlayerWeaponController.P1currentWLevel == 4)
            {
                Instantiate(pacBullet, P1primarySpawnPoint[0].position, P1primarySpawnPoint[0].rotation);
                Instantiate(pacBullet, P1primarySpawnPoint[1].position, P1primarySpawnPoint[1].rotation);
                Instantiate(pacBullet, P1primarySpawnPoint[2].position, P1primarySpawnPoint[2].rotation);
                Instantiate(pacBullet, P1primarySpawnPoint[3].position, P1primarySpawnPoint[3].rotation);
                Instantiate(pacBullet, P1primarySpawnPoint[4].position, P1primarySpawnPoint[4].rotation);
            }
            if (PlayerWeaponController.P1currentWLevel >= 5)
            {
                Instantiate(pacBullet, P1primarySpawnPoint[0].position, P1primarySpawnPoint[0].rotation);
                Instantiate(pacBullet, P1primarySpawnPoint[1].position, P1primarySpawnPoint[1].rotation);
                Instantiate(pacBullet, P1primarySpawnPoint[2].position, P1primarySpawnPoint[2].rotation);
                Instantiate(pacBullet, P1primarySpawnPoint[3].position, P1primarySpawnPoint[3].rotation);
                Instantiate(pacBullet, P1primarySpawnPoint[4].position, P1primarySpawnPoint[4].rotation);
                Instantiate(pacBullet, P1primarySpawnPoint[5].position, P1primarySpawnPoint[5].rotation);
                Instantiate(pacBullet, P1primarySpawnPoint[6].position, P1primarySpawnPoint[6].rotation);
            }
        }
    }
    private void CheckP2Primary()
    {
        if (P2toggleData == 1)
        {
            if (PlayerWeaponController.P2currentWLevel <= 1)
            {
                Instantiate(machineGunBullet, P2primarySpawnPoint[0].position, P2primarySpawnPoint[0].rotation);
            }
            if (PlayerWeaponController.P2currentWLevel == 2)
            {
                Instantiate(machineGunBullet, P2primarySpawnPoint[1].position, P2primarySpawnPoint[1].rotation);
                Instantiate(machineGunBullet, P2primarySpawnPoint[2].position, P2primarySpawnPoint[2].rotation);
            }
            if (PlayerWeaponController.P2currentWLevel == 3)
            {
                Instantiate(machineGunBullet, P2primarySpawnPoint[0].position, P2primarySpawnPoint[0].rotation);
                Instantiate(machineGunBullet, P2primarySpawnPoint[1].position, P2primarySpawnPoint[1].rotation);
                Instantiate(machineGunBullet, P2primarySpawnPoint[2].position, P2primarySpawnPoint[2].rotation);
            }
            if (PlayerWeaponController.P2currentWLevel == 4)
            {
                Instantiate(machineGunBullet, P2primarySpawnPoint[0].position, P2primarySpawnPoint[0].rotation);
                Instantiate(machineGunBullet, P2primarySpawnPoint[1].position, P2primarySpawnPoint[1].rotation);
                Instantiate(machineGunBullet, P2primarySpawnPoint[2].position, P2primarySpawnPoint[2].rotation);
                Instantiate(machineGunBullet, P2primarySpawnPoint[3].position, P2primarySpawnPoint[3].rotation);
                Instantiate(machineGunBullet, P2primarySpawnPoint[4].position, P2primarySpawnPoint[4].rotation);
            }
            if (PlayerWeaponController.P2currentWLevel >= 5)
            {
                Instantiate(machineGunBullet, P2primarySpawnPoint[0].position, P2primarySpawnPoint[0].rotation);
                Instantiate(machineGunBullet, P2primarySpawnPoint[1].position, P2primarySpawnPoint[1].rotation);
                Instantiate(machineGunBullet, P2primarySpawnPoint[2].position, P2primarySpawnPoint[2].rotation);
                Instantiate(machineGunBullet, P2primarySpawnPoint[3].position, P2primarySpawnPoint[3].rotation);
                Instantiate(machineGunBullet, P2primarySpawnPoint[4].position, P2primarySpawnPoint[4].rotation);
                Instantiate(machineGunBullet, P2primarySpawnPoint[5].position, P2primarySpawnPoint[5].rotation);
                Instantiate(machineGunBullet, P2primarySpawnPoint[6].position, P2primarySpawnPoint[6].rotation);
            }
        }
        if (P2toggleData == 2)
        {
            if (PlayerWeaponController.P2currentWLevel <= 1)
            {
                Instantiate(flakCannonBullet, P2primarySpawnPoint[0].position, P2primarySpawnPoint[0].rotation);
            }
            if (PlayerWeaponController.P2currentWLevel == 2)
            {
                Instantiate(flakCannonBullet, P2primarySpawnPoint[1].position, P2primarySpawnPoint[1].rotation);
                Instantiate(flakCannonBullet, P2primarySpawnPoint[2].position, P2primarySpawnPoint[2].rotation);
            }
            if (PlayerWeaponController.P2currentWLevel == 3)
            {
                Instantiate(flakCannonBullet, P2primarySpawnPoint[0].position, P2primarySpawnPoint[0].rotation);
                Instantiate(flakCannonBullet, P2primarySpawnPoint[1].position, P2primarySpawnPoint[1].rotation);
                Instantiate(flakCannonBullet, P2primarySpawnPoint[2].position, P2primarySpawnPoint[2].rotation);
            }
            if (PlayerWeaponController.P2currentWLevel == 4)
            {
                Instantiate(flakCannonBullet, P2primarySpawnPoint[0].position, P2primarySpawnPoint[0].rotation);
                Instantiate(flakCannonBullet, P2primarySpawnPoint[1].position, P2primarySpawnPoint[1].rotation);
                Instantiate(flakCannonBullet, P2primarySpawnPoint[2].position, P2primarySpawnPoint[2].rotation);
                Instantiate(flakCannonBullet, P2primarySpawnPoint[3].position, P2primarySpawnPoint[3].rotation);
                Instantiate(flakCannonBullet, P2primarySpawnPoint[4].position, P2primarySpawnPoint[4].rotation);
            }
            if (PlayerWeaponController.P2currentWLevel >= 5)
            {
                Instantiate(flakCannonBullet, P2primarySpawnPoint[0].position, P2primarySpawnPoint[0].rotation);
                Instantiate(flakCannonBullet, P2primarySpawnPoint[1].position, P2primarySpawnPoint[1].rotation);
                Instantiate(flakCannonBullet, P2primarySpawnPoint[2].position, P2primarySpawnPoint[2].rotation);
                Instantiate(flakCannonBullet, P2primarySpawnPoint[3].position, P2primarySpawnPoint[3].rotation);
                Instantiate(flakCannonBullet, P2primarySpawnPoint[4].position, P2primarySpawnPoint[4].rotation);
                Instantiate(flakCannonBullet, P2primarySpawnPoint[5].position, P2primarySpawnPoint[5].rotation);
                Instantiate(flakCannonBullet, P2primarySpawnPoint[6].position, P2primarySpawnPoint[6].rotation);
            }
        }
        if (P2toggleData == 3)
        {
            if (PlayerWeaponController.P2currentWLevel <= 1)
            {
                Instantiate(pacBullet, P2primarySpawnPoint[0].position, P2primarySpawnPoint[0].rotation);
            }
            if (PlayerWeaponController.P2currentWLevel == 2)
            {
                Instantiate(pacBullet, P2primarySpawnPoint[1].position, P2primarySpawnPoint[1].rotation);
                Instantiate(pacBullet, P2primarySpawnPoint[2].position, P2primarySpawnPoint[2].rotation);
            }
            if (PlayerWeaponController.P2currentWLevel == 3)
            {
                Instantiate(pacBullet, P2primarySpawnPoint[0].position, P2primarySpawnPoint[0].rotation);
                Instantiate(pacBullet, P2primarySpawnPoint[1].position, P2primarySpawnPoint[1].rotation);
                Instantiate(pacBullet, P2primarySpawnPoint[2].position, P2primarySpawnPoint[2].rotation);
            }
            if (PlayerWeaponController.P2currentWLevel == 4)
            {
                Instantiate(pacBullet, P2primarySpawnPoint[0].position, P2primarySpawnPoint[0].rotation);
                Instantiate(pacBullet, P2primarySpawnPoint[1].position, P2primarySpawnPoint[1].rotation);
                Instantiate(pacBullet, P2primarySpawnPoint[2].position, P2primarySpawnPoint[2].rotation);
                Instantiate(pacBullet, P2primarySpawnPoint[3].position, P2primarySpawnPoint[3].rotation);
                Instantiate(pacBullet, P2primarySpawnPoint[4].position, P2primarySpawnPoint[4].rotation);
            }
            if (PlayerWeaponController.P2currentWLevel >= 5)
            {
                Instantiate(pacBullet, P2primarySpawnPoint[0].position, P2primarySpawnPoint[0].rotation);
                Instantiate(pacBullet, P2primarySpawnPoint[1].position, P2primarySpawnPoint[1].rotation);
                Instantiate(pacBullet, P2primarySpawnPoint[2].position, P2primarySpawnPoint[2].rotation);
                Instantiate(pacBullet, P2primarySpawnPoint[3].position, P2primarySpawnPoint[3].rotation);
                Instantiate(pacBullet, P2primarySpawnPoint[4].position, P2primarySpawnPoint[4].rotation);
                Instantiate(pacBullet, P2primarySpawnPoint[5].position, P2primarySpawnPoint[5].rotation);
                Instantiate(pacBullet, P2primarySpawnPoint[6].position, P2primarySpawnPoint[6].rotation);
            }
        }
    }

    private void CheckP1Secondary()
    {
        if (P1toggleData == 1)
        {
            if (PlayerWeaponController.P1currentSecondaryLevel <= 1 || PlayerWeaponController.P1currentSecondaryLevel == 2)
            {
                Instantiate(homingMissiles, P1secondarySpawnPoint[0].position, P1secondarySpawnPoint[0].rotation);
                Instantiate(homingMissiles, P1secondarySpawnPoint[1].position, P1secondarySpawnPoint[1].rotation);
            }
            if (PlayerWeaponController.P1currentSecondaryLevel == 3 || PlayerWeaponController.P1currentSecondaryLevel == 4)
            {
                Instantiate(homingMissiles, P1secondarySpawnPoint[2].position, P1secondarySpawnPoint[2].rotation);
                Instantiate(homingMissiles, P1secondarySpawnPoint[3].position, P1secondarySpawnPoint[3].rotation);
                Instantiate(homingMissiles, P1secondarySpawnPoint[4].position, P1secondarySpawnPoint[4].rotation);
                Instantiate(homingMissiles, P1secondarySpawnPoint[5].position, P1secondarySpawnPoint[5].rotation);
            }
            if (PlayerWeaponController.P1currentSecondaryLevel >= 5)
            {
                Instantiate(homingMissiles, P1secondarySpawnPoint[0].position, P1secondarySpawnPoint[0].rotation);
                Instantiate(homingMissiles, P1secondarySpawnPoint[1].position, P1secondarySpawnPoint[1].rotation);
                Instantiate(homingMissiles, P1secondarySpawnPoint[2].position, P1secondarySpawnPoint[2].rotation);
                Instantiate(homingMissiles, P1secondarySpawnPoint[3].position, P1secondarySpawnPoint[3].rotation);
                Instantiate(homingMissiles, P1secondarySpawnPoint[4].position, P1secondarySpawnPoint[4].rotation);
                Instantiate(homingMissiles, P1secondarySpawnPoint[5].position, P1secondarySpawnPoint[5].rotation);
            }
        }
        if (P1toggleData == 2)
        {
            if (PlayerWeaponController.P1currentSecondaryLevel <= 1 || PlayerWeaponController.P1currentSecondaryLevel == 2)
            {
                Instantiate(sweeperPods, P1secondarySpawnPoint[0].position, P1secondarySpawnPoint[0].rotation);
                Instantiate(sweeperPods, P1secondarySpawnPoint[1].position, P1secondarySpawnPoint[1].rotation);
            }
            if (PlayerWeaponController.P1currentSecondaryLevel == 3 || PlayerWeaponController.P1currentSecondaryLevel == 4)
            {
                Instantiate(sweeperPods, P1secondarySpawnPoint[2].position, P1secondarySpawnPoint[2].rotation);
                Instantiate(sweeperPods, P1secondarySpawnPoint[3].position, P1secondarySpawnPoint[3].rotation);
                Instantiate(sweeperPods, P1secondarySpawnPoint[4].position, P1secondarySpawnPoint[4].rotation);
                Instantiate(sweeperPods, P1secondarySpawnPoint[5].position, P1secondarySpawnPoint[5].rotation);
            }
            if (PlayerWeaponController.P1currentSecondaryLevel >= 5)
            {
                Instantiate(sweeperPods, P1secondarySpawnPoint[0].position, P1secondarySpawnPoint[0].rotation);
                Instantiate(sweeperPods, P1secondarySpawnPoint[1].position, P1secondarySpawnPoint[1].rotation);
                Instantiate(sweeperPods, P1secondarySpawnPoint[2].position, P1secondarySpawnPoint[2].rotation);
                Instantiate(sweeperPods, P1secondarySpawnPoint[3].position, P1secondarySpawnPoint[3].rotation);
                Instantiate(sweeperPods, P1secondarySpawnPoint[4].position, P1secondarySpawnPoint[4].rotation);
                Instantiate(sweeperPods, P1secondarySpawnPoint[5].position, P1secondarySpawnPoint[5].rotation);
            }
        }
        if (P1toggleData == 3)
        {
            if (PlayerWeaponController.P1currentSecondaryLevel <= 1 || PlayerWeaponController.P1currentSecondaryLevel == 2)
            {
                Instantiate(plasmaBullet, P1secondarySpawnPoint[0].position, P1secondarySpawnPoint[0].rotation);
                Instantiate(plasmaBullet, P1secondarySpawnPoint[1].position, P1secondarySpawnPoint[1].rotation);
            }
            if (PlayerWeaponController.P1currentSecondaryLevel == 3 || PlayerWeaponController.P1currentSecondaryLevel == 4)
            {
                Instantiate(plasmaBullet, P1secondarySpawnPoint[2].position, P1secondarySpawnPoint[2].rotation);
                Instantiate(plasmaBullet, P1secondarySpawnPoint[3].position, P1secondarySpawnPoint[3].rotation);
                Instantiate(plasmaBullet, P1secondarySpawnPoint[4].position, P1secondarySpawnPoint[4].rotation);
                Instantiate(plasmaBullet, P1secondarySpawnPoint[5].position, P1secondarySpawnPoint[5].rotation);
            }
            if (PlayerWeaponController.P1currentSecondaryLevel >= 5)
            {
                Instantiate(plasmaBullet, P1secondarySpawnPoint[0].position, P1secondarySpawnPoint[0].rotation);
                Instantiate(plasmaBullet, P1secondarySpawnPoint[1].position, P1secondarySpawnPoint[1].rotation);
                Instantiate(plasmaBullet, P1secondarySpawnPoint[2].position, P1secondarySpawnPoint[2].rotation);
                Instantiate(plasmaBullet, P1secondarySpawnPoint[3].position, P1secondarySpawnPoint[3].rotation);
                Instantiate(plasmaBullet, P1secondarySpawnPoint[4].position, P1secondarySpawnPoint[4].rotation);
                Instantiate(plasmaBullet, P1secondarySpawnPoint[5].position, P1secondarySpawnPoint[5].rotation);
            }
        }
    }
    private void CheckP2Secondary()
    {
        if (P2toggleData == 1)
        {
            if (PlayerWeaponController.P2currentSecondaryLevel <= 1 || PlayerWeaponController.P2currentSecondaryLevel == 2)
            {
                Instantiate(homingMissiles, P2secondarySpawnPoint[0].position, P2secondarySpawnPoint[0].rotation);
                Instantiate(homingMissiles, P2secondarySpawnPoint[1].position, P2secondarySpawnPoint[1].rotation);
            }
            if (PlayerWeaponController.P2currentSecondaryLevel == 3 || PlayerWeaponController.P2currentSecondaryLevel == 4)
            {
                Instantiate(homingMissiles, P2secondarySpawnPoint[2].position, P2secondarySpawnPoint[2].rotation);
                Instantiate(homingMissiles, P2secondarySpawnPoint[3].position, P2secondarySpawnPoint[3].rotation);
                Instantiate(homingMissiles, P2secondarySpawnPoint[4].position, P2secondarySpawnPoint[4].rotation);
                Instantiate(homingMissiles, P2secondarySpawnPoint[5].position, P2secondarySpawnPoint[5].rotation);
            }
            if (PlayerWeaponController.P2currentSecondaryLevel >= 5)
            {
                Instantiate(homingMissiles, P2secondarySpawnPoint[0].position, P2secondarySpawnPoint[0].rotation);
                Instantiate(homingMissiles, P2secondarySpawnPoint[1].position, P2secondarySpawnPoint[1].rotation);
                Instantiate(homingMissiles, P2secondarySpawnPoint[2].position, P2secondarySpawnPoint[2].rotation);
                Instantiate(homingMissiles, P2secondarySpawnPoint[3].position, P2secondarySpawnPoint[3].rotation);
                Instantiate(homingMissiles, P2secondarySpawnPoint[4].position, P2secondarySpawnPoint[4].rotation);
                Instantiate(homingMissiles, P2secondarySpawnPoint[5].position, P2secondarySpawnPoint[5].rotation);
            }
        }
        if (P2toggleData == 2)
        {
            if (PlayerWeaponController.P2currentSecondaryLevel <= 1 || PlayerWeaponController.P2currentSecondaryLevel == 2)
            {
                Instantiate(sweeperPods, P2secondarySpawnPoint[0].position, P2secondarySpawnPoint[0].rotation);
                Instantiate(sweeperPods, P2secondarySpawnPoint[1].position, P2secondarySpawnPoint[1].rotation);
            }
            if (PlayerWeaponController.P2currentSecondaryLevel == 3 || PlayerWeaponController.P2currentSecondaryLevel == 4)
            {
                Instantiate(sweeperPods, P2secondarySpawnPoint[2].position, P2secondarySpawnPoint[2].rotation);
                Instantiate(sweeperPods, P2secondarySpawnPoint[3].position, P2secondarySpawnPoint[3].rotation);
                Instantiate(sweeperPods, P2secondarySpawnPoint[4].position, P2secondarySpawnPoint[4].rotation);
                Instantiate(sweeperPods, P2secondarySpawnPoint[5].position, P2secondarySpawnPoint[5].rotation);
            }
            if (PlayerWeaponController.P2currentSecondaryLevel >= 5)
            {
                Instantiate(sweeperPods, P2secondarySpawnPoint[0].position, P2secondarySpawnPoint[0].rotation);
                Instantiate(sweeperPods, P2secondarySpawnPoint[1].position, P2secondarySpawnPoint[1].rotation);
                Instantiate(sweeperPods, P2secondarySpawnPoint[2].position, P2secondarySpawnPoint[2].rotation);
                Instantiate(sweeperPods, P2secondarySpawnPoint[3].position, P2secondarySpawnPoint[3].rotation);
                Instantiate(sweeperPods, P2secondarySpawnPoint[4].position, P2secondarySpawnPoint[4].rotation);
                Instantiate(sweeperPods, P2secondarySpawnPoint[5].position, P2secondarySpawnPoint[5].rotation);
            }
        }
        if (P2toggleData == 3)
        {
            if (PlayerWeaponController.P2currentSecondaryLevel <= 1 || PlayerWeaponController.P2currentSecondaryLevel == 2)
            {
                Instantiate(plasmaBullet, P2secondarySpawnPoint[0].position, P2secondarySpawnPoint[0].rotation);
                Instantiate(plasmaBullet, P2secondarySpawnPoint[1].position, P2secondarySpawnPoint[1].rotation);
            }
            if (PlayerWeaponController.P2currentSecondaryLevel == 3 || PlayerWeaponController.P2currentSecondaryLevel == 4)
            {
                Instantiate(plasmaBullet, P2secondarySpawnPoint[2].position, P2secondarySpawnPoint[2].rotation);
                Instantiate(plasmaBullet, P2secondarySpawnPoint[3].position, P2secondarySpawnPoint[3].rotation);
                Instantiate(plasmaBullet, P2secondarySpawnPoint[4].position, P2secondarySpawnPoint[4].rotation);
                Instantiate(plasmaBullet, P2secondarySpawnPoint[5].position, P2secondarySpawnPoint[5].rotation);
            }
            if (PlayerWeaponController.P2currentSecondaryLevel >= 5)
            {
                Instantiate(plasmaBullet, P2secondarySpawnPoint[0].position, P2secondarySpawnPoint[0].rotation);
                Instantiate(plasmaBullet, P2secondarySpawnPoint[1].position, P2secondarySpawnPoint[1].rotation);
                Instantiate(plasmaBullet, P2secondarySpawnPoint[2].position, P2secondarySpawnPoint[2].rotation);
                Instantiate(plasmaBullet, P2secondarySpawnPoint[3].position, P2secondarySpawnPoint[3].rotation);
                Instantiate(plasmaBullet, P2secondarySpawnPoint[4].position, P2secondarySpawnPoint[4].rotation);
                Instantiate(plasmaBullet, P2secondarySpawnPoint[5].position, P2secondarySpawnPoint[5].rotation);
            }
        }
    }

    private void RestartButton()
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
        if (MainMenuController.currentStage == 3)
        {
            SceneManager.LoadScene("Level3");
        }
    }

    private void NextButton()
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

            if (PlayerHealthSystem.P1currentLives <0 && !P1buy)
            {
                PlayerHealthSystem.P1savedHealth = PlayerHealthSystem.P1maxHealth;
                PlayerHealthSystem.P1savedShields = PlayerHealthSystem.P1maxShields;
                PlayerHealthSystem.P1savedLives = 0;
            }
            if (PlayerHealthSystem.P2currentLives < 0 && !P2buy)
            {
                PlayerHealthSystem.P2savedHealth = PlayerHealthSystem.P1maxHealth;
                PlayerHealthSystem.P2savedShields = PlayerHealthSystem.P1maxShields;
                PlayerHealthSystem.P2savedLives = 0;
            }
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
        if (MainMenuController.currentStage > 3)
        {
            SceneManager.LoadScene("Credit");
        }
    }

    private void ScrollingSound()
    {
        buttonSoundEffect[0].Stop();
        buttonSoundEffect[0].clip = soundEffect[0];
        buttonSoundEffect[0].Play();
    }
}