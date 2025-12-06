using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class livroPiano : MonoBehaviour
{
    public teclado tecladinho;
    public TMPro.TextMeshPro textoSimbolos;
    
    private List<string> simbolosNotInUse = new();

    void Start()
    {
        string simbFim      = tecladinho.simbolosTeclas[tecladinho.sequenciaCorreta[0]];
        string simbGrave    = tecladinho.simbolosTeclas[tecladinho.sequenciaCorreta[1]];
        string simbLuz      = tecladinho.simbolosTeclas[tecladinho.sequenciaCorreta[3]];
        string simbSilencio = tecladinho.simbolosTeclas[tecladinho.sequenciaCorreta[4]];

        // ajusta as que nao estao em uso
        AjustarSimboloNotInUse();

        textoSimbolos.text = "";
        textoSimbolos.text += PopRandomSimboloNotInUse() + '\n';
        textoSimbolos.text += PopRandomSimboloNotInUse() + '\n';
        textoSimbolos.text += simbGrave + '\n';
        textoSimbolos.text += simbLuz + '\n';
        textoSimbolos.text += PopRandomSimboloNotInUse() + '\n';
        textoSimbolos.text += simbSilencio + '\n';
        textoSimbolos.text += PopRandomSimboloNotInUse() + '\n';
        textoSimbolos.text += simbFim + '\n';

    }

    private string PopRandomSimboloNotInUse()
    {
        int id = Random.Range(0, simbolosNotInUse.Count);
        string simbolo = simbolosNotInUse[id];
        simbolosNotInUse.RemoveAt(id);
        return simbolo;
    }
    private void AjustarSimboloNotInUse()
    {
        for (int i=0; i<tecladinho.simbolosTeclas.Count; i++)
        {
            // nao faz parte da sequencia correta
            if (!tecladinho.sequenciaCorreta.Contains(i))
            {
                // add simbolo
                simbolosNotInUse.Add(tecladinho.simbolosTeclas[i]);
            }
        }
    }
}
