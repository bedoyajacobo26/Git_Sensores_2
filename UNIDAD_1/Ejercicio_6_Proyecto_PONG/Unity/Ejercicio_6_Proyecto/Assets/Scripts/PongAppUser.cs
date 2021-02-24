using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PongAppUser : MonoBehaviour
{
    public SerialController serialController;

    //PELOTA
    int velX;
    int velY;
    float velocidad;
    public ParticleSystem particulas;

    //MARCADOR
    public Text text_resultadoP1;
    public Text text_resultadoP2;
    public Text text_ganador;
    int resultadoP1 = 0;
    int resultadoP2 = 0;
    //JUGADORES
    public GameObject jugador_1;
    public GameObject jugador_2;
    public float limSup = 5f;
    public float limInf = -5f;
    //POTENCIOMETROS
    public float valPot1 = 0f;
    public float mapPot1 = 0f;
    public float valPot2 = 0f;
    public float mapPot2 = 0f;
    float a;
    char[] delimitadores = {','};
    
    // Start is called before the first frame update
    void Start()
    {
        serialController = GameObject.Find("SerialController").GetComponent<SerialController>();

        movimientoPelota();

        text_resultadoP1.text = "0";
        text_resultadoP2.text = "0";
    }

    // Update is called once per frame
    void Update()
    {

        text_resultadoP1.text = resultadoP1.ToString();
        text_resultadoP2.text = resultadoP2.ToString();

        

        if (resultadoP1 == 5)
        {
            text_ganador.gameObject.SetActive(true);
            text_ganador.text = "Jugador 1 Gana";
            resetearPelota();
        }
        else if (resultadoP2 == 5)
        {
            text_ganador.gameObject.SetActive(true);
            text_ganador.text = "Jugador 2 Gana";
            resetearPelota();
        }

        string message = serialController.ReadSerialMessage();

        if (message == null)
        {
            return;
        }

        valPot1 = (float.Parse(message.Substring(0, message.IndexOf(','))))/100;
        valPot2 = (float.Parse(message.Substring(message.IndexOf(',') + 1)))/100;

        mapPot1 = Map(valPot1, 0, 1023, limInf, limSup);
        mapPot2 = Map(valPot2, 0, 1023, limInf, limSup);

        jugador_1.transform.position = new Vector3(jugador_1.transform.position.x, mapPot1, jugador_1.transform.position.z);
        jugador_2.transform.position = new Vector3(jugador_2.transform.position.x, mapPot2, jugador_2.transform.position.z);


        if (message == null)
            return;

        // Check if the message is plain data or a connect/disconnect event.
        if (ReferenceEquals(message, SerialController.SERIAL_DEVICE_CONNECTED))
            Debug.Log("Connection established");
        else if (ReferenceEquals(message, SerialController.SERIAL_DEVICE_DISCONNECTED))
            Debug.Log("Connection attempt failed or disconnection detected");
        else
            Debug.Log("Valores potenciometroa : " + message);

    }

    public void movimientoPelota()
    {
        velocidad = Random.Range(5, 10);

        velX = Random.Range(0, 2);
        if (velX == 0)
        {
            velX = 1;
        }
        else
        {
            velX = -1;
        }

        velY = Random.Range(0, 2);
        if (velY == 0)
        {
            velY = 1;
        }
        else
        {
            velY = -1;
        }

        GetComponent<Rigidbody>().velocity = new Vector3(velocidad * velX, velocidad * velY, 0);
    }
    public void resetearPelota()
    {
        transform.localPosition = new Vector3(0, 0, 0);
        GetComponent<Rigidbody>().velocity = Vector3.zero;
    }

    void OnCollisionEnter(Collision objeto)
    {
        if (objeto.collider.tag == "Player")
        {
            particulas.Play();
        }

        else if (objeto.collider.tag == "porteria1")
        {
            resultadoP2++;
            serialController.SendSerialMessage("B");
            resetearPelota();
            Invoke("movimientoPelota", 1.5f);

        }
        else if (objeto.collider.tag == "porteria2")
        {
            serialController.SendSerialMessage("A");
            resultadoP1++;
            resetearPelota();
            Invoke("movimientoPelota", 1.5f);
        }
    }

    public float Map(float input, float inputMin, float inputMax, float min, float max)
    {
        return min + (input - inputMin) * (max - min) / (inputMax - inputMin);
    }
}
