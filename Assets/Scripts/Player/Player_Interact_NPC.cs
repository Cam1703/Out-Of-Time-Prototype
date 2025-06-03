using UnityEngine;

public class Player_Interact_NPC : MonoBehaviour
{
    private bool isTouchingNPC = false;
    private GameObject currentNPC; // para guardar a qué NPC tocas (por si tienes varios)

    void Update()
    {
        if (isTouchingNPC && Input.GetKeyDown(KeyCode.E))
        {
            Interact();
        }
    }

    private void Interact()
    {
        Debug.Log("¡Hablaste con el NPC!");
        // Aquí podrías hacer cosas como abrir diálogos, etc.
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("NPC"))
        {
            isTouchingNPC = true;
            currentNPC = collision.gameObject;
            Debug.Log("Presiona E para hablar");
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject == currentNPC)
        {
            isTouchingNPC = false;
            currentNPC = null;
        }
    }
}
