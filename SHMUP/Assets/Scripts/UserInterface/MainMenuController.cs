using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    private int glowTracker;

    public Image singleGlow;
    public Image doubleGlow;
    public Image quitGlow;

    public static bool onePlayer;

    public GameObject warning;

    public GameObject mainMenuCanvas;
    public GameObject backGround;
    public GameObject buttonList;
    public GameObject singleButton;
    public GameObject doubleButton;
    public GameObject quitButton;

    private void Awake()
    {
        DeactivateMainMenu();
        DeactivateGlow();

        glowTracker = 1;
    }

    private void Start()
    {
        StartCoroutine(Timer());
    }

    private void Update()
    {
        if(glowTracker <= 1)
        {
            glowTracker = 1;

            DeactivateGlow();

            singleGlow.fillAmount = 1;
        }
        if (glowTracker == 2)
        {
            DeactivateGlow();

            doubleGlow.fillAmount = 1;
        }
        if (glowTracker >= 3)
        {
            glowTracker = 3;

            DeactivateGlow();

            quitGlow.fillAmount = 1;
        }

        if(Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.Alpha8) || Input.GetKeyDown(KeyCode.Alpha4) || Input.GetKeyDown(KeyCode.Keypad8) || Input.GetKeyDown(KeyCode.Keypad4))
        {
            glowTracker--;
        }
        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.Alpha5) || Input.GetKeyDown(KeyCode.Alpha6) || Input.GetKeyDown(KeyCode.Keypad5) || Input.GetKeyDown(KeyCode.Keypad6))
        {
            glowTracker++;
        }

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Alpha0) || Input.GetKeyDown(KeyCode.Keypad0))
        {
            if (glowTracker <= 1)
            {
                SingleButton();
            }
            if (glowTracker == 2)
            {
                DoubleButton();
            }
            if (glowTracker >= 3)
            {
                QuitButton();
            }
        }
    }

    IEnumerator Timer()
    {
        warning.SetActive(true);

        yield return new WaitForSeconds(6.0f);

        warning.SetActive(false);

        ActivateMainMenu();
    }

    private void ActivateMainMenu()
    {
        mainMenuCanvas.SetActive(true);
        buttonList.SetActive(true);
        singleButton.SetActive(true);
        doubleButton.SetActive(true);
        quitButton.SetActive(true);
    }
    private void DeactivateMainMenu()
    {
        mainMenuCanvas.SetActive(false);
        buttonList.SetActive(false);
        singleButton.SetActive(false);
        doubleButton.SetActive(false);
        quitButton.SetActive(false);
    }

    private void DeactivateGlow()
    {
        singleGlow.fillAmount = 0;
        doubleGlow.fillAmount = 0;
        quitGlow.fillAmount = 0;
    }

    public void SingleButton()
    {
        onePlayer = true;
        SceneManager.LoadScene("SelectionMenu");
    }

    public void DoubleButton()
    {
        onePlayer = false;
        SceneManager.LoadScene("SelectionMenu");
    }

    public void QuitButton()
    {
        Application.Quit();
    }
}
