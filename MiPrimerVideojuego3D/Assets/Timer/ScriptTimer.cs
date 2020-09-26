using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScriptTimer : MonoBehaviour
{
    public float maxTime = 60f;

    private float countDown = 0f;

    // Start is called before the first frame update
    void Start()
    {
        countDown = maxTime;
        
    }

    // Update is called once per frame
    void Update()
    {
        //El DeltaTime es el tiempo en segundos que ha pasado desde que se renderizó en pantalla el último Frame anterior
        countDown = countDown - Time.deltaTime;
        Debug.Log("Cuenta atrás: " + countDown);
        if (countDown <= 0)
        {
            Debug.Log("Te has quedado sin tiempo... HAS PERDIDO");

            ScriptCoin.coinCount = 0;
            SceneManager.LoadScene("MainScene");
        }
    }
}
