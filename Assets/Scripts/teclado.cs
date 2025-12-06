using UnityEngine;
using System.Collections.Generic;
using Fungus;
using Unity.VisualScripting;

public class teclado : MonoBehaviour
{   
    public TMPro.TextMeshPro textoTecla;
    [SerializeField] public int[] sequenciaCorreta = 
        { 5, 19, 16, 8, 12, 16, 12 };
    private int sequenciaIndiceAtual = 0;

    public List<AudioClip> audiosTeclas;
    public AudioClip audioSequenciaCorreta;
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

    public void TeclaEmCima(int teclaIndex)
    {
        // mostra o simbolo
        textoTecla.text = "" + simbolosTeclas[teclaIndex];
    }

    public void TeclaPressionada(int teclaIndex)
    {
        // play audio
        audioSource.clip = audiosTeclas[teclaIndex];
        audioSource.Play();

        // mostra o simbolo
        textoTecla.text = "" + simbolosTeclas[teclaIndex];
        
        // monta a resposta
        VerificarSequencia(teclaIndex);
    }

    private void VerificarSequencia(int nota)
    {
        Debug.Log("nota " + nota);
        if (nota == sequenciaCorreta[sequenciaIndiceAtual])
        {
            sequenciaIndiceAtual++;
            if (sequenciaIndiceAtual == sequenciaCorreta.Length)
            {
                Invoke("SequenciaCompleta", 1.0f);
            }
        }
        else
        {
            sequenciaIndiceAtual = 0; // erro: reinicia
            // se errou apertando a primeira nota da sequencia correta
            if (nota == sequenciaCorreta[sequenciaIndiceAtual]) { 
                sequenciaIndiceAtual++;
            }
        }
        Debug.Log("sequenciaIndiceAtual " + sequenciaIndiceAtual);
    }

    private void SequenciaCompleta()
    {
        // tocar musica
        audioSource.clip = audioSequenciaCorreta;
        audioSource.Play();
        // chamar o dialogo final
        GameManagerTestNight.Instance.MostrarItens();
        Flowchart.BroadcastFungusMessage("FazerLigacaoFinal");
    }


    public void Mostrar()
    {
        SetAtivaHitboxGeralSair(false);
    }

    public void Sair()
    {
        sequenciaIndiceAtual = 0;
    }

    private void SetAtivaHitboxGeralSair(bool ativar)
    {
        GameManagerTestNight.Instance.SetActiveHitboxSairUI(ativar);
    }
}
