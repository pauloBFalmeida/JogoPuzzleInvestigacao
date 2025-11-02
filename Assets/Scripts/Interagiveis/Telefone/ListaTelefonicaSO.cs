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

    private Dictionary<string, string> numeroParaNome;

    private void InicializarDicionario()
    {
        numeroParaNome = new Dictionary<string, string>();

        foreach (var item in nomeNumeros)
        {
            numeroParaNome.Add(item.telefone, item.nome);
        }
    }

    public bool IsNumeroValido(string numero)
    {
        if (numeroParaNome == null) { InicializarDicionario(); }

        return numeroParaNome.ContainsKey(numero);
    }
    
    public string GetNomeParaNumero(string numero)
    {
        if (numeroParaNome == null) { InicializarDicionario(); }

        if (numeroParaNome.TryGetValue(numero, out string nome))
            return nome;
        // se nao tiver numero no dict
        return null;
    }
}
