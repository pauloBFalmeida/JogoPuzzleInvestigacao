using UnityEngine;

public class TelefoneInteracao : ObjetoInteracao
{
    private TelefoneUI TelefoneUI;

    public ListaTelefonicaSO listaTelefonica;

    public override void Interact()
    {
        if (TelefoneUI == null) { TelefoneUI = uiInstancia.GetComponent<TelefoneUI>(); }

        base.Interact();
        TelefoneUI.Show();
    }

    public override void receberFeedback(string numero)
    {
        Debug.Log("Numero discado: " + numero);
        Debug.Log("Nome: " + listaTelefonica.GetNomeParaNumero(numero));

    }

}
