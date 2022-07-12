using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvertArray : MonoBehaviour
{

    public int[] arrayNumeros;

    public int[] arrayInvertida;


    void Start()
    {
        arrayInvertida = new int[5];

        arrayInvertida[0] = arrayNumeros[4];

        print(arrayInvertida[0]);
        //Physics.Raycast(
        //Physics.Linecast(
    }


}
