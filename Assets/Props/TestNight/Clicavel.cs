using UnityEngine;

public class Clicavel : MonoBehaviour
{
    public GameObject itemMostrar;

    public GameObject hitboxSairUI;

    void OnMouseDown()
    {
        GameManagerTestNight.Instance.EsconderItens(itemMostrar);
        itemMostrar.SetActive(true);
    }
}
