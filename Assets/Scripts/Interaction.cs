using UnityEngine;
using TMPro;
using System.Collections;

public class Interaction : MonoBehaviour
{
    [Header("Message to be displayed when interacting")]
    [TextArea(2, 4)]
    public string message = "Text by default.";

    [Header("UI references")]
    public GameObject dialogPanel;
    public TextMeshProUGUI dialogText;
    public float speedText = 0.05f;

    private bool isPlayerClose = false;
    private bool isShowingDialog = false;

    void Update()
    {
        if (isPlayerClose && Input.GetKeyDown(KeyCode.E) && !isShowingDialog)
        {
            StartCoroutine(ShowingDialog());
        }
    }

    private IEnumerator ShowingDialog()
    {
        isShowingDialog = true;
        dialogPanel.SetActive(true);
        dialogText.text = "";

        Debug.Log(message);

        foreach (char word in message)
        {
            dialogText.text += word;
            yield return new WaitForSeconds(speedText);
        }

        // Espera a que el jugador presione E para cerrar
        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.E));

        dialogPanel.SetActive(false);
        isShowingDialog = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isPlayerClose = true;
            Debug.Log("Presiona E para interactuar");
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isPlayerClose = false;
        }
    }
}
