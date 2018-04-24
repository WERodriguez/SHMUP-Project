using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlexToggle : MonoBehaviour
{
    //Tracks flex
    static public bool myFlexBool;
    //Tracks if double tapping.
    static public bool doubleTapActive;

    public float doubleTapTimer;
    public float timeLimit;
    public float coroutineTimeLimit;
    public int tapCounter;

    private void Start()
    {
        doubleTapActive = false;
    }

    private void Update()
    {

        if (tapCounter == 1 && doubleTapTimer < timeLimit)
        {
            doubleTapTimer += Time.deltaTime;
        }

        if (tapCounter == 1 && doubleTapTimer > timeLimit)
        {
            tapCounter = 0;
            doubleTapTimer = 0;
        }

        if (tapCounter >= 2 && doubleTapTimer < timeLimit)
        {
            doubleTapActive = true;
            tapCounter = 0;
            doubleTapTimer = 0;

            StartCoroutine(StopDoubleTap());
        }
    }

    //Registers flex as true.
    public void SetFlexTrue()
    {
        myFlexBool = true;
    }

    //Registers flex as false.
    public void SetFlexFalse()
    {
        myFlexBool = false;
    }

    public void DoubleFlex()
    {
        tapCounter++;
    }

    IEnumerator StopDoubleTap()
    {
        yield return new WaitForSeconds(coroutineTimeLimit);
        doubleTapActive = false;
    }
}
