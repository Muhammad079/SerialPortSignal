using System;
using System.IO.Ports;
using System.Threading;
using UnityEngine;

public class SerialDataSender : MonoBehaviour
{
    [Header("Serial Port Settings")]
    [SerializeField] private string serialPortName = "COM7";
    [SerializeField] private int baudRate = 115200;

    private SerialPort serialPort;
    private Thread openPortThread;
    private bool isPortOpen = false;

    void Start()
    {
        serialPortName = ConfigManager.GetInstance().GetStringValue("SERIAL_PORT_NAME");
        baudRate = ConfigManager.GetInstance().GetValue("SERIAL_BAUD_RATE");
        openPortThread = new Thread(OpenPort);
        openPortThread.IsBackground = true; // Runs in the background
        openPortThread.Start();
    }

    void OnDestroy()
    {
        ClosePort();
    }

    private void OnApplicationQuit()
    {
        ClosePort();
    }

    private void OpenPort()
    {
        try
        {
            serialPort = new SerialPort(serialPortName, baudRate, Parity.None, 8, StopBits.One);

            if (!serialPort.IsOpen)
            {
                serialPort.Open();
                isPortOpen = true;
                Debug.LogAssertion($"Serial port {serialPortName} opened successfully.");
            }
        }
        catch (Exception e)
        {
            Debug.LogAssertion($"Failed to open serial port: {e.Message}");
        }
    }

    public void SendData(string data)
    {
        if (serialPort != null && serialPort.IsOpen)
        {
            try
            {
                serialPort.WriteLine(data);
                Debug.LogAssertion($"Sent: {data}");
            }
            catch (Exception e)
            {
                Debug.LogAssertion($"Error sending data: {e.Message}");
            }
        }
        else
        {
            Debug.LogError("Serial port is not open. Cannot send data.");
        }
    }

    public void ClosePort()
    {
        if (serialPort != null && serialPort.IsOpen)
        {
            serialPort.Close();
            serialPort.Dispose();
            Debug.LogAssertion($"Serial port {serialPortName} closed.");
        }
    }

}