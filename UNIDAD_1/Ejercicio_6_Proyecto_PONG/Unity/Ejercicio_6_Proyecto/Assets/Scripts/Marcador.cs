using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Marcador : MonoBehaviour
{
    public Text text_resultadoP1;
    public Text text_resultadoP2;
    public Text text_ganador;
    public Pelota pelota ;

    int resultadoP1 = 0;
    int resultadoP2 = 0;

    // Start is called before the first frame update
    void Start()
    {
        text_resultadoP1.text = "0";
        text_resultadoP2.text = "0";

    }

    // Update is called once per frame
    void Update()
    {
        text_resultadoP1.text = resultadoP1.ToString();
        text_resultadoP2.text = resultadoP2.ToString();

        if(resultadoP1 == 5)
        {
            text_ganador.gameObject.SetActive(true);
            text_ganador.text = "Jugador 1 Gana";
            pelota.resetearPelota();
        }
        else if (resultadoP2 == 5)
        {
            text_ganador.gameObject.SetActive(true);
            text_ganador.text = "Jugador 2 Gana";
            pelota.resetearPelota();
        }

    }

    void OnCollisionEnter(Collision objeto)
    {
        if (objeto.collider.tag == "porteria1")
        {
            resultadoP2++;
            pelota.resetearPelota();
            Invoke("moverPelota", 1.5f);
           
        }
        else if (objeto.collider.tag == "porteria2")
        {
            resultadoP1++;
            pelota.resetearPelota();
            Invoke("moverPelota", 1.5f);
        }
    }

    void moverPelota()
    {
        pelota.movimientoPelota();
    }
}
