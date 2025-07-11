using UnityEngine;
using UnityEngine.SceneManagement;

public class CambioDeEscena2D : MonoBehaviour
{
    public string nombreEscenaDestino;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            DontDestroyOnLoad(other.gameObject);
            SceneManager.LoadScene(3);
        }
    }
}