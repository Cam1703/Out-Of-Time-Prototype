using TMPro;
using UnityEngine;
using System.Collections;
public class MachineInteraction : MonoBehaviour
{
    [Header("Message to be displayed when interacting")]
    [TextArea(2, 4)]
    public string messageWin = "Text by default.";

    [Header("Message to be displayed when interacting")]
    [TextArea(2, 4)]
    public string messageFailed = "Text by default.";

    [Header("UI references")]
    public GameObject dialogPanel;
    public TextMeshProUGUI dialogText;
    public float speedText = 0.05f;

    private bool isPlayerClose = false;
    private bool isShowingDialog = false;
    private bool isHavingTheParts = false;
    private PlayerHealth _playerHealth;
    private int numberParts = 0;

    private void Start()
    {
        _playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
    }
    void Update()
    {

        if (isPlayerClose && Input.GetKeyDown(KeyCode.E) && !isShowingDialog)
        {
            if(isHavingTheParts) StartCoroutine(ShowingDialogWin());
            else StartCoroutine(ShowingDialogFailed());
        }
    }

    private IEnumerator ShowingDialogFailed()
    {
        isShowingDialog = true;
        dialogPanel.SetActive(true);
        dialogText.text = "";

        Debug.Log(messageFailed);

        foreach (char word in messageFailed)
        {
            dialogText.text += word;
            yield return new WaitForSeconds(speedText);
        }

        // Espera a que el jugador presione E para cerrar
        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.E));

        dialogPanel.SetActive(false);
        isShowingDialog = false;
    }
    private IEnumerator ShowingDialogWin()
    {
        isShowingDialog = true;
        dialogPanel.SetActive(true);
        dialogText.text = "";

        Debug.Log(messageWin);

        foreach (char word in messageWin)
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
            numberParts = _playerHealth.MachinePieces;
            if (numberParts == 4) isHavingTheParts = true;
            else isHavingTheParts = false;
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
