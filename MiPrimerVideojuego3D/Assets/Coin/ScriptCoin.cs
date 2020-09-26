using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class ScriptCoin : MonoBehaviour
{

    public static int coinCount=0;
    // Start is called before the first frame update
    void Start()
    {
        ScriptCoin.coinCount++;
        Debug.Log("El juego ha comenzado y ahora hay " + ScriptCoin.coinCount + " monedas");   
    }

    // Update is called once per frame
    void Update()
    {
       // UnityEngine.Debug.Log("Este mensaje si aparece");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ScriptCoin.coinCount--;
            Debug.Log("Hemos recogido una moneda");

            if (ScriptCoin.coinCount == 0)
            {
                Debug.Log("El juego ha terminado");
                GameObject gameManager = GameObject.Find("GameManager");
                Destroy(gameManager);
                GameObject[] fireworkSystem = GameObject.FindGameObjectsWithTag("Fireworks");

                foreach(GameObject firework in fireworkSystem)
                    {
                    firework.GetComponent<ParticleSystem>().Play();
                }
            }
            Destroy(gameObject);

            

        }
        
    }
}
