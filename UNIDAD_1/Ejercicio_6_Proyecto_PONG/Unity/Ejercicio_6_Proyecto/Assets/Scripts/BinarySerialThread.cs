using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;

using System.Text;

public class BinarySerialThread : AbstractSerialThread
{
    private byte[] buffer = new byte[1];
    public BinarySerialThread(string portName,
                                     int baudRate,
                                     int delayBeforeReconnecting,
                                     int maxUnreadMessages)
      : base(portName, baudRate, delayBeforeReconnecting, maxUnreadMessages, false)
    {

    }

    protected override void SendToWire(object message, SerialPort serialPort)
    {
        byte[] binaryMessage = (byte[])message;
        serialPort.Write(binaryMessage, 0, binaryMessage.Length);
    }

    protected override object ReadFromWire(SerialPort serialPort)
    {
        serialPort.Read(buffer, 0, 1);
        return buffer;
        
    }
}
