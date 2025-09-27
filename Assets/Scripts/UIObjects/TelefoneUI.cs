using UnityEngine;

public class TelefoneUI : MonoBehaviour
{
    void Start()
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

    public void OnNumberPressed(int number)
    {
        Debug.Log("Dialed number: " + number);
    }

    public void Sair()
    {
        Hide();
    }
    
}
