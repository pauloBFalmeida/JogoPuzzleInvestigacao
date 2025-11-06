using UnityEngine;
using TMPro;

public class TextoDiscador : MonoBehaviour
{
    private string digitoAtual = "";
    private string numeroConfirmado = "";

    private TextMeshPro TextMesh;

    void Start()
    {
        TextMesh = this.GetComponent<TextMeshPro>();
    }

    public void UpdateDigitoTextoNumero(int digito)
    {
        if (digito < 0 || digito > 9)
        {
            digitoAtual = "";
            return;
        }
        if (numeroConfirmado.Length > 10) { return; }

        digitoAtual = digito.ToString();
        TextMesh.text = numeroConfirmado + digitoAtual;
    }
    
    public void UpdateNumero()
    {
        numeroConfirmado = numeroConfirmado + digitoAtual;
    }
}
