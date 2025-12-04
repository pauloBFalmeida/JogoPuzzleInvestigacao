using UnityEngine;

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
        if (entrada == resposta)
        {
            Invoke("FazerLigacaoFinal", .5f);
        }
    }
}
