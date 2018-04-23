/**************************************************************************************************
 * SENSOR METER                                                                   SensorMeterTab.cs
 * LIMBITLESS SOLUTIONS INC.                                                             2018.01.17
 * https://limbitless-solutions.org/                                                         v1.1.1
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
using UnityEngine.UI;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Button))]

// NOTE: Currently only supports a canvas element, strictly x,y grid, with no support for rotation.

/// <summary>
/// A UI canvas meter element that can interpret and interact with the SensorCore in various ways.
/// </summary>
public class SensorMeterTab : MonoBehaviour, IDragHandler, IEndDragHandler
{
    #region Structures

    public enum Mode : int { None, Flex, Rest};

    #endregion

    #region Inspector Controls

    [Header("Settings")]
    [Tooltip("The sensor variable that the meter represents.")]
    public Mode variableMode = Mode.None;

    [Tooltip("If true, scales the slideSpeed by the sensorCap adjustment. " +
        "Use for adjust mode meters.")]
    public bool scaleToAdjustMeter;

    [Space(10)]
    [Tooltip("If true, holding and dragging with the mouse slides the tab.")]
    public bool enableMouseDrag = true;

    [Tooltip("If true, uses x axis. Otherwise, uses y axis.")]
    public bool isHorizontal = true;

    [Tooltip("The speed in Unity units, at which the tab slides along the length of the range " +
        "when moved by directional input.")]
    public float slideSpeed;

    [Tooltip("The speed in Unity units, at which the tab slides along the length of the range " +
        "when moved by mouse input. Scaled by the canvas scale and object scale.")]
    public float slideSpeedMouse;

    [Tooltip("If true, will scale te slideSpeedMouse variable by the screen size relative to" +
        "the reference width below.")]
    public bool slideSpeedMouseScale;

    [Tooltip("If scaling the mouse slide speed based on a screen width, use this value as the" +
        "reference screen width to scale against.")]
    public float refScreenWidth;

    #endregion

    #region Run-Time

    /// <summary>
    /// Reference to the button component. Set on awake.
    /// </summary>
    protected Button refButton;

    [HideInInspector]
    /// <summary>
    /// If true, button is the currently selected gameObject.
    /// </summary>
    public bool isSelected = false;

    [HideInInspector]
    /// <summary>
    /// If true, a drag action is occuring.
    /// </summary>
    public bool isDragging = false;

    #endregion

    // METHODS ------------------------------------------------------------------------------------

    #region Monobehaviours

    protected void Awake()
    {
        refButton = GetComponent<Button>(); 
    }

    protected void Update()
    {
        if (EventSystem.current.currentSelectedGameObject == refButton.gameObject)
            isSelected = true;
        else
            isSelected = false;

        // Move with directional.
        if (isSelected)
        {
            float direction = Input.GetAxisRaw((isHorizontal) ? "Horizontal" : "Vertical");

            if (variableMode != Mode.None)
            {
                float activeSlideSpeed = slideSpeed;

                if (scaleToAdjustMeter)
                {
                    if (SensorCore.Main.sensorAdjustedCap > 0)
                        activeSlideSpeed /= 1024f / SensorCore.Main.sensorAdjustedCap;
                    else
                        activeSlideSpeed = 0f;
                }

                if (variableMode == Mode.Flex)
                {
                    SensorCore.Main.flexThreshold = Mathf.Clamp
                    (
                        SensorCore.Main.flexThreshold + (activeSlideSpeed * direction * Time.deltaTime),
                        0f,
                        1f
                    );
                }
                else if (variableMode == Mode.Rest)
                {
                    SensorCore.Main.restThreshold = Mathf.Clamp
                    (
                        SensorCore.Main.restThreshold + (activeSlideSpeed * direction * Time.deltaTime),
                        0f,
                        1f
                    );
                }
            }
        }
    }

    #endregion

    #region Overrides

    public void OnDrag(PointerEventData data)
    {
        if (!enableMouseDrag)
            return;

        isDragging = true;

        float direction = Input.GetAxisRaw((isHorizontal) ? "Mouse X" : "Mouse Y");

        if (variableMode != Mode.None)
        {
            float activeSlideSpeed = slideSpeedMouse;

            if (scaleToAdjustMeter)
            {
                if (SensorCore.Main.sensorAdjustedCap > 0)
                    activeSlideSpeed /= 1024f / SensorCore.Main.sensorAdjustedCap;
                else
                    activeSlideSpeed = 0f;
            }

            if (slideSpeedMouseScale)
            {
                activeSlideSpeed *= (refScreenWidth / Screen.width);
            }

            if (variableMode == Mode.Flex)
            {
                SensorCore.Main.flexThreshold = Mathf.Clamp
                (
                    SensorCore.Main.flexThreshold + (activeSlideSpeed * direction * Time.deltaTime),
                    0f,
                    1f
                );
            }
            else if (variableMode == Mode.Rest)
            {
                SensorCore.Main.restThreshold = Mathf.Clamp
                (
                    SensorCore.Main.restThreshold + (activeSlideSpeed * direction * Time.deltaTime),
                    0f,
                    1f
                );
            }
        }
    }

    public void OnEndDrag(PointerEventData data)
    {
        isDragging = false;
    }

    #endregion
}
