using System;
using UnityEngine;

public class ObjetoInteracao : MonoBehaviour
{
    [Header("Prefab da UI")]
    public GameObject uiPrefab;

    [Header("Canvas")]
    public Transform canvasTransform;

    protected GameObject uiInstancia;

    void Start()
    {
        CriarUI();
    }

    public virtual void Interact()
    {
        Debug.Log("Interagiu com " + gameObject.name);
    }

    public virtual void receberFeedback(string feedback) 
    {
        Debug.Log("receberFeedback " + feedback);
    }
    
    public void CriarUI()
    {
        if (uiPrefab == null || canvasTransform == null) { return; }

        // Instancia a UI como filha do Canvas
        uiInstancia = Instantiate(uiPrefab, canvasTransform);

        // Passa esse ObjetoInteracao de ref para a UIInteracao
        uiInstancia.TryGetComponent<UIInteracao>(out UIInteracao uiInteracao);
        if (uiInteracao != null)
        {
            uiInteracao.objetoInteracaoRef = this;
        }
    }
}