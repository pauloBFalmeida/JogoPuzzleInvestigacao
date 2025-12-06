using UnityEngine;
using System.Collections.Generic;
using Fungus;
using Unity.VisualScripting;

public class teclado : MonoBehaviour
{   
    public TMPro.TextMeshPro textoTecla;
    public string resposta = "123";
    private string entrada = "";

    public List<AudioClip> audiosTeclas;
    private AudioSource audioSource;

    public readonly List<string> simbolosTeclas = new List<string>
    {
        "\U0001F702",
        "\U0001F73C",
        "\U0001F73E",
        "\U0001F707",
        "\U0001F709",
        "\U0001F70B",
        "\U0001F70E",
        "\U0001F70F",
        "\U0001F711",
        "\U0001F717",
        "\U0001F719",
        "\U0001F71A",
        "\U0001F71B",
        "\U0001F71D",
        "\U0001F71F",
        "\U0001F720",
        "\U0001F722",
        "\U0001F725",
        "\U0001F72A",
        "\U0001F72C",
        "\U0001F732",
        "\U0001F74F",
        "\U0001F756",
        "\U0001F762",
        "\U0001F773",
    };

    
    private void Awake()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
    }

    public void Clicado(int teclaIndex)
    {
        // play audio
        audioSource.clip = audiosTeclas[teclaIndex];
        audioSource.Play();

        // mostra o simbolo
        textoTecla.text = "" + simbolosTeclas[teclaIndex];
        
        // monta a resposta
        entrada += teclaIndex;
        Debug.Log("entrada " + entrada + " resposta " + resposta);
        if (entrada == resposta)
        {
            GameManagerTestNight.Instance.MostrarItens();
            Flowchart.BroadcastFungusMessage("FazerLigacaoFinal");
        }
    }


    public void Mostrar()
    {
        SetAtivaHitboxGeralSair(false);
    }

    public void Sair()
    {
        entrada = "";
    }

    private void SetAtivaHitboxGeralSair(bool ativar)
    {
        GameManagerTestNight.Instance.SetActiveHitboxSairUI(ativar);
    }
}
