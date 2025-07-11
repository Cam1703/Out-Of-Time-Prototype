using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void PlayGame()
    {

        SceneManager.LoadScene(2);

    }
    
    public void ExitGame()
    {
        Debug.Log("Saliendo del juego..."); 
        Application.Quit();
    }
    
}
