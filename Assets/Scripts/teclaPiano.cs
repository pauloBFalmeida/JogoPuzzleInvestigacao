using System;
using UnityEngine;

public class teclaPiano : MonoBehaviour
{
    public int simboloIndex;
    public teclado tecladinho;

    void OnMouseDown()
    {
        tecladinho.TeclaPressionada(simboloIndex);
    }

    void OnMouseOver()
    {
        tecladinho.TeclaEmCima(simboloIndex);
    }
}