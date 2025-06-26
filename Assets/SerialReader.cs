using System.IO.Ports;
using UnityEngine;

public class SerialReader : MonoBehaviour
{
    public string portName = "COM3";
    public int baudRate = 9600;

    private SerialPort serialPort = null;
    public static Instruction? instruction = null;

    public enum Instruction
    {
        MOVE_UP = 0,
        MOVE_DOWN = 1,
        MOVE_LEFT = 2,
        MOVE_RIGHT = 3,
    };

    void Start()
    {
        serialPort = new SerialPort(portName, baudRate)
        {
            ReadTimeout = 500
        };
        serialPort.Open();
    }

    void Update()
    {
        if (serialPort != null && serialPort.IsOpen && serialPort.BytesToRead > 0)
        {
            instruction = (Instruction)serialPort.ReadByte();
            Debug.Log(instruction);
        }
        else
        {
            instruction = null;
        }
    }

    void OnDestroy()
    {
        if (serialPort != null && serialPort.IsOpen)
        {
            serialPort.Close();
            instruction = null;
        }
    }
}