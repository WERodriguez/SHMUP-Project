/**************************************************************************************************
 * SENSOR METER                                                                      SensorMeter.cs
 * LIMBITLESS SOLUTIONS INC.                                                             2018.01.24
 * https://limbitless-solutions.org/                                                         v1.2.0
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

[RequireComponent(typeof(RectTransform))]

// NOTE: Marker tracking only works correctly if the object is pivoted correctly for scaling.
// For example, a horizontal meter (scaleX) should have it's x pivot point set to 0 (left) or 1 if 
// the meter is reversed.

/// <summary>
/// Manipulates an object's scale to reflect a [0f, 1f] range from a SensorCore reading.
/// </summary>
public class SensorMeter : MonoBehaviour
{
    #region Structures

    public enum MeterMode
    {
        singleFull          = 0,
        singleActive        = 1,
        singleAdjustable    = 2,

        rangeFull           = 3,
        rangeActive         = 4,
        rangeAdjustable     = 5
    };

    #endregion

    #region Inspector Config

    [Header("Object References")]
    [Tooltip("Reference to the object to scale as the meter fill.")]
    public Transform refMeterFill;

    [Tooltip("Reference to the transform of the gameObject desired to track the sensor position.")]
    public Transform refSensorMarker;

    [Tooltip("Reference to the transform of the gameObject desired to track the flex threshold.")]
    public Transform refFlexThresholdMarker;

    [Tooltip("Reference to the transform of the gameObject desired to track the rest threshold.")]
    public Transform refRestThresholdMarker;

    // TODO: Add rest threshold marker.

    [Space(10)]
    [Header("General Settings")]
    [Tooltip("The meter's mode determines how it interprets sensor data.")]
    public MeterMode mode;

    [Tooltip("If true, uses the smoothed reading.")]
    public bool smoothed;

    [Tooltip("if true, will update position information each frame. Only set true for moving " +
        "meter objects. Otherwise, positions will be updated when sensor values are updated.")]
    public bool continuousPositionTracking = false;

    [SerializeField]
    [Tooltip("If true, shows the range and position gizmos in scene view even when not selected.")]
    private bool alwaysShowPositionGizmos = false;

    [Tooltip("If true, flips the min and max ends of the meter.")]
    public bool flipMeter = false;

    [Space(5)]
    [Tooltip("If true, scales the meterFill object's transform in the x-axis.")]
    public bool scaleX = true;

    [Tooltip("If true, scales the meterFill object's transform in the y-axis.")]
    public bool scaleY = false;

    #endregion

    #region Run-Time Reference

    /// <summary>
    /// Reference to the element's RectTransform.
    /// </summary>
    private RectTransform refRect;

    /// <summary>
    /// The sensorMarker's initial localPosition. Set at start to maintain tracking offset.
    /// </summary>
    private Vector3 sensorMarkerOffset;

    /// <summary>
    /// The FlexThresholdMarker's initial localPosition. Set at start to maintain tracking offset.
    /// </summary>
    private Vector3 flexThresholdMarkerOffset;

    /// <summary>
    /// The RestThresholdMarker's initial localPosition. Set at start to maintain tracking offset.
    /// </summary>
    private Vector3 restThresholdMarkerOffset;

    /// <summary>
    /// Saved maximum scale value, saved at Awake.
    /// </summary>
    private Vector3 maxScale;

    #endregion

    #region Run-Time Public

    [HideInInspector]
    /// <summary>
    /// The meter's current [0f, 1f] fill value.
    /// </summary>
    public float value;

    [HideInInspector]
    /// <summary>
    /// The minimum x,y, and z for tracking a marker's position.
    /// </summary>
    public Vector3 markerMinPosition;

    [HideInInspector]
    /// <summary>
    /// The maximum x,y, and z for tracking a marker's position.
    /// </summary>
    public Vector3 markerMaxPosition;

    #endregion

    // METHODS ------------------------------------------------------------------------------------

    #region Monobehaviours

    private void Awake()
    {
        if (refMeterFill == null)
        {
            Debug.Log("<color='green'>SensorMeter</color> (<i>\"" + name + "\"</i>): " +
                "No meterFill reference, destroying...");
            Destroy(gameObject);
            return;
        }

        // Set's max scale to initial so scale range is [0, maxScale] in the x, y, and z.
        maxScale = refMeterFill.localScale;

        refRect = GetComponent<RectTransform>();

        UpdatePositions();

        if (refSensorMarker != null)
        {
            sensorMarkerOffset = markerMinPosition - refSensorMarker.position;
        }
        if (refFlexThresholdMarker != null)
        {
            flexThresholdMarkerOffset = markerMinPosition - refFlexThresholdMarker.position;
        }
        if (refRestThresholdMarker != null)
        {
            restThresholdMarkerOffset = markerMinPosition - refRestThresholdMarker.position;
        }
    }

    private void LateUpdate()
    {
        // Get data.
        value = GetValue();

        Vector3 newScale = refMeterFill.localScale;
        if (scaleX)
            newScale.x = maxScale.x * value;
        if (scaleY)
            newScale.y = maxScale.y * value;

        refMeterFill.localScale = newScale;

        // Update positions and markers.
        if (continuousPositionTracking)
        {
            UpdatePositions();
        }

        UpdateMarkers();
    }

    private void OnDrawGizmos()
    {
        if (alwaysShowPositionGizmos)
            OnDrawGizmosSelected();
    }

    private void OnDrawGizmosSelected()
    {
        if (!Application.isPlaying)
        {
            if (refRect == null)
            {
                try
                {
                    refRect = GetComponent<RectTransform>();
                }
                catch { }
            }

            UpdatePositions();
            UpdateMarkers();
        }

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(markerMinPosition, 100f * transform.parent.localScale.x * transform.localScale.x);

        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(markerMaxPosition, 100f * transform.parent.localScale.x * transform.localScale.x);

        if (refSensorMarker != null)
        {
            Gizmos.color = Color.white;
            if (!Application.isPlaying)
            {
                Gizmos.DrawWireSphere
                (
                    refSensorMarker.position - sensorMarkerOffset,
                    100f * transform.parent.localScale.x * transform.localScale.x * 0.75f
                );
            }
            else
            {
                Gizmos.DrawWireSphere
                (
                    refSensorMarker.position + sensorMarkerOffset,
                    100f * transform.parent.localScale.x * transform.localScale.x * 0.75f
                );
            }
        }
    }

    #endregion

    #region Public Process

    /// <summary>
    /// Determine's the meter's fill value [0f, 1f] based on mode and SensorCore reading.
    /// </summary>
    /// <returns>The determined [0f, 1f] fill value.</returns>
    public float GetValue()
    {
        if (SensorCore.Main == null)
            return 0f;

        float result = 0f;

        switch (mode)
        {
            case MeterMode.singleFull:
            case MeterMode.rangeFull:
                result = SensorCore.Main.GetFlexFull(smoothed);
                break;

            case MeterMode.singleAdjustable:
			case MeterMode.rangeAdjustable:
                result = SensorCore.Main.GetFlexAdjusted(smoothed);
				break;

            case MeterMode.singleActive:
                result = SensorCore.Main.GetFlexActive(true, smoothed);
                break;

            case MeterMode.rangeActive:
				result = SensorCore.Main.GetFlexActive(false, smoothed);
				break;

            default:
                result = 0f;
                break;
        }

        return result;
    }

    /// <summary>
    /// Updates the positions of markers relative to the position of the meter and marker values.
    /// </summary>
    public void UpdatePositions()
    {
        if (refRect != null)
        {
            // Uses scale of both meter parent (this instance) and canvas scale.
            markerMinPosition = new Vector3
            (
                (scaleX) ? (refRect.position.x - (refRect.rect.width / 2 * transform.parent.localScale.x * transform.localScale.x)) :
                           refRect.position.x,

                (scaleY) ? (refRect.position.y - (refRect.rect.height / 2 * transform.parent.localScale.y * transform.localScale.y)) :
                           refRect.position.y,

                refRect.position.z
            );

            markerMaxPosition = new Vector3
            (
                markerMinPosition.x + ((scaleX) ? refRect.sizeDelta.x * transform.parent.localScale.x * transform.localScale.x : 0),

                markerMinPosition.y + ((scaleY) ? refRect.sizeDelta.y * transform.parent.localScale.y * transform.localScale.y : 0),

                refRect.position.z
            );
        }
    }

    /// <summary>
    /// Updates the marker position trackers, if references to them exist.
    /// </summary>
    public void UpdateMarkers()
    {
        if (Application.isPlaying)
        {
            if (refSensorMarker != null)
            {
                if (flipMeter)
                    refSensorMarker.position = Vector3.Lerp(markerMaxPosition, markerMinPosition, value) - sensorMarkerOffset;
                else
                    refSensorMarker.position = Vector3.Lerp(markerMinPosition, markerMaxPosition, value) - sensorMarkerOffset;
            }

            // Flex threshold.
            if (refFlexThresholdMarker != null)
            {
                switch (mode)
                {
                    case MeterMode.rangeFull:
                    case MeterMode.singleFull:
                        refFlexThresholdMarker.position = Vector3.Lerp
                        (
                            (flipMeter) ? markerMaxPosition : markerMinPosition,
                            (flipMeter) ? markerMinPosition : markerMaxPosition,
                            SensorCore.Main.flexThreshold
                        ) - flexThresholdMarkerOffset;
                        break;

                    case MeterMode.rangeAdjustable:
                    case MeterMode.singleAdjustable:
                        if (SensorCore.Main.sensorAdjustedCap > 0)
                        {
                            refFlexThresholdMarker.position = Vector3.Lerp
                            (
                                (flipMeter) ? markerMaxPosition : markerMinPosition,
                                (flipMeter) ? markerMinPosition : markerMaxPosition,
                                Mathf.Clamp((SensorCore.Main.flexThreshold * 1024f) / SensorCore.Main.sensorAdjustedCap, 0f, 1f)
                            ) - flexThresholdMarkerOffset;
                        }
                        else
                        {
                            refFlexThresholdMarker.position = Vector3.Lerp
                            (
                                (flipMeter) ? markerMaxPosition : markerMinPosition,
                                (flipMeter) ? markerMinPosition : markerMaxPosition,
                                0f
                            ) - flexThresholdMarkerOffset;
                        }
                        break;

                    case MeterMode.rangeActive:
                    case MeterMode.singleActive:
                        refFlexThresholdMarker.position = Vector3.Lerp
                        (
                            (flipMeter) ? markerMaxPosition : markerMinPosition,
                            (flipMeter) ? markerMinPosition : markerMaxPosition,
                            1f
                        ) - flexThresholdMarkerOffset;
                        break;

                    default:
                        refFlexThresholdMarker.position = Vector3.Lerp
                        (
                            (flipMeter) ? markerMaxPosition : markerMinPosition,
                            (flipMeter) ? markerMinPosition : markerMaxPosition,
                            0f
                        ) - flexThresholdMarkerOffset;
                        break;
                }
            }
             
            // Rest Threshold
            if (refRestThresholdMarker != null)
            {
                switch (mode)
                {
                    case MeterMode.rangeFull:
                        refRestThresholdMarker.position = Vector3.Lerp
                        (
                            (flipMeter) ? markerMaxPosition : markerMinPosition,
                            (flipMeter) ? markerMinPosition : markerMaxPosition,
                            SensorCore.Main.restThreshold
                        ) - restThresholdMarkerOffset;
                        break;

                    case MeterMode.rangeAdjustable:
                        if (SensorCore.Main.sensorAdjustedCap > 0)
                        {
                            refRestThresholdMarker.position = Vector3.Lerp
                            (
                                (flipMeter) ? markerMaxPosition : markerMinPosition,
                                (flipMeter) ? markerMinPosition : markerMaxPosition,
                                Mathf.Clamp((SensorCore.Main.restThreshold * 1024f) / SensorCore.Main.sensorAdjustedCap, 0f, 1f)
                            ) - restThresholdMarkerOffset;
                        }
                        else
                        {
                            refRestThresholdMarker.position = Vector3.Lerp
                            (
                                (flipMeter) ? markerMaxPosition : markerMinPosition,
                                (flipMeter) ? markerMinPosition : markerMaxPosition,
                                0f
                            ) - restThresholdMarkerOffset;
                        }
                        break;

                    case MeterMode.rangeActive:
                        refRestThresholdMarker.position = Vector3.Lerp
                        (
                            (flipMeter) ? markerMaxPosition : markerMinPosition,
                            (flipMeter) ? markerMinPosition : markerMaxPosition,
                            0f
                        ) - restThresholdMarkerOffset;
                        break;

                    case MeterMode.singleFull:
                    case MeterMode.singleAdjustable:
                    case MeterMode.singleActive:
                    default:
                        refFlexThresholdMarker.position = Vector3.Lerp
                        (
                            (flipMeter) ? markerMaxPosition : markerMinPosition,
                            (flipMeter) ? markerMinPosition : markerMaxPosition,
                            0f
                        ) - flexThresholdMarkerOffset;
                        break;
                }
            }
        }
        else
        {
            if (refSensorMarker != null)
            {
                sensorMarkerOffset = refSensorMarker.position - markerMinPosition;
            }
        }
    }

    #endregion
}
