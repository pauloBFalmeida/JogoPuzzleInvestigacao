using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Lista de Nomes")]
public class ListaNomesSO : ScriptableObject
{
    [Header("Nomes")]
    public List<string> nomes = new();
}
