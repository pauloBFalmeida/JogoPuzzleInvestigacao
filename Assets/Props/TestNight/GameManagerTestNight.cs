using System.Collections.Generic;
using UnityEngine;
using Fungus;

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

    public void EsconderTudo()
    {
        foreach (GameObject obj in itensClicaveis) { obj.SetActive(false); }
    }
    
    public void MostrarTudo()
    {
        foreach (GameObject obj in itensClicaveis) { obj.SetActive(true); }
    }

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
        if (itemSendoMostrado != null) {
            itemSendoMostrado.SetActive(false); 
            // passa a info q fechou   
            if (itemSendoMostrado.TryGetComponent<TelefoneWrapper>(out TelefoneWrapper telefoneWrapper))
            {
                telefoneWrapper.discador.SairDiscagem();
            }
            if (itemSendoMostrado.TryGetComponent<teclado>(out teclado tecladinho))
            {
                tecladinho.Sair();
            }
        }

        // mostra os itens clicaveis do cenario
        foreach (GameObject obj in itensClicaveis)
        {
            obj.SetActive(true);
        }
    }

    public void SetActiveHitboxSairUI(bool active) { hitboxSairUI.SetActive(active); }

    public void FazerLigacao(string nome)
    {
        switch (nome)
        {
            case "Joao":
                AnimLigacao();
                Invoke("FazerLigacaoJoao", 1.0f);
                break;
            case "playstation":
                AnimLigacao();
                Invoke("FazerLigacaoPlaystation", 1.0f);
                break;
            case "Puzzle":
                AnimLigacao();
                Invoke("FazerLigacaoPuzzle", 1.0f);
                break;
            case "Ovis":
                AnimLigacao();
                Invoke("FazerLigacaoOvis", 1.0f);
                break;
            case "ajuda2":
                AnimLigacao();
                Invoke("FazerLigacaoMonodo", 1.0f);
                break;
            default:
                break;

        }
    }

    
    private void AnimLigacao()
    {
        
    }

    private void FazerLigacaoPuzzle()
    {
        GameManagerTestNight.Instance.MostrarItens();
        Flowchart.BroadcastFungusMessage("ligou_puzzle");
    }

    private void FazerLigacaoOvis()
    {
        GameManagerTestNight.Instance.MostrarItens();
        Flowchart.BroadcastFungusMessage("ligou_ajuda_1");
    }

    private void FazerLigacaoJoao()
    {
        GameManagerTestNight.Instance.MostrarItens();
        Flowchart.BroadcastFungusMessage("ligou_joao");
    }
    private void FazerLigacaoPlaystation()
    {
        GameManagerTestNight.Instance.MostrarItens();
        Flowchart.BroadcastFungusMessage("ligou_ps");
    }
    
    private void FazerLigacaoMonodo()
    {
        GameManagerTestNight.Instance.MostrarItens();
        Flowchart.BroadcastFungusMessage("ligou_ajuda_2");
    }
}
