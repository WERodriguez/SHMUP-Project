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

    private void ResetPlayer1Value()
    {
        PlayerHealthSystem.P1currentLives = PlayerHealthSystem.maxLives;
        PlayerHealthSystem.P1currentHealth = PlayerHealthSystem.maxHealth;
        PlayerHealthSystem.P1currentShields = PlayerHealthSystem.maxShields;
    }
    private void ResetPlayer2Value()
    {
        PlayerHealthSystem.P2currentLives = PlayerHealthSystem.maxLives;
        PlayerHealthSystem.P2currentHealth = PlayerHealthSystem.maxHealth;
        PlayerHealthSystem.P2currentShields = PlayerHealthSystem.maxShields;
    }

    public void HangarButton()
    {
        canvasAnimation.SetBool("EnableCanvasAnimation", true);
        SceneManager.LoadScene("Hangar");
    }

    public void RestartButton()
    {
        if(UIController.onePlayer)
        {
            ResetPlayer1Value();
        }
        else
        {
            ResetPlayer1Value();
            ResetPlayer2Value();
        }

        canvasAnimation.SetBool("EnableCanvasAnimation", true);
        SceneManager.LoadScene("(Testing)TheRange");
    }
}
