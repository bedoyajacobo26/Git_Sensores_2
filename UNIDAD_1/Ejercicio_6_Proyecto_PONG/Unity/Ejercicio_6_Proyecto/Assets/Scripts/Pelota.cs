using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pelota : MonoBehaviour
{
    int velX;
    int velY;

    float velocidad;

    public ParticleSystem particulas;
    

    // Start is called before the first frame update
    void Start()
    {
        movimientoPelota();
    }

    // Update is called once per frame
    void Update()
    {
        
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
    }
}
