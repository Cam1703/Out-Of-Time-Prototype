using UnityEngine;

public class NoDestruirAlCambiarEscena : MonoBehaviour
{
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}