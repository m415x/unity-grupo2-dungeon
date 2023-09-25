using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SimpleScript : MonoBehaviour
{
    public Image progressBar;
    public float loadTime = 10f; // Tiempo en segundos para completar la carga

    private bool isLoading = false;

    private void Start()
    {
        // Ocultar la barra de progreso al inicio
        progressBar.fillAmount = 0f;
    }

    public void StartLoading()
    {
        if (!isLoading)
        {
            isLoading = true;
            StartCoroutine(LoadingProgress());
        }
    }

    private IEnumerator LoadingProgress()
    {
        float elapsedTime = 0f;

        while (elapsedTime < loadTime)
        {
            float progress = elapsedTime / loadTime;
            progressBar.fillAmount = progress;

            elapsedTime += Time.deltaTime;

            yield return null;
        }

        // Asegurarse de que la barra de progreso esté al 100% cuando se complete la carga
        progressBar.fillAmount = 1f;

        isLoading = false;
    }

}