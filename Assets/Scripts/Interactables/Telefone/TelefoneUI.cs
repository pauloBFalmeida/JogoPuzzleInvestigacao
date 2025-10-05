using UnityEngine;

public class TelefoneUI : UIInterface
{
    void Start()
    {
        StartUI();
    }

    public void OnNumberPressed(int number)
    {
        Debug.Log("Dialed number: " + number);
    }
}
