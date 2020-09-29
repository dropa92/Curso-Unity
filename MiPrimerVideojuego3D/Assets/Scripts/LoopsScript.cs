using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopsScript : MonoBehaviour
{

    public List<string> studentsNames = new List<string>();

    // Start is called before the first frame update
    void Start()
    {
        /**
         *forecah(Type elementName in collection)
         *{   //codigo del bucle
         *   
         *     }
         */

        studentsNames.Add("Paco");
        //Aquí la lista tiene 1 elemento
        studentsNames.Add("Marco");
        //Aquí la lista tiene 2 elementos
        studentsNames.Add("Ana");
        //Aquí la lista tiene 3 elementos
        studentsNames.Add("Esther");
        //Aquí la lista tiene 4 elementos
        studentsNames.Add("Antonio");


        foreach (string person in studentsNames)
        {
            Debug.Log(person);
        }

        /**
         * FOR --> Este bucle se utiliza para acceder a posiciones
         * for(inicialización; condición de continuación; interador){
         *      //Código del bucle
         * }
         */

        Debug.Log("Imprimiendo con el For");
        for (int i=1;i<=10; i++){
            Debug.Log(i);
        }

        /**
         *WHILE
         *while(condición){
         *    //Código a ejecutar
         *    //iterador
         * }
         * 
         *  //La variables del bucle sigue existiendo despues...
         */

        Debug.Log("Contar de 1 a 10 con bucle while");

        int counter = 1;
        while (counter <= 10)
        {
            Debug.Log(counter);
            counter++;
        }




       

    }



    /**
     * EJERCICIO NUMEROS PAR E IMPARES 
     */

    public bool IsNumberEvent(int number)
    {
        int reminder = number % 2;
        if (reminder == 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
