using UnityEngine;

public class UIInteracao : MonoBehaviour
{
    public ObjetoInteracao objetoInteracaoRef;
    
    public void StartUI()
    {
        // deixa invisivel
        gameObject.SetActive(false);
    }

    public void Sair()
    {
        Hide();
    }

    public void Show()
    {
        GameManager.Instance.CameraPararCursor();
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        GameManager.Instance.CameraSeguirCursor();
        gameObject.SetActive(false);
    }
}
