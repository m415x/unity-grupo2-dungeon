using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Button = UnityEngine.UI.Button;

public class MainMenuUIManager : MonoBehaviour
{
    public Image bgImage;
    public RawImage title;
    public Button menuButton;
    public Button startButton;
    public Button quitButton;
    public Image progressBar;
    public TMP_Text progressText;

    // Tiempo en segundos para completar la carga
    public float loadTime = 5f;

    private bool isLoading = false;

    private void OnEnable()
    {
        // Asigna las funciones a los botones
        menuButton.onClick.AddListener(delegate { OnButtonClick(menuButton); });
        startButton.onClick.AddListener(delegate { OnButtonClick(startButton); });
        quitButton.onClick.AddListener(delegate { OnButtonClick(quitButton); });

        // Ocultar los botones "Start", "Quit"
        startButton.gameObject.SetActive(false);
        quitButton.gameObject.SetActive(false);

        // Ocultar la barra de progreso y el texto al inicio
        progressBar.fillAmount = 0f;
        progressText.gameObject.SetActive(false);
    }

    private void OnButtonClick(Button buttonPressed)
    {
        if (buttonPressed.name == "MenuButton")
        {
            // Oculta el botón "Menu"
            menuButton.gameObject.SetActive(false);

            // Activa los botones "Start" y "Quit"
            startButton.gameObject.SetActive(true);
            quitButton.gameObject.SetActive(true);
        }

        if (buttonPressed.name == "StartButton")
        {
            // Llama al método StartLoading() de StartAnimation para comenzar la carga
            StartLoading();
        }

        if (buttonPressed.name == "QuitButton")
        {
            Debug.Log("Presionaste el botón 'Quit'");

            // Esto funciona en una compilación ejecutable
            Application.Quit();
        }
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

        // Cargar escena 1
        SceneManager.LoadScene(1);

        isLoading = false;
    }
}