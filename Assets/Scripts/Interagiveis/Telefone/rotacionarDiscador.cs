using UnityEngine;
using UnityEngine.EventSystems;

public class rotacionarDiscador : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 30f;
    [SerializeField] private Transform pivotPoint; // Referência ao ponto de pivot
    
    void Update()
    {
        // Rotaciona em torno do ponto do pivot
        transform.RotateAround(pivotPoint.position, Vector3.forward, rotationSpeed * Time.deltaTime);
    }
}
