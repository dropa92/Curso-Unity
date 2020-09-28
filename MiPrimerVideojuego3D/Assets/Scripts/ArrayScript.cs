using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class ArrayScript : MonoBehaviour
{
    // TODAS LAS ESTRUCTURAS DE DATOS EMPIEZAN DESDE LA POSICION 0
    // EL ULTIMO ELEMENTO DE UN ARRAY ES EL DE SU DIMENSION MENOS 1
    
    /* Los Arrays son colecciones de objetos los cuales comparten las mismas características, ya sea nombre, edad, altura, etc. Pueden tener todo lo que quieran siempre y cuando sean objetos similares.
*  Los Arrays tienen unas dimensiones fijas. Una vez que se crean, no pueden aumentar su tamaño, o disminuirlo. Siempre mantendran su capacidad intacta.

    ARRAY
    - Es homogéneo (solo un tipo de dato)
    - Es de tamaño fijo (una vez creado no se pueden crear más elementos)
    - Tiene un orden
 **/

    string student1 = "paco";
    string student2 = "marco";
    string student3 = "ana";
    string student4 = "esther";

    //Aquí estamos creando el Array y le estamos dando valores a sus posiciones
    string[] students = new string[] { "paco", "marco", "ana", "esther" };
    
    //Aquí estamos creando y el Array y asignandole las posiciones, pero no le estamos dando valor a esas posiciones
    string[] familyNames = new string[4];



    /*
     * LISTA
     * - Es homogéneo (Solo un tipo de dato)
     * --La Lista es de tamaño ajustable (podemos añadir o eliminar elementos en tiempo real)
     * - Tiene un orden (se accede por posición)
     */

    public List<string> studentsNames = new List<string>();
    


   
    // Start is called before the first frame update
    void Start()
    {
        //Aquí la lista está vacia
        //El metodo ADD añade un elemento al final de la lista
        studentsNames.Add("Paco");
        //Aquí la lista tiene 1 elemento

        studentsNames.Add("Marco");
        //Aquí la lista tiene 2 elementos

        studentsNames.Add("Ana");
        //Aquí la lista tiene 3 elementos

        studentsNames.Add("Esther");
        //Aquí la lista tiene 4 elementos

        studentsNames.Add("Antonio");
        //Aquí la lista tiene 5 elementos

        if (studentsNames.Contains("Antonio"))
        {
            studentsNames.Remove("Antonio");
            //Aquí se elimina un elemento de la lista

        }
        //El metodo INSERT inserta un valor en la posición que le indicamos, desplazando así el resto de la lista hacia una posición de +1
        studentsNames.Insert(2, "Paula");

        //El método TOARRAY devuelve un ARRAY de un ARRAYLIST
        string[] arrayStudents=studentsNames.ToArray();

        //La funcion CLEAR elimina de forma definitiva todos los elementos del ARRAYLIST
        studentsNames.Clear();


        //El primer estudiante de la LISTA
        Debug.Log(studentsNames[0]);

        //El segundo estudiante de la LISTA
        Debug.Log(studentsNames[1]);


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
