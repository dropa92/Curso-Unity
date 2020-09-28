using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Este documento está creado con la única finalidad de campo de prácticas para aprender a usar variables. No tiene ningún utilidad práctica en el videojuego.

public class VariableScript : MonoBehaviour
{

    /*
     * Zona de declaración de variables
     */

    public int myNumber = 30;
    public int total;

    // Start is called before the first frame update
    void Start()
    {
        total = myNumber - 5; // Total = 25
        Debug.Log("Total: " + total);
        Debug.Log(6 + 5);
    }

    // Update is called once per frame
    void Update()
    {
        // Comprobamos si la tecla retorno ha sido pulsada y llamamos al método sumarNumeros()
        if (Input.GetKeyDown(KeyCode.Return))
        {
            sumarNumeros();
        }
    }

    void sumarNumeros()
    {
        Debug.Log(6 + 5);
    }
}
