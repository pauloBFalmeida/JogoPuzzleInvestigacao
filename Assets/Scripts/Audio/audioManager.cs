using System.Collections;
using UnityEngine;

public class audioManager : MonoBehaviour
{
    [Header("Áudios possíveis")]
    [SerializeField] private AudioClip[] clips;   // arraste os clips aqui

    [Header("Intervalo entre sons")]
    [SerializeField] private float tempoMin = 20f;
    [SerializeField] private float tempoMax = 50f;

    private AudioSource source;

    private void Awake()
    {
        source = gameObject.AddComponent<AudioSource>();
    }

    private void Start()
    {
        StartCoroutine(LoopSomAmbiente());
    }

    private IEnumerator LoopSomAmbiente()
    {
        // espera um pouco no começo
        yield return new WaitForSeconds(20f);

        while (true)
        {
            // sorteia clip
            AudioClip clipSorteado = clips[Random.Range(0, clips.Length)];

            // toca
            source.clip = clipSorteado;
            source.Play();

            // espera o clip acabar
            yield return new WaitForSeconds(clipSorteado.length);

            // espera intervalo aleatorio ate o proximo
            float intervalo = Random.Range(tempoMin, tempoMax);
            yield return new WaitForSeconds(intervalo);
        }
    }
}