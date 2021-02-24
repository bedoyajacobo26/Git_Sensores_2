using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BinaryPongAppUser : MonoBehaviour
{
    public BinarySerialController BinarySerialController;
    public PongAppUser PongApp;

    // Start is called before the first frame update
    void Start()
    {
        BinarySerialController = GameObject.Find("BinarySerialController").GetComponent<BinarySerialController>();
    
    }

    // Update is called once per frame
    void Update()
    {
        
        byte[] message = BinarySerialController.ReadSerialMessage();
        

        if (message[0] == 0x1)
        {
            
            PongApp.movimientoPelota();
        }
        else
            return;
        

        if (message == null)
            return;

        // Check if the message is plain data or a connect/disconnect event.
        if (ReferenceEquals(message, SerialController.SERIAL_DEVICE_CONNECTED))
            Debug.Log("Connection established");
        else if (ReferenceEquals(message, SerialController.SERIAL_DEVICE_DISCONNECTED))
            Debug.Log("Connection attempt failed or disconnection detected");
        else
            Debug.Log("Valor botón :" + message[0]);
    }
}
