using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    public float rayDistance = 100f;
    public LayerMask layerInteracao;


    void Update()
    {
        if (Input.GetMouseButtonDown(0) && GameManager.Instance.IsCameraSeguindoCursor()) // Botao Esq Mouse
        {
            CastRay();
        }
    }

    void CastRay()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, rayDistance, layerInteracao))
        {
            Debug.Log("Hit: " + hit.collider.name);

            // Try to find an Interactable component on the object
            Interactable interactable = hit.collider.GetComponent<Interactable>();
            if (interactable != null)
            {
                interactable.Interact();
            }
        }
    }
}