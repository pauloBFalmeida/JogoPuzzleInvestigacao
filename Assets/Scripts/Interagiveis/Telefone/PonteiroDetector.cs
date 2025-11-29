using UnityEngine;

public class PonteiroDetector : MonoBehaviour
{
    public RotacionarDiscador rotacionarDiscador;

    private int digitoDetectado = -1;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("DiscadorNumero"))
        {
            var digito = other.GetComponent<DigitoCollider>();
            if (digito != null)
            {
                digitoDetectado = digito.valor;
                rotacionarDiscador.PassouDigito(digitoDetectado);
            }
        }
        else if (other.CompareTag("DiscadorLimite"))
        {
            rotacionarDiscador.LimitRotation();
        }
    }
}
