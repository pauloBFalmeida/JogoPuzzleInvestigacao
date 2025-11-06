using UnityEngine;
using UnityEngine.EventSystems;

public class rotacionarDiscador : MonoBehaviour
{

    [Header("Configurações")]
    [SerializeField] private float returnSpeed = 120f;
    [SerializeField] private float rotationSmoothness = 8f;
    
    private bool isDragging = false;
    private float initialAngleOffset;
    private Quaternion  initialRotation;

    void Start()
    {
        initialRotation = transform.rotation;
    }

    void Update()
    {
        if (isDragging)
        {
            // Segue exatamente o angulo do mouse
            FollowMouseAngle();
        }
        else
        {
            // Retorna suavemente para a rotacao inicial
            transform.rotation = Quaternion.Lerp(transform.rotation, initialRotation, Time.deltaTime * returnSpeed);
        }
    }

    void OnMouseDown()
    {
        StartDragging();
    }

    void OnMouseUp()
    {
        StopDragging();
    }

    private void StartDragging()
    {
        isDragging = true;
        
        // Calcula o offset inicial entre o angulo atual e o angulo do mouse
        Vector3 mousePosition = GetMouseWorldPosition();
        float currentAngle = transform.eulerAngles.z;
        float mouseAngle = GetAngleToMouse(mousePosition);
        initialAngleOffset = currentAngle - mouseAngle;
    }

    private void StopDragging()
    {
        isDragging = false;
    }

    private void FollowMouseAngle()
    {
        // pega o angulo que tem que rodar
        Vector3 mousePosition = GetMouseWorldPosition();
        float targetAngle = GetAngleToMouse(mousePosition) + initialAngleOffset;

        // Aplica a rotacao para seguir exatamente o mouse
        transform.rotation = Quaternion.Euler(0, 0, targetAngle);
        
    }

    private float GetAngleToMouse(Vector3 mousePosition)
    {
        // Calcula a direcao do centro ate o mouse
        Vector3 direction = mousePosition - transform.position;

        // Calcula o angulo em graus (-180 a 180)
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        
        return angle;
    }

    private Vector3 GetMouseWorldPosition()
    {
        Vector3 mousePos = Input.mousePosition;
        
        // Para objetos no mundo 2D
        mousePos.z = -Camera.main.transform.position.z;
        return Camera.main.ScreenToWorldPoint(mousePos);
    }
}
