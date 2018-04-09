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

    public Image singleGlow;
    public Image doubleGlow;
    public Image quitGlow;
    public Image controlGlow;
    public Image nextGlow;

    public static int currentStage;
    public static bool onePlayer;

    public GameObject warning;

    public GameObject mainMenuCanvas;
    public GameObject mainMenuBackground;
    public GameObject controlMenuBackground;
    public GameObject buttonList;
    public GameObject singleButton;
    public GameObject doubleButton;
    public GameObject quitButton;
    public GameObject controlButton;
    public GameObject nextButton;

    private void Awake()
    {
        DeactivateMainMenu();
        DeactivateControlList();
        DeactivateMainMenuGlow();
        DeactivateControlListGlow();
        ResetGlowTracker();

        currentStage = 1;
		waiting = false;
        controlList = false;
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

                    quitGlow.fillAmount = 1;
                }
                if (glowTracker >= 4)
                {
                    glowTracker = 4;

                    DeactivateMainMenuGlow();

                    controlGlow.fillAmount = 1;
                }

                if (Input.GetButtonDown("P1VerticalChoiceUp") || Input.GetButtonDown("P2VerticalChoiceUp") || Input.GetKeyDown(KeyCode.Keypad8))
                {
                    glowTracker--;
                }
                if (Input.GetButtonDown("P1VerticalChoiceDown") || Input.GetButtonDown("P2VerticalChoiceDown") || Input.GetKeyDown(KeyCode.Keypad5))
                {
                    glowTracker++;
                }

                if (Input.GetButtonDown("Fire_P1") || Input.GetButtonDown("Fire_P2") || Input.GetKeyDown(KeyCode.Keypad0))
                {
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
                        QuitButton();
                    }
                    if (glowTracker == 4)
                    {
                        ControlButton();
                    }
                }
            }
            else
            {
                if (glowTracker <= 1)
                {
                    glowTracker = 1;

                    DeactivateControlListGlow();

                    nextGlow.fillAmount = 1;
                }
                if (glowTracker >= 1)
                {
                    glowTracker = 1;

                    DeactivateControlListGlow();

                    nextGlow.fillAmount = 1;
                }

                if (Input.GetButtonDown("P1VerticalChoiceUp") || Input.GetButtonDown("P2VerticalChoiceUp") || Input.GetKeyDown(KeyCode.Keypad8))
                {
                    glowTracker--;
                }
                if (Input.GetButtonDown("P1VerticalChoiceDown") || Input.GetButtonDown("P2VerticalChoiceDown") || Input.GetKeyDown(KeyCode.Keypad5))
                {
                    glowTracker++;
                }

                if (Input.GetButtonDown("Fire_P1") || Input.GetButtonDown("Fire_P2") || Input.GetKeyDown(KeyCode.Keypad0))
                {
                    if (controlGlowTracker == 1)
                    {
                        NextButton();
                    }
                }
            }
		}
    }

    IEnumerator Timer()
    {
        warning.SetActive(true);

        yield return new WaitForSeconds(6.0f);

        warning.SetActive(false);

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

    private void ActivateControlList()
    {
        controlMenuBackground.SetActive(true);
    }
    private void DeactivateControlList()
    {
        controlMenuBackground.SetActive(false);
    }

    private void DeactivateMainMenuGlow()
    {
        singleGlow.fillAmount = 0;
        doubleGlow.fillAmount = 0;
        quitGlow.fillAmount = 0;
        controlGlow.fillAmount = 0;
    }
    private void DeactivateControlListGlow()
    {
        nextGlow.fillAmount = 0;
    }

    private void ResetGlowTracker()
    {
        glowTracker = 1;
        controlGlowTracker = 1;
    }

    private void SingleButton()
    {
        onePlayer = true;
        SceneManager.LoadScene("SelectionMenu");
    }

    private void DoubleButton()
    {
        onePlayer = false;
        SceneManager.LoadScene("SelectionMenu");
    }

    private void QuitButton()
    {
        Application.Quit();
    }

    private void ControlButton()
    {
        DeactivateMainMenuGlow();
        ActivateControlList();
        ResetGlowTracker();

        controlList = true;
    }

    private void NextButton()
    {
        DeactivateMainMenuGlow();
        DeactivateControlList();
        ResetGlowTracker();

        controlList = false;
    }
}
