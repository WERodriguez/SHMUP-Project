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

    public static int currentStage;
    public static bool onePlayer;

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

    public Image singleGlow;
    public Image doubleGlow;
    public Image quitGlow;
    public Image controlGlow;
    public Image creditGlow;
    public Image rightGlow;
    public Image leftGlow;

    public Text intro;

    private void Awake()
    {
        DeactivateMainMenu();
        DeactivateControlBackground();
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

                    intro.text = "Menu Interaction\n- Keyboard -";

                    DeactivateControlList();
                    controlMenu.SetActive(true);
                }
                if (glowTracker >= 2)
                {
                    glowTracker = 2;

                    intro.text = "In-Game Interaction\n- Keyboard -";

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

                if (Input.GetButtonDown("Fire_P1") || Input.GetButtonDown("Fire_P2") || Input.GetKeyDown(KeyCode.Keypad0))
                {
                    DeactivateMainMenuGlow();
                    DeactivateControlBackground();
                    DeactivateControlList();
                    ResetGlowTracker();

                    controlList = false;
                }
            }
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

    private void ActivateControlList()
    {
        controlMenu.SetActive(true);
        controlInGame.SetActive(true);
    }
    private void DeactivateControlList()
    {
        controlMenu.SetActive(false);
        controlInGame.SetActive(false);
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
        ActivateControlBackground();
        ResetGlowTracker();

        controlList = true;
    }

    private void CreditButton()
    {
        SceneManager.LoadScene("Credit");
    }
}
