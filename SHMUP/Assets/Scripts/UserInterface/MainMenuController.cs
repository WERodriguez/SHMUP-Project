using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    private int glowTracker;
    private int controlGlowTracker;
	private bool waiting;
    private bool controlList;

    public bool arcadeBuild;
    public bool limbitlessBuild;

    public static int currentStage;
    public static bool onePlayer;
	public static bool arcadeQuit;

    public GameObject mainMenuCanvas;
    public GameObject mainMenuBackground;
    public GameObject controlMenuBackground;
    public GameObject controlMenu;
    public GameObject controlInGame;
    public GameObject buttonList;
    public GameObject singleButton;
    public GameObject doubleButton;
    public GameObject quitButton;
    public GameObject controlButton;
    public GameObject creditButton;

    public GameObject[] menuBuildType;
    public GameObject[] inGameBuildType;

    public Image singleGlow;
    public Image doubleGlow;
    public Image quitGlow;
    public Image controlGlow;
    public Image creditGlow;
    public Image rightGlow;
    public Image leftGlow;

    public Text intro;

    public GameObject audioSource;

    private void Awake()
    {
        DeactivateMainMenu();
        DeactivateControlBackground();
        DeactivateControlList();
        DeactivateControlType();
        DeactivateMainMenuGlow();
        DeactivateControlListGlow();
        ResetGlowTracker();

        currentStage = 1;
		waiting = false;
        controlList = false;
		arcadeQuit = false;
    }

    private void Start()
    {
        StartCoroutine(Timer());
    }

    private void Update()
    {
		if (waiting)
		{
            if (!controlList)
            {
                if (glowTracker <= 1)
                {
                    glowTracker = 1;

                    DeactivateMainMenuGlow();

                    singleGlow.fillAmount = 1;
                }
                if (glowTracker == 2)
                {
                    DeactivateMainMenuGlow();

                    doubleGlow.fillAmount = 1;
                }
                if (glowTracker == 3)
                {
                    DeactivateMainMenuGlow();

                    controlGlow.fillAmount = 1;
                }
                if (glowTracker == 4)
                {
                    DeactivateMainMenuGlow();

                    creditGlow.fillAmount = 1;
                }
                if (glowTracker >= 5)
                {
                    glowTracker = 5;

                    DeactivateMainMenuGlow();

                    quitGlow.fillAmount = 1;
                }

                if (Input.GetButtonDown("P1VerticalChoiceUp") || Input.GetButtonDown("P2VerticalChoiceUp") || Input.GetKeyDown(KeyCode.Keypad8))
                {
                    glowTracker--;
                }
                if (Input.GetButtonDown("P1VerticalChoiceDown") || Input.GetButtonDown("P2VerticalChoiceDown") || Input.GetKeyDown(KeyCode.Keypad5))
                {
                    glowTracker++;
                }

                if (Input.GetButtonDown("Fire_P1") || Input.GetButtonDown("Fire_P2") || Input.GetKeyDown(KeyCode.Keypad0) || FlexToggle.myFlexBool == true)
                {
                    FlexToggle.myFlexBool = false;

                    if (glowTracker == 1)
                    {
                        SingleButton();
                    }
                    if (glowTracker == 2)
                    {
                        DoubleButton();
                    }
                    if (glowTracker == 3)
                    {
                        ControlButton();
                    }
                    if (glowTracker == 4)
                    {
                        CreditButton();
                    }
                    if(glowTracker == 5)
                    {
                        QuitButton();
                    }
                }
            }
            else
            {
                if (glowTracker <= 1)
                {
                    glowTracker = 1;
                    
                    if (!arcadeBuild && !limbitlessBuild)
                    {
                        intro.text = "Menu Interaction\n- Keyboard -";

                        DeactivateControlType();
                        menuBuildType[0].SetActive(true);
                        inGameBuildType[0].SetActive(true);
                    }
                    if (arcadeBuild)
                    {
						arcadeQuit = true;

                        intro.text = "Menu Interaction\n- Arcade -";

                        DeactivateControlType();
                        menuBuildType[1].SetActive(true);
                        inGameBuildType[1].SetActive(true);
                    }
                    if (limbitlessBuild)
                    {
                        intro.text = "Menu Interaction\n- LimbitLess -";

                        DeactivateControlType();
                        menuBuildType[2].SetActive(true);
                        inGameBuildType[2].SetActive(true);
                    }

                    DeactivateControlList();
                    controlMenu.SetActive(true);
                }
                if (glowTracker >= 2)
                {
                    glowTracker = 2;

                    if (!arcadeBuild && !limbitlessBuild)
                    {
                        intro.text = "In-Game Interaction\n- Keyboard -";

                        DeactivateControlType();
                        menuBuildType[0].SetActive(true);
                        inGameBuildType[0].SetActive(true);
                    }
                    if (arcadeBuild)
                    {
                        intro.text = "In-Game Interaction\n- Arcade -";

                        DeactivateControlType();
                        menuBuildType[1].SetActive(true);
                        inGameBuildType[1].SetActive(true);
                    }
                    if (limbitlessBuild)
                    {
                        intro.text = "In-Game Interaction\n- LimbitLess -";

                        DeactivateControlType();
                        menuBuildType[2].SetActive(true);
                        inGameBuildType[2].SetActive(true);
                    }

                    DeactivateControlList();
                    controlInGame.SetActive(true);
                }

                if (Input.GetButtonDown("P1HorizontalChoiceRight") || Input.GetButtonDown("P2HorizontalChoiceRight") || Input.GetKeyDown(KeyCode.Keypad6))
                {
                    glowTracker--;

                    DeactivateControlListGlow();
                    rightGlow.fillAmount = 1;
                }
                if (Input.GetButtonDown("P1HorizontalChoiceLeft") || Input.GetButtonDown("P2HorizontalChoiceLeft") || Input.GetKeyDown(KeyCode.Keypad4))
                {
                    glowTracker++;

                    DeactivateControlListGlow();
                    leftGlow.fillAmount = 1;
                }

                if (Input.GetButtonDown("Fire_P1") || Input.GetButtonDown("Fire_P2") || Input.GetKeyDown(KeyCode.Keypad0) || FlexToggle.myFlexBool == true)
                {
                    FlexToggle.myFlexBool = false;
                    DeactivateMainMenuGlow();
                    DeactivateControlBackground();
                    DeactivateControlList();
                    ResetGlowTracker();

                    controlList = false;
                }
            }

			if (arcadeQuit)
			{
				if (Input.GetButtonDown ("ArcadeQuit"))
				{
					Application.Quit ();
				}
			}
		}

        if(!TitleController.fromTitle)
        {
            audioSource.SetActive(true);
        }
        else
        {
            audioSource.SetActive(false);
        }
    }

    IEnumerator Timer()
    {
		ActivateMainMenu();

        yield return new WaitForSeconds(2.5f);
        
        waiting = true;
    }
    private void ActivateMainMenu()
    {
        mainMenuCanvas.SetActive(true);
        buttonList.SetActive(true);
        singleButton.SetActive(true);
        doubleButton.SetActive(true);
        quitButton.SetActive(true);
        controlButton.SetActive(true);
    }
    private void DeactivateMainMenu()
    {
        mainMenuCanvas.SetActive(false);
        buttonList.SetActive(false);
        singleButton.SetActive(false);
        doubleButton.SetActive(false);
        quitButton.SetActive(false);
        controlButton.SetActive(false);
    }

    private void ActivateControlBackground()
    {
        controlMenuBackground.SetActive(true);

        intro.enabled = true;
    }
    private void DeactivateControlBackground()
    {
        controlMenuBackground.SetActive(false);

        intro.enabled = false;
    }

    private void DeactivateControlList()
    {
        controlMenu.SetActive(false);
        controlInGame.SetActive(false);
    }
    private void DeactivateControlType()
    {
        for (int counter = 0; counter < 3; counter++)
        {
            menuBuildType[counter].SetActive(false);
            inGameBuildType[counter].SetActive(false);
            Debug.Log(counter);
        }
    }

    private void DeactivateMainMenuGlow()
    {
        singleGlow.fillAmount = 0;
        doubleGlow.fillAmount = 0;
        quitGlow.fillAmount = 0;
        controlGlow.fillAmount = 0;
        creditGlow.fillAmount = 0;
    }

    private void DeactivateControlListGlow()
    {
        rightGlow.fillAmount = 0;
        leftGlow.fillAmount = 0;
    }

    private void ResetGlowTracker()
    {
        glowTracker = 1;
        controlGlowTracker = 1;
    }

    private void SingleButton()
    {
        DestroyMusic();

        onePlayer = true;
        SceneManager.LoadScene("SelectionMenu");
    }

    private void DoubleButton()
    {
        DestroyMusic();

        onePlayer = false;
        SceneManager.LoadScene("SelectionMenu");
    }

    private void ControlButton()
    {
        DeactivateMainMenuGlow();
        ActivateControlBackground();
        ResetGlowTracker();

        controlList = true;
    }

    private void CreditButton()
    {
        DestroyMusic();

        SceneManager.LoadScene("Credit");
    }

    private void QuitButton()
    {
        Application.Quit();
    }

    private void DestroyMusic()
    {
        Destroy(GameObject.Find("MenuMusicController"));
        Destroy(GameObject.Find("HangarMusicController"));

        TitleController.fromTitle = false;
    }
}
