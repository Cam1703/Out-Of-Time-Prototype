using UnityEngine;

public class Bonfire : MonoBehaviour
{
    private bool isTouchingBonfire = false;
    private GameObject currentBonfire;

    private void OnCollisionEnter2D(UnityEngine.Collision2D collision)
    {
        // Verifica que la colisión esté ocurriendo con el jugador
        if (collision.gameObject.CompareTag("Player"))
        {
            isTouchingBonfire = true;
            currentBonfire = collision.gameObject;
            Debug.Log("Jugador ha tocado la fogata.");
           Debug.Log("Presiona E para interactuar");
            // Verifica si presiona E
            if (Input.GetKeyDown(KeyCode.E))
            {
                PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
                if (playerHealth != null)
                {
                    playerHealth.SaveProgress();
                    Debug.Log("Progreso guardado cerca de la fogata.");
                }
            }
        }
    }

    private void OnCollisionExit2D(UnityEngine.Collision2D collision)
    {
        if (collision.gameObject == currentBonfire)
        {
            isTouchingBonfire = false;
            currentBonfire = null;
            Debug.Log("Jugador ha dejado la fogata.");
        }
    }

    private void OnCollisionStay2D(UnityEngine.Collision2D collision)
    {
        // Esto asegura que se mantenga la interacción mientras el jugador esté tocando la fogata
        if (isTouchingBonfire && collision.gameObject.CompareTag("Player") && Input.GetKeyDown(KeyCode.E))
        {
            PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.SaveProgress();
                Debug.Log("Progreso guardado cerca de la fogata.");
            }
        }
    }

}
