using UnityEngine;

public class TelefoneUI : UIInteracao
{
    public ListaTelefonicaSO listaTelefonica;

    void Start()
    {
        StartUI();
        currNumero = "";
    }

    private string currNumero;

    public void OnDigitoPressed(int digito)
    {
        Debug.Log("digito: " + digito);
        
        currNumero += digito;

        if (listaTelefonica.IsNumeroValido(currNumero))
        {
            objetoInteracaoRef.receberFeedback(currNumero);
            Hide();
        }
    }

}
