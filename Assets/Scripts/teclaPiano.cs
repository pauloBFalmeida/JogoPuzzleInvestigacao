using System;
using UnityEngine;

public class teclaPiano : MonoBehaviour
{
    public int simboloIndex;
    public teclado tecladinho;

    void OnMouseDown()
    {
        tecladinho.Clicado(simboloIndex);
    }
}