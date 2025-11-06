using System;
using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public struct DigitoAngulo
{
    public int digito;
    public float angulo;
}
public class RotacionarDiscador : MonoBehaviour
{

    [Header("Configurações")]
    [SerializeField] private float returnSpeed = 2f;
    [SerializeField] private float limAngle = -32f; // limite maximo que pode puxar
    [SerializeField] private float rotationSmoothness = 8f;
    [SerializeField] private List<DigitoAngulo> angulosReconhecerDigitos = new();
    [SerializeField] public TextoDiscador TextoNumero;

    private bool isDragging = false;
    private float initialAngleOffset;
    private Quaternion initialRotation;
    private bool jaPassouMetade = false;

    private float lastTargetAngle = 0f;
    private int lastDigito = -1;

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
            // mostar o digito atual
            ReconhecerDigito();
        }
        else
        {
            // Retorna suavemente para a rotacao inicial
            ReturnClockwiseToInitial();
        }
    }

    void OnMouseDown()
    {
        StartDragging();
        jaPassouMetade = false;
    }

    void OnMouseUp()
    {
        PegarDigito();
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

        if (targetAngle > 360) { targetAngle -= 360f; }
        if (targetAngle < 0) { targetAngle += 360f; }

        if (targetAngle < 150 && targetAngle > 100) { jaPassouMetade = true; }

        if (jaPassouMetade)
        {
            if (targetAngle < limAngle || targetAngle > 270)
            {
                targetAngle = limAngle;
            }
        }
        else
        {
            if (targetAngle < 90)
            {
                targetAngle = 0f;
            }
        }

        // if (targetAngle < limAngle)
        // {
        //     // vindo inicio (posicao inicial forcada para baixo) 
        //     // if (targetAngle < limAngle/2)
        //     // {
        //     //     targetAngle = 0f;
        //     //     Debug.Log("vindo inicio ");
        //     // } else
        //     // {
        //     //     targetAngle = limAngle;
        //     //     Debug.Log("voltando ");
        //     // }

        // }

        transform.rotation = Quaternion.Euler(0, 0, targetAngle);

        lastTargetAngle = targetAngle;
    }

    private float GetAngleToMouse(Vector3 mousePosition)
    {
        // Calcula a direcao do centro ate o mouse
        Vector3 direction = mousePosition - transform.position;

        // Calcula o angulo em graus (-180 a 180)
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        if (angle > 0)
        {
            angle -= 360f; // Converte para -360 a 0
        }

        return angle;
    }

    private Vector3 GetMouseWorldPosition()
    {
        Vector3 mousePos = Input.mousePosition;

        // Para objetos no mundo 2D
        mousePos.z = -Camera.main.transform.position.z;
        return Camera.main.ScreenToWorldPoint(mousePos);
    }

    private void ReturnClockwiseToInitial()
    {
        float currentAngle = transform.eulerAngles.z;
        // Calcula o ângulo alvo
        float targetAngle = initialRotation.eulerAngles.z;

        // Se o ângulo atual for maior que o alvo, adiciona 360 ao alvo
        // para forçar o caminho anti-horário
        if (currentAngle > targetAngle)
        {
            targetAngle += 360f;
        }

        // Interpola o ângulo
        currentAngle = Mathf.Lerp(currentAngle, targetAngle, Time.deltaTime * returnSpeed);

        // Normaliza o ângulo para evitar valores muito grandes
        if (currentAngle >= 360f) currentAngle -= 360f;

        // Aplica a rotação
        transform.rotation = Quaternion.Euler(0, 0, currentAngle);
    }

    private void PegarDigito()
    {
        TextoNumero.UpdateNumero();
    }

    public void ReconhecerDigito()
    {
        if (lastTargetAngle > 350 || lastTargetAngle < limAngle -1) { return; };

        // percorre a lista, enquanto o angulo do disco for maior que o item da lista continue pegando os digitos
        // quando for menor, quer dizer que ja nao mais se aplica a aquele digito, entao pare e retorne o ultimo
        int melhorDigito = -1;
        foreach (DigitoAngulo item in angulosReconhecerDigitos)
        {

            if (item.angulo > lastTargetAngle)
            {
                melhorDigito = item.digito;
            }
            else
            {
                break;
            }
        }

        lastDigito = melhorDigito;

        TextoNumero.UpdateDigitoTextoNumero(melhorDigito);
    }
}
