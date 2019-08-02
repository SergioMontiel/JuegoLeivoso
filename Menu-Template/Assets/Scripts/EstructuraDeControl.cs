using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EstructuraDeControl : MonoBehaviour
{

    public int vida = 150;
    public string nombre = "cincopeso";

    // Start is called before the first frame update
    void Start()
    {
        /*
        if (vida>100)
        {
            Debug.Log("El jugador tiene vida mayor a 50");
        }
        else if(vida>30)
        {
            Debug.Log("Daño desconocido");
        }
        else
        {
            Debug.Log("Tienes poca vida");
        }
        */

    }

    // Update is called once per frame
    void Update()
    {
        if (vida > 100)
        {
            Debug.Log("El jugador tiene vida mayor a 50");
        }
        else if (vida > 30)
        {
            Debug.Log("Daño desconocido");
        }
        else
        {
            Debug.Log("Tienes poca vida");
        }
    }
}
