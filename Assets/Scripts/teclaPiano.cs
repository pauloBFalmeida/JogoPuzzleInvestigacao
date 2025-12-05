using System;
using UnityEngine;

public class teclaPiano : MonoBehaviour
{
    public TMPro.TextMeshPro textoTecla;
    public int simboloIndex;
    public teclado tecladinho;
    void Update()
    {
        // Detecta clique do mouse (ou toque na tela)
        if (Input.GetMouseButtonDown(0))
        {
            // Converte a posição do mouse para uma posição no mundo
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            // Faz um raycast na posição do mouse para detectar colliders 2D
            RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);

            // Verifica se o raycast atingiu algum collider
            if (hit.collider != null)
            {
                // Verifica se o collider atingido é o deste GameObject
                if (hit.collider.gameObject == gameObject)
                {
                    textoTecla.text = "" + tecladinho.simbolosTeclas[simboloIndex];
                    tecladinho.AddSimbolo(simboloIndex);
                }
            }
        }
    }
}