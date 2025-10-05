using UnityEngine;

public class TelefoneInteractable : Interactable
{
    public TelefoneUI TelefoneUI;
    public override void Interact()
    {
        base.Interact();
        TelefoneUI.Show();
    }

}
