using System;
using UnityEngine;
using TMPro;


public class RotacionarDiscador : MonoBehaviour
{

    [Header("Configurações")]
     private float returnSpeed = 2f;
    public TextoDiscador TextoNumero;
    public TextMeshPro TextoAjuda;

    private bool isDragging = false;
    private float initialAngleOffset;
    private Quaternion initialRotation;

    private int ultimoDigitoDiscado = -1;
    private bool chegouLimiteRotacao = false;
    private bool passouPeloDigito9 = false;
    public ListaTelefonicaSO listaTelefonica;
    private string numeroDiscado = "";

    void Start()
    {
        initialRotation = transform.rotation;

        TextoAjuda.text = "Ajuda:\n" + listaTelefonica.GetNumeroAjuda();
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
            ReturnClockwiseToInitial();
        }
    }

    void OnMouseDown()
    {
        StartDragging();
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
        float currentRotation = transform.eulerAngles.z;
        float mouseAngle = GetAngleToMouse(mousePosition);
        initialAngleOffset = currentRotation - mouseAngle;
    }

    private void StopDragging()
    {
        isDragging = false;
        chegouLimiteRotacao = false;
        passouPeloDigito9 = false;
        ultimoDigitoDiscado = -1;
    }

    private void FollowMouseAngle()
    {
        if (chegouLimiteRotacao) return;

        // pega o angulo que tem que rodar
        Vector3 mousePosition = GetMouseWorldPosition();
        float targetAngle = GetAngleToMouse(mousePosition) + initialAngleOffset;
        // converte para [0.0, 360.0]
        if (targetAngle > 360) { targetAngle -= 360f; }
        if (targetAngle < 0) { targetAngle += 360f; }

        // aplica a rotacao
        transform.rotation = Quaternion.Euler(0, 0, targetAngle);
    }

    public void LimitRotation()
    {
        chegouLimiteRotacao = true;
    }

    public void PassouDigito(int digito)
    {
        // se passou pelo 0 antes de passar pelo 9, quer dizer que veio do lado oposto
        if (digito == 0 && !passouPeloDigito9)
        {
            ResetRotation();
            return;
        }
        // marca que passou pelo digito 9 
        if (digito == 9) passouPeloDigito9 = true;

        ultimoDigitoDiscado = digito;
        // se estiver segurando mouse -> atualiza o mostrador 
        if (isDragging)
        {
            TextoNumero.UpdateDigitoTextoNumero(digito);
        }
    }
    /*
        Retorna o angulo de [0.0, 360.0] do mouse com o centro do objeto
        Seguindo o padrao da circulo trigonometrico: 0 a direita, 90 a cima, 180 a esquerda e 270 em baixo
    */
    private float GetAngleToMouse(Vector3 mousePosition)
    {
        // Calcula a direcao do centro ate o mouse
        Vector3 direction = mousePosition - transform.position;

        // Calcula o angulo em graus (-180 a 180)
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        // converte de [-180.0, 180.0] -> [0.0, 360.0] 
        angle += 360f;
        if (angle > 360) { angle -= 360; }

        return angle;
    }

    private Vector3 GetMouseWorldPosition()
    {
        Vector3 mousePos = Input.mousePosition;

        // Para objetos no mundo 2D
        mousePos.z = -Camera.main.transform.position.z;
        return Camera.main.ScreenToWorldPoint(mousePos);
    }

    private void ResetRotation()
    {
        transform.rotation = Quaternion.Euler(0, 0, 0);
    }

    private void ReturnClockwiseToInitial()
    {
        float currentAngle = transform.eulerAngles.z;

        // se for muito pequeno apena zera a rotacao
        if (    Math.Abs(currentAngle) < 1 ||                                       // proximo de +- 0
                (Math.Abs(currentAngle) < 361 && Math.Abs(currentAngle) > 359))     // proximo de +- 360
            {
            ResetRotation();
            return;
        }

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
        // ignora digitos que nao sao [0, 9]
        if (ultimoDigitoDiscado < 0 || ultimoDigitoDiscado > 9) return;

        numeroDiscado = numeroDiscado + ultimoDigitoDiscado.ToString();

        TextoNumero.UpdateNumero(numeroDiscado);

        if (listaTelefonica.IsNumeroValido(numeroDiscado))
        {
            string nome = listaTelefonica.GetNomeParaNumero(numeroDiscado);

            GameManagerTestNight.Instance.FazerLigacao(nome);
        }
    }
    
    public void SairDiscagem()
    {
        // limpa os valores
        TextoNumero.UpdateNumero("");
        numeroDiscado = "";
        ultimoDigitoDiscado = -1;
    }
}
