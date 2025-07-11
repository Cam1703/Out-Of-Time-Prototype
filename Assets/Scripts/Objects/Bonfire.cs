using TMPro;
using UnityEngine;
using System.Collections;

public class Bonfire : MonoBehaviour
{
    
    [Header("Message to be displayed when interacting")]
    [TextArea(2, 4)]
    public string messageSaved = "Text by default.";

    [Header("UI references")]
    public GameObject dialogPanel;
    public TextMeshProUGUI dialogText;
    public float speedText = 0.05f;
    private bool isTouchingBonfire = false;
    private GameObject currentBonfire;
    private IEnumerator ShowingDialogSave()
    {
        dialogPanel.SetActive(true);
        dialogText.text = "";

        Debug.Log(messageSaved);

        foreach (char word in messageSaved)
        {
            dialogText.text += word;
            yield return new WaitForSeconds(speedText);
        }

        // Espera a que el jugador presione E para cerrar
        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.E));

        dialogPanel.SetActive(false);
    }

    private void OnCollisionEnter2D(UnityEngine.Collision2D collision)
    {
        // Verifica que la colisi�n est� ocurriendo con el jugador
        if (collision.gameObject.CompareTag("Player"))
        {
            isTouchingBonfire = true;
            currentBonfire = collision.gameObject;
            //Debug.Log("Jugador ha tocado la fogata.");
           Debug.Log("Presiona E para interactuar");
            // Verifica si presiona E
            if (Input.GetKeyDown(KeyCode.E))
            {
                PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
                if (playerHealth != null)
                {
                    playerHealth.SaveProgress();
                    StartCoroutine(ShowingDialogSave());
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
            //Debug.Log("Jugador ha dejado la fogata.");
        }
    }

    private void OnCollisionStay2D(UnityEngine.Collision2D collision)
    {
        // Esto      asegura que se mantenga la interacci�n mientras el jugador est� tocando la fogata
        if (isTouchingBonfire && collision.gameObject.CompareTag("Player") && Input.GetKeyDown(KeyCode.E))
        {
            PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.SaveProgress();
                StartCoroutine(ShowingDialogSave());
                Debug.Log("Progreso guardado cerca de la fogata.");
            }
        }
    }

}
