using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jugador : MonoBehaviour
{
    public KeyCode arriba;
    public KeyCode abajo;

    float velocidad;
    float limPosicion;
    // Start is called before the first frame update
    void Start()
    {
        velocidad = 0.05f;
        limPosicion = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(arriba))
        {
            if (transform.position.y >= 2.5)
            {
                limPosicion = 0;
            }
            else
            {
                limPosicion = 1;
            }
            transform.Translate(0, velocidad*limPosicion, 0);
        }
        else if (Input.GetKey(abajo))
        {
            if (transform.position.y <= -2.5)
            {
                limPosicion = 0;
            }
            else
            {
                limPosicion = 1;
            }
            transform.Translate(0, -velocidad*limPosicion, 0);
        }
    }
}
