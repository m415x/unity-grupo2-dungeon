using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StartAnimation : MonoBehaviour
{
    public Image bgImage;
    public RawImage title;
    public Button startButton;
    public Button quitButton;
    public Image progressBar;
    public TMP_Text progressText;
    public GameObject characterToAppear;
    public Image statusBar;
    public GameObject controlButtons;

    // Tiempo en segundos para completar la carga
    public float loadTime = 5f;

    private bool isLoading = false;

    private void Start()
    {
        // Ocultar la barra de progreso y el texto al inicio
        progressBar.fillAmount = 0f;
        progressText.gameObject.SetActive(false);
        characterToAppear.SetActive(false);
    }

    public void StartLoading()
    {
        if (!isLoading)
        {
            startButton.gameObject.SetActive(false);
            quitButton.gameObject.SetActive(false);
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

            // Actualizar el texto del porcentaje
            progressText.gameObject.SetActive(true);
            int percentage = Mathf.RoundToInt(progress * 100);
            progressText.text = percentage.ToString() + "%";

            elapsedTime += Time.deltaTime;

            yield return null;
        }

        // Asegurarse de que la barra de progreso esté al 100% cuando se complete la carga
        progressBar.fillAmount = 1f;

        // Mostrar el porcentaje final como 100%
        progressText.text = "100%";

        // Esperar un breve momento antes de desactivar la barra y el texto
        yield return new WaitForSeconds(1f);

        // Desactivar la barra de progreso y el texto para ocultarlos
        progressBar.gameObject.SetActive(false);
        progressText.gameObject.SetActive(false);
        bgImage.gameObject.SetActive(false);
        title.gameObject.SetActive(false);

        // Activar el botón "Quit"
        quitButton.gameObject.SetActive(true);

        // Usar Invoke para activar el GameObject después de 1 segundo
        Invoke("ShowCharacter", 1f);

        isLoading = false;

        // Aquí puedes mostrar el juego o realizar cualquier otra acción necesaria
    }

    private void ShowCharacter()
    {
        // Activar el GameObject que deseas que aparezca
        characterToAppear.SetActive(true);
        controlButtons.gameObject.SetActive(true);
        statusBar.gameObject.SetActive(true);
    }
}