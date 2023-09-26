using UnityEngine;
using UnityEngine.UI;
using Button = UnityEngine.UI.Button;

public class GamePlayUIManager : MonoBehaviour
{
    public Button quitButton;
    public Image statusBar;
    public GameObject controlButtons;
    public GameObject characterToAppear;

    private void OnEnable()
    {
        // Asignar función de botón "Quit"
        quitButton.onClick.AddListener(delegate 
        {
            Debug.Log("Presionaste el botón 'Quit'");
            Application.Quit();
        });

        // Inicialmente, los botones "Start", "Quit", Controles y personaje están desactivados
        quitButton.gameObject.SetActive(true);
        controlButtons.gameObject.SetActive(true);
        statusBar.gameObject.SetActive(true);
        characterToAppear.SetActive(false);
    }

    private void Start()
    {
        // Activar el botón "Quit"
        //quitButton.gameObject.SetActive(true);

        // Usar Invoke para activar el GameObject después de 1 segundo
        Invoke("ShowCharacter", 1f);
    }

    private void ShowCharacter()
    {
        // Activar el GameObject que deseas que aparezca
        characterToAppear.SetActive(true);

    }
}