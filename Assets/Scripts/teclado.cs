using UnityEngine;
using Fungus;

public class teclado : MonoBehaviour
{
    public string resposta;
    private string entrada = "";
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    public void AddSimbolo(string simbolo)
    {
        entrada += simbolo;
        if (entrada == resposta || entrada.Length > 5)
        {
            GameManagerTestNight.Instance.MostrarItens();

            Flowchart.BroadcastFungusMessage("FazerLigacaoFinal");
        }
    }
}
