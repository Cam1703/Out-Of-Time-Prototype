using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Interfaz : MonoBehaviour
{
    public TextMeshProUGUI vidas;
    public TextMeshProUGUI balas;
    public TextMeshProUGUI botiquin;

    public GameObject pausePanel;      
    public Button resumeButton;      
    public Button resetButton;           
    public Button quitButton;     

    public Button pauseButton;      

    private bool isPaused = false;

    void Start()
    {

        pausePanel.SetActive(false);

    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.P))
        {
            Debug.Log("Probando llamada manual a PauseGame()");
            PauseGame();
        }
    }

    public void PauseGame()
    {
        Debug.Log("✅ PauseGame llamado correctamente");
        pausePanel.SetActive(true);        
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void ResumeGame()
    {
        Debug.Log("✅ ResumeGame llamado correctamente");
        Time.timeScale = 1f;
        pausePanel.SetActive(false);
        isPaused = false;
    }

    public void ResetGame()
    {
        Debug.Log("✅ ResetGame llamado correctamente");
        Time.timeScale = 1f;
        // Recarga la escena actual para resetear el nivel
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); 
        pausePanel.SetActive(false);
        isPaused = false;
    }

    public void QuitGame()
    {
        Debug.Log("✅ QuitGame llamado correctamente");
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
}
