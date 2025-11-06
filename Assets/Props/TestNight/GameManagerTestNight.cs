using System.Collections.Generic;
using UnityEngine;

public class GameManagerTestNight : MonoBehaviour
{
    public static GameManagerTestNight Instance { get; private set; }

    void Start()
    {
        // Se ja existe, acabe
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    public GameObject hitboxSairUI;
    public List<GameObject> itensClicaveis = new();
    private GameObject itemSendoMostrado;

    public void EsconderItens(GameObject itemMostrar)
    {
        // mostra hitbox para sair da ui
        hitboxSairUI.SetActive(true);
        // guarda a ui atual que vai ser mostrada
        itemSendoMostrado = itemMostrar;

        // esconde os itens clicaveis do cenario
        foreach (GameObject obj in itensClicaveis)
        {
            obj.SetActive(false);
        }
    }

    public void MostrarItens()
    {
        // esconde hitbox para sair da ui
        hitboxSairUI.SetActive(false);
        // esconde a ui atual
        if (itemSendoMostrado != null) { itemSendoMostrado.SetActive(false); }

        // mostra os itens clicaveis do cenario
        foreach (GameObject obj in itensClicaveis)
        {
            obj.SetActive(true);
        }
    }
}
