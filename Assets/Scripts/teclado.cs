using UnityEngine;
using System.Collections.Generic;
using Fungus;

public class teclado : MonoBehaviour
{   
    private string resposta = "123"; // TODO public
    private string entrada = "";

    public readonly List<string> simbolosTeclas = new List<string>
    {
        "\U0001F702",
        "\U0001F704",
        "\U0001F705",
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
        // "\U000",
        // "\U000",
        // "\U000",
        // "\U000",
        // "\U000",
        // "\U000",
        // "\U000",
        // "\U000",
        // "\U000",
        // "\U000",
        // "\U000",
        // "\U000",
        // "\U000",
        // "\U000",
        // "\U000",
        // "\U000",
        // "\U000",
    };

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    public void AddSimbolo(int simboloIndex)
    {
        entrada += simboloIndex;
        Debug.Log("entrada " + entrada);
        Debug.Log("resposta " + resposta);
        Debug.Log("== " + (entrada == resposta) );
        if (entrada == resposta)
        {
            Debug.Log("== " + (entrada == resposta) );
            GameManagerTestNight.Instance.MostrarItens();

            Flowchart.BroadcastFungusMessage("FazerLigacaoFinal");
        }
    }

    public void SairDiscagem()
    {
        entrada = "";
    }
}
