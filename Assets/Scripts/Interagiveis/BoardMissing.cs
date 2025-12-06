using UnityEngine;

public class BoardMissing : MonoBehaviour
{
    public GameObject placaMostrar;
    void Start()
    {
        placaMostrar.SetActive(false);
    }

    bool isMouseOver = false;

    void Update()
    {
        placaMostrar.SetActive(isMouseOver);
    }

    void OnMouseEnter()
    {
        isMouseOver = true;
    }

    void OnMouseExit()
    {
        isMouseOver = false;
    }

    public void Sair()
    {
        isMouseOver = false;
    }

}
