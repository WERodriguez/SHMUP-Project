using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public static bool onePlayer;

    public GameObject warning;

    public GameObject mainMenuCanvas;
    public GameObject backGround;
    public GameObject buttonList;
    public GameObject singleButton;
    public GameObject doubleButton;
    public GameObject quitButton;
    private void Start()
    {
        DeactivateMainMenu();
        StartCoroutine(Timer());
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
