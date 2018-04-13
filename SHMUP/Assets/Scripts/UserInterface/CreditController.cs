using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditController : MonoBehaviour
{
    public GameObject mainMenuButton;

    private bool waiting;

    private void Start()
    {
        StartCoroutine(Timer());
    }

    private void Update()
    {
        if(!waiting)
        {
            if(Input.GetButtonDown("Fire_P1") || Input.GetButtonDown("Fire_P2") || Input.GetKeyDown(KeyCode.Keypad0))
            {
                MainMenuButton();
            }
        }
    }

    IEnumerator Timer()
    {
        waiting = true;

        mainMenuButton.SetActive(false);

        yield return new WaitForSeconds(7.5f);

        mainMenuButton.SetActive(true);

        waiting = false;
    }

    private void MainMenuButton()
    {
        Destroy(GameObject.Find("MenuMusicController"));
        Destroy(GameObject.Find("HangarMusicController"));

        SceneManager.LoadScene("MainMenu");
    }
}
