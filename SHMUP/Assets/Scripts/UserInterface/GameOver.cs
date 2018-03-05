using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public GameObject hangarButton;
    public GameObject restartButton;

    public GameObject onePlayerScreen;
    public GameObject twoPlayersScreen;

    public Animator canvasAnimation;

    private float lastingTime;
    private int duration;

    private void Start()
    {
        hangarButton.SetActive(true);
        restartButton.SetActive(true);

        if (UIController.onePlayer)
        {
            onePlayerScreen.SetActive(true);
            twoPlayersScreen.SetActive(false);
        }
        else
        {
            onePlayerScreen.SetActive(false);
            twoPlayersScreen.SetActive(true);
        }

        duration = 9;
        lastingTime = duration;

        Invoke("NextAnimation", 1f);
    }

    private void Update()
    {
        lastingTime = lastingTime - 1 * Time.deltaTime;

        if(lastingTime <= 0)
        {
            canvasAnimation.SetBool("EnableCanvasAnimation", true);
        }
    }
    /*
    private void NextAnimation()
    {
        lastingTime--;

        if(lastingTime > 0)
        {
            Invoke("NextAnimation", 1f);
        }
        else
        {
            canvasAnimation.SetBool("EnableCanvasAnimation", true);
        }
    }*/

    private void ResetValue()
    {
        /*
        PlayerHealthSystem.currentLives = PlayerHealthSystem.maxLives;
        PlayerHealthSystem.currentHealth = PlayerHealthSystem.maxHealth;
        PlayerHealthSystem.currentShields = PlayerHealthSystem.maxShields;
        */
    }

    public void HangarButton()
    {
        canvasAnimation.SetBool("EnableCanvasAnimation", true);
        SceneManager.LoadScene("Hangar");
    }

    public void RestartButton()
    {
        canvasAnimation.SetBool("EnableCanvasAnimation", true);
        ResetValue();
        SceneManager.LoadScene("(Testing)TheRange");
    }
}
