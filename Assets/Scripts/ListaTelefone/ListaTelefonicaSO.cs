using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct NomeTelefone
{
    public string nome;
    public string telefone;
}

[CreateAssetMenu(menuName = "Lista Telefonica")]
public class ListaTelefonicaSO : ScriptableObject
{
    [Header("Nomes e Numeros de Telefone")]
    public List<NomeTelefone> nomeNumeros = new();

    public string numeroAjuda;

    private Dictionary<string, string> numeroParaNome;

    public string GetNumeroAjuda()
    {
        return numeroAjuda;
    }

    private void InicializarDicionario()
    {
        numeroParaNome = new Dictionary<string, string>();

        foreach (var item in nomeNumeros)
        {
            numeroParaNome.Add(item.telefone, item.nome);
        }
    }

    private string CalculateHashStr(string numero)
    {
        Debug.Log("CalculateHashStr numero " + numero);
        if (int.TryParse(numero, out int numeroInt))
        {
            return Animator.StringToHash(numero).ToString();
        }
        return "";
    }

    public bool IsNumeroValido(string numero)
    {
        // inicializa o dict se nao tiver iniciado
        if (numeroParaNome == null) { InicializarDicionario(); }

        Debug.Log("CalculateHashStr(numero) = " + CalculateHashStr(numero));
        Debug.Log("Contains " + numeroParaNome.ContainsKey(CalculateHashStr(numero)));

        return numeroParaNome.ContainsKey(numero) || numeroParaNome.ContainsKey(CalculateHashStr(numero));
    }

    
    public string GetNomeParaNumero(string numero)
    {
        // inicializa o dict se nao tiver iniciado
        if (numeroParaNome == null) { InicializarDicionario(); }

        // retorna o nome se o numero estiver no dict 
        if (numeroParaNome.TryGetValue(numero, out string nome)) return nome;
        // retorna o nome se o hash do numero estiver no dict
        if (numeroParaNome.TryGetValue(CalculateHashStr(numero), out string nomeH)) return nomeH;

        // se nao tiver numero no dict
        return null;
    }
}
