using UnityEngine;
using UnityEngine.UI;

public class MenuButtonController : MonoBehaviour
{
    public Button menuButton;
    public Button startButton;
    public Button quitButton;
    public Image statusBar;
    public GameObject controlButtons;
    public StartAnimation startAnimationScript;

    private void Start()
    {
        // Asigna las funciones a los botones
        menuButton.onClick.AddListener(OnMenuButtonClick);
        startButton.onClick.AddListener(OnStartButtonClick);
        quitButton.onClick.AddListener(OnQuitButtonClick);

        // Inicialmente, los botones "Start" y "Quit" est�n desactivados
        startButton.gameObject.SetActive(false);
        quitButton.gameObject.SetActive(false);
        controlButtons.gameObject.SetActive(false);
        statusBar.gameObject.SetActive(false);
    }

    private void OnMenuButtonClick()
    {
        // Oculta el bot�n "Menu"
        menuButton.gameObject.SetActive(false);

        // Activa los botones "Start" y "Quit"
        startButton.gameObject.SetActive(true);
        quitButton.gameObject.SetActive(true);
    }

    private void OnStartButtonClick()
    {
        // Llama al m�todo StartLoading() de StartAnimation para comenzar la carga
        startAnimationScript.StartLoading();
    }

    private void OnQuitButtonClick()
    {
        Debug.Log("Presionaste el bot�n 'Quit'");

        // Esto funciona en una compilaci�n ejecutable
        Application.Quit();
    }
}
