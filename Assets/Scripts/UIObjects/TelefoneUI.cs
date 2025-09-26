using UnityEngine;

public class TelefoneUI : MonoBehaviour
{
    void Start()
    {
        Hide();
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    public void OnNumberPressed(int number)
    {
        Debug.Log("Dialed number: " + number);
    }

}
