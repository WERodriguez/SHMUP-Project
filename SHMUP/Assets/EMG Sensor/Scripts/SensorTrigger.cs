/**************************************************************************************************
 * SENSOR METER                                                                    SensorTrigger.cs
 * LIMBITLESS SOLUTIONS INC.                                                             2018.01.25
 * https://limbitless-solutions.org/                                                         v1.0.0
 * 
 * Author:  Angel Rodriguez Jr.
 * 
 * Copyright (C) 2018 Limbitless Solutions Inc.
 * Copyright (C) 2018 University of Central Florida, School of Visual Arts and Design (SVAD)
 * 
 * This work is licensed under the:
 * Creative Commons Attribution-NonCommercial-NoDerivatives 4.0 International License. 
 * To view a copy of this license, visit http://creativecommons.org/licenses/by-nc-nd/4.0/ 
 * or send a letter to Creative Commons, PO Box 1866, Mountain View, CA 94042, USA.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

// Note: Uses SensorCore.Main instance.

/// <summary>
/// Adds event support to a SensorCore, allowing methods to be linked to sensor status events.
/// </summary>
public class SensorTrigger : MonoBehaviour
{
    #region Static

    /// <summary>
    /// The primary active SensorTrigger instance.
    /// </summary>
    public static SensorTrigger Main = null;

    #endregion

    #region Inspector (Events)

    [Header("Settings")]
    [SerializeField]
    [Tooltip("If true, this SensorCore will destroy as normal between scenes.")]
    private bool destroyAfterScene = false;

    [Tooltip("If true, use the rawreading instead of the smoothed. Recommended for tight" +
        "button to flex emulation.")]
    public bool useRaw = false;

    [Space(10)]
    [Header("Events")]
    [Tooltip("Called when the sensor reading increasing after previously decreasing.")]
    public UnityEvent OnUpturn;

    [Tooltip("Called when the sensor reading decreases after previously increasing.")]
    public UnityEvent OnDownturn;

    [Tooltip("Called when the sensor reading reaches or goes past the flex threshold after " +
        "previously being below it.")]
    public UnityEvent OnFlexEnter;

    [Tooltip("Called when the sensor reading goes below the flex threshold after previously" +
        "being at or above it.")]
    public UnityEvent OnFlexExit;

    [Tooltip("Called when the sensor reading goes at or below the rest threshold after " +
        "previously being above it.")]
    public UnityEvent OnRestEnter;

    [Tooltip("Called when the sensor reading reaches above the rest threshold after previously" +
        "being at or below it.")]
    public UnityEvent OnRestExit;

    #endregion

    #region Run-time

    [HideInInspector]
    public bool isReadingUpwards = false;

    [HideInInspector]
    public bool isFlexing = false;

    [HideInInspector]
    public bool isResting = true;

    private bool ignoreFirstTurn = true;
    private float previousReading = 0;

    #endregion

    // METHODS ------------------------------------------------------------------------------------

    #region Monobehaviours

    protected void Awake()
    {
        if (Main != null)
        {
            Destroy(gameObject);
            return;
        }

        Main = this;
        Debug.Log("<color='purple'>SensorTrigger</color>: Set <i>" + this.name +
            "</i> as Main trigger. Set to <b>" +
            ((destroyAfterScene) ? "destroy" : "persist") +
            "</b> on scene end.");

        if (!destroyAfterScene)
        {
            DontDestroyOnLoad(this);
        }
    }

    protected void Update()
    {
        if (SensorCore.Main == null)
            return;

        float activeReading = (useRaw) ? SensorCore.Main.readingRaw :
                                         SensorCore.Main.readingRawSmoothed;

        // Check for upturn.
        if (activeReading > previousReading && !isReadingUpwards)
        {
            if (ignoreFirstTurn)
            {
                ignoreFirstTurn = false;
            }
            else
            {
                isReadingUpwards = true;
                OnUpturn.Invoke();
            }
        }

        // Check for downturn.
        else if (activeReading < previousReading && isReadingUpwards)
        {
            if (ignoreFirstTurn)
            {
                ignoreFirstTurn = false;
            }
            else
            {
                isReadingUpwards = false;
                OnDownturn.Invoke();
            }
        }

        // Check against flex.
        if (activeReading >= SensorCore.Main.flexThreshold * 1024f && !isFlexing)
        {
            isFlexing = true;
            OnFlexEnter.Invoke();
        }
        else if (activeReading < SensorCore.Main.flexThreshold * 1014f && isFlexing)
        {
            isFlexing = false;
            OnFlexExit.Invoke();
        }

        // Check against rest.
        if (activeReading <= SensorCore.Main.restThreshold * 1024f && !isResting)
        {
            isResting = true;
            OnRestEnter.Invoke();
        }
        else if (activeReading > SensorCore.Main.restThreshold * 1014f && isResting)
        {
            isResting = false;
            OnRestExit.Invoke();
        }

        previousReading = activeReading;
    }

    #endregion
}
