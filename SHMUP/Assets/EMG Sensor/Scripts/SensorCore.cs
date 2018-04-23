/**************************************************************************************************
 * EMG SENSOR CORE                                                                    SensorCore.cs
 * LIMBITLESS SOLUTIONS INC.                                                             2018.01.30
 * https://limbitless-solutions.org/                                                         v2.2.0
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
 *
 * Thanks to the Arduino/firmata library for Visual C# .NET, 
 * from which portions of this code were based on and modified. 
 * Copyright (C) Tim Farley (2009) and Daniel MacDonald (2013). 
 * Licensed under the GNU Lesser General Public License.
 * https://www.gnu.org/licenses/old-licenses/lgpl-2.1.en.html
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
using System.IO.Ports;

// NOTE: Requires project API Compatibility Level to NET 2.0 (in Edit-> Project Settings-> Player)

/// <summary>
/// Core script for getting serial input from an EMG Sensor via USB for a PC build.
/// </summary>
public class SensorCore : MonoBehaviour
{
    #region Arduino Structures

    public enum PinMode
    {
        INPUT   = 0,
        OUTPUT  = 1,
        ANALOG  = 2,
        PWM     = 3,
        SERVO   = 4,
        SHIFT   = 5,
        I2C     = 6,
    };

    /// <summary>
    /// Pin description and capabilities.
    /// </summary>
    public class Pin
    {
        public int number;
        public int analog_number = -1;
        public int port { get { return number / 8; } }

        /// <summary>
        /// Firmata pin capability data.
        /// </summary> 
        public class Capability
        {
            public int mode;
            public PinMode Mode { get { return (PinMode)mode; } }
            public int resolution;
        }

        public List<Capability> capabilities = new List<Capability>();
    }

    // HEX COMMAND CONSTANTS:
    private const int DIGITAL_MESSAGE       = 0x90;
    private const int ANALOG_MESSAGE        = 0xE0;
    private const int REPORT_ANALOG         = 0xC0;
    private const int REPORT_DIGITAL        = 0xD0;
    private const int SET_PIN_MODE          = 0xF4;
    private const int REPORT_VERSION        = 0xF9;
    private const int SYSTEM_RESET          = 0xFF;
    private const int START_SYSEX           = 0xF0;
    private const int END_SYSEX             = 0xF7;
    private const int CAPABILITY_QUERY      = 0x6B;
    private const int CAPABILITY_RESPONSE   = 0x6C;

    #endregion

    #region Static Fields

    /// <summary>
    /// The primary active SensorCore instance.
    /// </summary>
    public static SensorCore Main = null;

    #endregion

    #region Inspector Config

    [Header("General Settings")]
    [SerializeField]
    [Tooltip("If true, this SensorCore will destroy as normal between scenes.")]
    private bool destroyAfterScene = false;

    [Tooltip("The magnitude of smoothing on the adjusted meter reading. Larger smoothing catches up" +
    "to the raw reading more quickly.")]
    [Range(0f, 1f)]
    public float smoothingMagnitude;

    [Tooltip("When smoothing, adjusts the effect of distance on the smoothing to curve the approach. " +
        "A higher curve value slows down on proximity to the raw reading, while a low curve linearly " +
        "approaches the raw with little curving. Use a higher curve for smaller sensor movements.")]
    [Range(0f, 1f)]
    public float smoothingCurve;

    [Space(10)]
    [Header("Attributes")]
    [Tooltip("The maximum value that the sensor reading will display in adjustted meter mode.")]
    [Range(0f, 1024f)]
    public int sensorAdjustedCap;

    [Range(0f, 1f)]
    [Tooltip("The [0f, 1f] position of the Flex Threshold of the meter. A reading above "
    + "the threshold is considered a maximum flex in single or range modes.")]
    public float flexThreshold;

    [Range(0f, 1f)]
    [Tooltip("The [0f, 1f] position of the Rest Threshold of the meter. A reading below "
    + "the threshold is considered a rest in range modes.")]
    public float restThreshold;

    [Space(10)]
    [Header("COM Port Connection")]

    [SerializeField]
    [Tooltip("Name of the port to connect to (i.e. \"COM5\").")]
    private string portName = "";

    [SerializeField]
    [Tooltip("Baud rate for the port connection (Default 57600).")]
    private int baudRate = 57600;

    [SerializeField]
    [Tooltip("Amount of time to wait after opening connection for arudio to reboot before " +
        "sending commands (Default 3).")]
    private int rebootDelay = 3;

    [SerializeField]
    [Tooltip("If true, will connect to the first available COM port upon awake.")]
    private bool autoConnectOnAwake = true;

    [Tooltip("If true, will check each frame for a change in devices if not all players " +
        "are connected. Upon discovery will automatically connect to device.")]
    public bool autoReconnect = true;

    [Space(10)]
    [Header("Emulation Input")]
    [Tooltip("If true, holding a flex key causes the sensor to register a flex.")]
    public bool useFlexInput;

    /* TO ADD: Requires smoothing.
    [Tooltip("When pressed, what percentage of the flex threshold does the flex reach.")]
    public float inputTargetOverFlex;
    */

    [Tooltip("Array of keys which cause the meter to flex. Smoothing recommended in range mode.")]
    public string[] flexKeys;

    #endregion

    #region Public Run-Time

    [HideInInspector]
    public bool isConnected = false;                    // Whether the SensorCore is connected. 

    [HideInInspector]
    public bool isFlexEmulating = false;                // If true, flex reading is being emulated.

    [HideInInspector]
    public float readingRaw;                            // The raw (float 0-1024) pin value.

    [HideInInspector]
    public float readingRawSmoothed;                    // The raw (float 0-1024) pin value with smoothing applied.

    [HideInInspector]
    public float readingAdjusted;                       // The adjusted float (0-1) reading using the unsmoothed raw.

    [HideInInspector]
    public float readingAdjustedSmoothed;               // The adjusted float (0-1) reading using the smoothed raw. 

    #endregion

    #region Arudino Input Processing

    private List<System.Action> setupQueue = new List<System.Action>();
    private object setupLock = new object();

    private SerialPort serialPort;                      // The active serialPort.
    private List<Pin> pins;                             // List of pins. Populated getting input.

    private int[] digitalOutputData = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
    private int[] digitalInputData = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
    private int[] analogInputData = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

    private bool canPollBytesToRead = true;             // Windows platform flag for threading.
    private int[] storedInputData = new int[4096];      // For recieving SysEx messages.
    private bool isParsingSysex;                        // When processing input.
    private int sysexBytesRead;                         // Stores red SysEx bytes.
    private int waitForData = 0;                        // Input processing count-down.
    private int executeMultiByteCommand = 0;            // Stored command to execute.
    private int multiByteChannel = 0;                   // Stored channel.

    private string[] refConnections;

    #endregion

    // METHODS ------------------------------------------------------------------------------------

    #region Monobehaviour

    private void Awake()
    {
        if (Main != null)
        {
            Destroy(gameObject);
            return;
        }

        Main = this;
        Debug.Log("<color='blue'>SensorCore</color>: Set <i>" + this.name +
            "</i> as Main sensor. Set to <b>" +
            ((destroyAfterScene) ? "destroy" : "persist") +
            "</b> on scene end.");

        if (!destroyAfterScene)
        {
            DontDestroyOnLoad(this);
        }

        if (autoConnectOnAwake)
        {
            Debug.Log("<color='blue'>SensorCore</color>: Attempting autoConnect...");
            if (portName == null || portName.Length == 0)
            {
                portName = GuessPortName();
            }

            try
            {
                Connect();
            }
            catch (System.Exception e)
            {
                Debug.Log("<color='blue'>SensorCore</color>: <color='red'>FAIL</color> " +
                "Unable to open serial port " + portName + ".\n" + e);
            }
        }
    }

    private void Update()
    {
        // Check connections.
        if (!isConnected &&
            autoReconnect)
        {
            if (SerialPort.GetPortNames().Length > 0 &&
                refConnections != SerialPort.GetPortNames())
            {
                foreach (string port in SerialPort.GetPortNames())
                {
                    portName = port;
                    try
                    {
                        Connect();
                        break;
                    }
                    catch (System.Exception e)
                    {
                        Debug.Log("<color='blue'>SensorCore</color>: Device " + port + 
                            " failed.\n" + e);
                    }
                }
            }

            refConnections = SerialPort.GetPortNames();
        }

        // Clamp thresholds.
        if (flexThreshold * 1024f > sensorAdjustedCap)
        {
            flexThreshold = sensorAdjustedCap / 1024f;
        }
        if (restThreshold > flexThreshold)
        {
            restThreshold = flexThreshold;
        }

        // Emulate flex.
        if (useFlexInput)
        {
            isFlexEmulating = false;

            foreach (string flexKey in flexKeys)
            {
                if (Input.GetKey(flexKey))
                {
                    EmulateFlexFrame();
                    break;
                }
            }
        }

        // Get sensor reading if not emulating.
        if (!isFlexEmulating)
        {
            if (serialPort != null && serialPort.IsOpen)
            {
                ProcessSensorInput();
                readingRaw = analogInputData[0];
            }
            else
            {
                readingRaw = 0;
            }
        }

        // Smooth.
        if (smoothingMagnitude > 0)
        {
            readingRawSmoothed = Mathf.MoveTowards
            (
                readingRawSmoothed,
                readingRaw,
                ((1024f * (1 - smoothingCurve)) + 
                    (Mathf.Abs(readingRaw - readingRawSmoothed) * 
                    (1 / smoothingMagnitude))) *
                    Time.unscaledDeltaTime
            );
        }
        else
        {
            readingRawSmoothed = readingRaw;
        }

        if (sensorAdjustedCap > 0)
        {
            readingAdjusted = Mathf.Clamp(readingRaw / sensorAdjustedCap, 0f, 1f);
            readingAdjustedSmoothed = Mathf.Clamp(readingRawSmoothed / sensorAdjustedCap, 0f, 1f);
        }
        else
        {
            readingAdjusted = 0f;
            readingAdjustedSmoothed = 0f;
        }
    }

    private void OnDestroy()
    {
        Disconnect();
    }

    #endregion

    #region Public Process

    /// <summary>
    /// Compares the sensor's reading to te flex threshold and returns true if at or above it.
    /// </summary>
    /// <param name="isSmoothed">If true, use the smoothed reading (default: true).</param>
    /// <returns>True if at or above flex threshold.</returns>
    public bool isFlexing(bool isSmoothed = true)
    {
        float usedReading = (isSmoothed) ? readingRawSmoothed : readingRaw;

        if (usedReading >= flexThreshold)
            return true;

        // Else:
        return false;
    }

    /// <summary>
    /// Compares the sensor's reading to te rest threshold and returns true if at or below it.
    /// </summary>
    /// <param name="isSmoothed">If true, use the smoothed reading (default: true).</param>
    /// <returns>True if at or below rest threshold.</returns>
    public bool isResting(bool isSmoothed = true)
    {
        float usedReading = (isSmoothed) ? readingRawSmoothed : readingRaw;

        if (usedReading <= restThreshold)
            return true;

        // Else:
        return false;
    }

    /// <summary>
    /// Gets the [0f, 1f] ratio of the sensor reading, compared against a cap of 1024f. 
    /// </summary>
    /// <param name="isSmoothed">If true, use the smoothed reading (default: true).</param>
    /// <returns>The [0f, 1f] ratio of the sensor reading.</returns>
    public float GetFlexFull(bool isSmoothed = true)
    {
        float usedReading = (isSmoothed) ? readingRawSmoothed : readingRaw;

        return usedReading / 1024f;
    }

    /// <summary>
    /// Gets the [0f, 1f] ratio of the sensor reading, compared against the sensorAdjustedCap. 
    /// </summary>
    /// <param name="isSmoothed">If true, use the smoothed reading (default: true).</param>
    /// <returns>The [0f, 1f] ratio of the sensor reading.</returns>
    public float GetFlexAdjusted(bool isSmoothed = true)
    {
        float usedReading = (isSmoothed) ? readingRawSmoothed : readingRaw;

        return Mathf.Clamp(usedReading / sensorAdjustedCap, 0f, 1f);
    }

    /// <summary>
    /// Gets the [0f, 1f] ratio of the sensor reading, compared against a cap of the flex
    /// threshold and a floor of either 0 (isSingle is true) or the restThreshold.
    /// </summary>
    /// <param name="isSingle">If true, creates the ratio with a floor of 0, otherwise will use
    /// the restThreshold.</param>
    /// <param name="isSmoothed">If true, use the smoothed reading (default: true).</param>
    /// <returns>The [0f, 1f] ratio of the sensor reading.</returns>
    public float GetFlexActive(bool isSingle, bool isSmoothed = true)
    {
        float usedReading = (isSmoothed) ? readingRawSmoothed : readingRaw;
    
        if (!isSingle)
			usedReading -= restThreshold * 1024f;

        return Mathf.Clamp(usedReading / (flexThreshold * 1024f), 0f, 1f);
    }

    /// <summary>
    /// Emulates a flex this frame only; overrides sensor input.
    /// </summary>
    public void EmulateFlexFrame()
    {
        isFlexEmulating = true;     // Reset next frame.

        readingRaw = 1024f;         // TODO: Set to threshold ratio.
    }

    #endregion

    #region Arudino Firmata

    /// <summary>
    /// Instruct Uniduino to execute an action only after arduino is connected and not before. 
    /// Use for one-time setup of the board such as setting pinModes and reporting states.
    /// </summary>
    /// <param name='action'> action.</param>
    public void Setup(System.Action action)
    {
        lock (setupLock)
        {
            if (!isConnected)
                setupQueue.Add(action);
            else
                action();
        }
    }

    /// <summary>
    /// Sets up and connects to a serial port determined by portName field.
    /// </summary>
    public void Connect()
    {
        pins = new List<Pin>();

        analogInputData   = new int[16];
        digitalInputData  = new int[16];
        digitalOutputData = new int[16];

        for (int i=0; i<16; i++)
        {
            analogInputData[i]   = 0;
            digitalInputData[i]  = 0;
            digitalOutputData[i] = 0;
        }

        serialPort = new SerialPort(portName, baudRate);

        serialPort.DtrEnable = true; 
        serialPort.RtsEnable = true;
        serialPort.PortName = portName;
        serialPort.BaudRate = baudRate;

        serialPort.DataBits = 8;
        serialPort.Parity = Parity.None;
        serialPort.StopBits = StopBits.One;
        serialPort.ReadTimeout = 1; 
        serialPort.WriteTimeout = 1000;

        if (UnityEngine.Application.platform.ToString().StartsWith("Windows"))
            canPollBytesToRead = false;

        try
        {
            serialPort.Open();

            if (serialPort.IsOpen)
            {
                Thread.Sleep(rebootDelay);
            }

            isConnected = true;
            refConnections = SerialPort.GetPortNames();
            Debug.Log("<color='blue'>SensorCore</color>: <color='green'>SUCCESS</color> Connected to serial port " +
                    portName + ".");

            Setup(ConfigurePins);
        }
        catch (System.Exception e) { throw e; }
    }

    /// <summary>
    /// Disconnects from a serial port.
    /// </summary>
    public void Disconnect()
    {
        if (serialPort != null && serialPort.IsOpen)
        {
            serialPort.Close();

            Debug.Log("<color='blue'>SensorCore</color>: Disconnected from serial port " +
                portName + ".");
        }
        else
        {
            Debug.Log("<color='blue'>SensorCore</color>: Disconnected from null port.");
        }

        isConnected = false;
    }

    /// <summary>
    /// Guesses a port name based on platform.
    /// </summary>
    /// <returns>The gussed name of the port</returns>
    public static string GuessPortName()
    {
        string[] devices = SerialPort.GetPortNames();

        switch (Application.platform)
        {
            case RuntimePlatform.OSXPlayer:
            case RuntimePlatform.OSXEditor:
            case RuntimePlatform.LinuxPlayer:
                if (devices.Length == 0) 
                {
                    devices = System.IO.Directory.GetFiles("/dev/");
                }

                string dev = "";

                foreach (var d in devices)
                {
                    if (d.StartsWith("/dev/tty.usb") || d.StartsWith("/dev/ttyUSB"))
                    {
                        dev = d;
                        break;
                    }
                }
                return dev;

            default:
                if (devices.Length == 0) 
                {
                    return "COM5"; 	
                }
                else
                    return devices[0];
        }
    }

    /// <summary>
    /// Setup procedure to set pin mode for analog.
    /// </summary>
    private void ConfigurePins()
    {
        SetPinMode(0, PinMode.ANALOG);
        ReportAnalog(0, 1);
    }

    /// <summary>
    /// Sets the mode of the specified pin (INPUT or OUTPUT).
    /// </summary>
    /// <param name="pin">The arduino pin.</param>
    /// <param name="mode">Mode Arduino.INPUT or Arduino.OUTPUT.</param>
    public void SetPinMode(int pin, PinMode mode)
    {
        SetPinMode(pin, (int)mode);
    }

    public void SetPinMode(int pin, int mode)
    {
        byte[] message = new byte[3];
        message[0] = (byte)(SET_PIN_MODE);
        message[1] = (byte)(pin);
        message[2] = (byte)(mode);
        serialPort.Write(message, 0, 3);
        message = null;
    }

    /// <summary>
    /// Reports the analog.
    /// </summary>
    /// <param name='pin'>
    /// Pin number in analog numbering scheme. 
    /// </param>
    /// <param name='enable'>
    /// Enable (0 or 1)
    /// </param>		
    public void ReportAnalog(int pin, byte enable)
    {
        byte[] command = new byte[2];
        command[0] = (byte)(REPORT_ANALOG | pin);
        command[1] = (byte)enable;
        serialPort.Write(command, 0, 2);
    }

    /// <summary>
    /// Processes input from the arduino sensor to get a reading.
    /// </summary>
    private void ProcessSensorInput()
    {
        int processed = 0;

        while (processed < 64)
        {
            processed++;

            if (canPollBytesToRead && serialPort.BytesToRead == 0)
            {
                return;
            }

            int inputData = 0;
            int command;

            try
            {
                inputData = serialPort.ReadByte();
            }
            catch (System.Exception e)
            {
                if (e.GetType() == typeof(System.TimeoutException))
                    return;
                else
                {
                    Disconnect();
                    return;
                }
            }

            if (isParsingSysex)
            {
                if (inputData == START_SYSEX)
                {
                    isParsingSysex = false;
                    ProcessSysexMessage();
                }
                else
                {
                    storedInputData[sysexBytesRead] = inputData;
                    sysexBytesRead++;
                }
            }
            else if (waitForData > 0 && inputData < 128)
            {
                waitForData--;
                storedInputData[waitForData] = inputData;

                if (executeMultiByteCommand != 0 && waitForData == 0)
                {
                    switch (executeMultiByteCommand)
                    {
                        case DIGITAL_MESSAGE:
                            SetDigitalInputs
                            (
                                multiByteChannel, 
                                (storedInputData[0] << 7) + storedInputData[1]
                            );
                            break;

                        case ANALOG_MESSAGE:
                            SetAnalogInput
                            (
                                multiByteChannel, 
                                (storedInputData[0] << 7) + storedInputData[1]
                            );
                            break;

                        case REPORT_VERSION:
                            SetVersion(storedInputData[1], storedInputData[0]);
                            break;
                    }
                }
            }
            else
            {
                if (inputData < 0xF0)
                {
                    command = inputData & 0xF0;
                    multiByteChannel = inputData & 0x0F;
                }
                else
                {
                    command = inputData;
                }

                switch (command)
                {
                    case START_SYSEX:
                        isParsingSysex = true;
                        sysexBytesRead = 0;
                        break;
                    case DIGITAL_MESSAGE:
                    case ANALOG_MESSAGE:
                    case REPORT_VERSION:
                        waitForData = 2;
                        executeMultiByteCommand = command;
                        break;
                }
            }
        }
    }

    /// <summary>
    /// Digital data received event handler. Fired when digital data is received from the device.
    /// This event will only be fired for ports for which reporting has been enabled.
    /// </summary>
    /// <param name="portNumber">
    /// port number</param>
    /// <param name="portData">
    /// A bit vector encoding the current value of all input pins on the port.</param>

    public delegate void DigitalDataReceivedEventHandler(int portNumber, int portData);
    public event DigitalDataReceivedEventHandler DigitalDataReceived;

    private void SetDigitalInputs(int portNumber, int portData)
    {
        //Log("received digital data");
        digitalInputData[portNumber] = portData;
        if (DigitalDataReceived != null) DigitalDataReceived(portNumber, portData);
    }

    /// <summary>
    /// Analog data received event handler. Fired when new analog data is received from the device.
    /// This event will only be fired for analog pins for which reporting has been enabled.
    /// </summary>		
    public delegate void AnalogDataReceivedEventHandler(int pin, int value);
    public event AnalogDataReceivedEventHandler AnalogDataReceived;

    private void SetAnalogInput(int pin, int value)
    {
        analogInputData[pin] = value;
        if (AnalogDataReceived != null) AnalogDataReceived(pin, value);
    }

    /// <summary>
    /// Version data received event handler. Fired when version data is received.
    /// Request protocol version data with a call to reportVersion
    /// </summary>

    public delegate void VersionDataReceivedEventHandler(int majorVersion, int minorVersion);
    public event VersionDataReceivedEventHandler VersionDataReceived;

    private void SetVersion(int majorVersion, int minorVersion)
    {
        // Don't currently need to be referenced.
        //this.majorVersion = majorVersion;
        //this.minorVersion = minorVersion;

        if (VersionDataReceived != null)
        {
            VersionDataReceived(majorVersion, minorVersion);
        }
    }

    /// <summary>
    /// Capabilities received event handler. Fired when pin capabilities are received from device.
    /// Request pin capabilities with a call to queryCapabilities
    /// 
    /// </summary>
    public delegate void CapabilitiesReceivedEventHandler(List<Pin> pins);
    public event CapabilitiesReceivedEventHandler CapabilitiesReceived;

    /// <summary>
    /// Request firmware to report pin capabilities. 
    /// </summary>
    public void QueryCapabilities()
    {
        byte[] message = new byte[3];
        message[0] = (byte)(START_SYSEX);
        message[1] = (byte)(CAPABILITY_QUERY);
        message[2] = (byte)(END_SYSEX);
        serialPort.Write(message, 0, 3);
        message = null;
    }

    /// <summary>
    /// Processes a SysEx message (called during input processing).
    /// </summary>
    private void ProcessSysexMessage()
    {
        switch (storedInputData[0])
        {
            case CAPABILITY_RESPONSE:
                ParseCapabilityResponse();
                ReallocatePinArrays(pins);

                if (CapabilitiesReceived != null)
                    CapabilitiesReceived(pins);

                break;

            default:
                break;
        }
    }

    private void ReallocatePinArrays(List<Pin> pins)
    {
        System.Array.Resize(ref digitalInputData, pins.Count);
        System.Array.Resize(ref digitalOutputData, pins.Count);
        System.Array.Resize(ref analogInputData, pins.Count);
    }

    private void ParseCapabilityResponse()
    {
        int k = 0;
        int analog_channel_index = 0;
        int offset = 0;

        pins = new List<Pin>();

        offset++;

        while (offset < sysexBytesRead)
        {
            var p = new Pin() { number = k };
            while (storedInputData[offset] != 127)
            {
                var pc = new Pin.Capability()
                {
                    mode = storedInputData[offset],
                    resolution = storedInputData[offset + 1]
                };
                p.capabilities.Add(pc);

                if (pc.Mode == PinMode.ANALOG)
                {
                    p.analog_number = analog_channel_index;
                    analog_channel_index++;
                }

                offset += 2;
            }

            pins.Add(p);

            k++;
            offset += 1;
        }
    }

    #endregion
}