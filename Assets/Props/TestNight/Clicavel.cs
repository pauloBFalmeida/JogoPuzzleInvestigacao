using UnityEngine;

public class Clicavel : MonoBehaviour
{
    public GameObject itemMostrar;

    void OnMouseDown()
    {
        GameManagerTestNight.Instance.EsconderItens(itemMostrar);
        itemMostrar.SetActive(true);
        
        if (itemMostrar.TryGetComponent<teclado>(out teclado tecladinho)) {
            tecladinho.Mostrar();
        }
    }
}
