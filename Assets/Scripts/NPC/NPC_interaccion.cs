using UnityEngine;

public class NPC_interaccion : MonoBehaviour
{
    private bool isPlayerColliding = false;

    void Update()
    {
        if (isPlayerColliding && Input.GetKeyDown(KeyCode.E))
        {
            Interact();
        }
    }

    private void Interact()
    {
        Debug.Log("¡Hola, soy el NPC!");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isPlayerColliding = true;
            Debug.Log("Presiona E para interactuar");
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isPlayerColliding = false;
        }
    }
}
