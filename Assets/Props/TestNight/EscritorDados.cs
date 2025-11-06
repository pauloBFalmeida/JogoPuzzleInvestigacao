using System;
using System.IO;
using UnityEngine;

public class EscritorDados : MonoBehaviour
{
    public void EscreverHorario()
    {
        string caminho = Application.persistentDataPath + "/dados.csv";

        // Cria o cabeçalho (se o arquivo não existir)
        if (!File.Exists(caminho))
        {
            File.WriteAllText(caminho, "tipo, dado\n");
        }
        
        // horario
        DateTime agora = DateTime.Now;
        string horarioFormatado = agora.ToString("HH:mm:ss");


        // Adiciona uma nova linha ao arquivo
        string novaLinha = $"horario,{horarioFormatado}\n";
        File.AppendAllText(caminho, novaLinha);

        Debug.Log($"CSV salvo em: {caminho}");
    }
    
    public void EscreverTexto(string texto)
    {
        string caminho = Application.persistentDataPath + "/dados.csv";

        // Adiciona uma nova linha ao arquivo
        string novaLinha = $"texto, {texto}\n";
        File.AppendAllText(caminho, novaLinha);

        Debug.Log($"CSV salvo em: {caminho}");
    }
}
