using UnityEngine;

public class TelefoneInteractable : Interactable
{
    public TelefoneUI TelefoneUI;
    public override void Interact(PlayerMovement playerMovement)
    {
        base.Interact(playerMovement);
        playerMovement.ToggleLockCursor(false);
        TelefoneUI.Show();
    }

}
