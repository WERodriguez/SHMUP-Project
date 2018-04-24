using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleController : MonoBehaviour
{
	public static bool fromTitle;
	public static bool arcadeQuit;

	public bool arcadeBuild;
	public bool limbitlessBuild;

    public GameObject logo;
    public GameObject warning;
    public GameObject skipButton;

    private bool canSkip;
    private bool skipPressed;

    private void Awake()
    {
        logo.SetActive(false);
        warning.SetActive(false);
        skipButton.SetActive(false);

		arcadeQuit = false;
        fromTitle = true;
        canSkip = false;
        skipPressed = false;
    }

    private void Start()
    {
        StartCoroutine(Timer());
    }

    private void Update()
	{
        if (canSkip)
        {
            if (Input.GetButtonDown("Fire_P1") || Input.GetButtonDown("Fire_P2") || Input.GetKeyDown(KeyCode.Keypad0) || FlexToggle.myFlexBool == true)
            {
                skipPressed = true;

                SceneManager.LoadScene("MainMenu");
            }
		}

		if (arcadeBuild)
		{
			arcadeQuit = true;
		}
		if (arcadeQuit)
		{
			if (Input.GetButtonDown ("ArcadeQuit"))
			{
				Application.Quit ();
			}
		}
    }

    IEnumerator Timer()
    {
        logo.SetActive(true);

        yield return new WaitForSeconds(4f);

        canSkip = true;

        warning.SetActive(true);
        skipButton.SetActive(true);

        if(skipPressed)
        {
            yield break;
        }

        yield return new WaitForSeconds(9f);

        SceneManager.LoadScene("MainMenu");
    }
}
