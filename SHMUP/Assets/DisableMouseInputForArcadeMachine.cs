using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableMouseInputForArcadeMachine : MonoBehaviour
{
    public bool wantMouse;

	// Use this for initialization
	void Awake ()
    {
        if (wantMouse == false)
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
}
