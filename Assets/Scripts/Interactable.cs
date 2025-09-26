using UnityEngine;

public class Interactable : MonoBehaviour
{
    public virtual void Interact(PlayerMovement playerMovement)
    {
        Debug.Log("Interacted with " + gameObject.name);
    }
}