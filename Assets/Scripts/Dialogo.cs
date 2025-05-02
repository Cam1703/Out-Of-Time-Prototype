using UnityEngine;
using TMPro;
using System.Collections;

public class ObjetoInteractuable : MonoBehaviour
{
    [Header("Mensaje que se mostrará al interactuar")]
    [TextArea(2, 4)]
    public string mensaje = "Texto por defecto del objeto.";

    [Header("Referencias de UI")]
    public GameObject panelDialogo;
    public TextMeshProUGUI textoDialogo;
    public float velocidadTexto = 0.05f;

    private bool jugadorCerca = false;
    private bool mostrandoDialogo = false;

    void Update()
    {
        if (jugadorCerca && Input.GetKeyDown(KeyCode.E) && !mostrandoDialogo)
        {
            StartCoroutine(MostrarDialogo());
        }
    }

    private IEnumerator MostrarDialogo()
    {
        mostrandoDialogo = true;
        panelDialogo.SetActive(true);
        textoDialogo.text = "";

        foreach (char letra in mensaje)
        {
            textoDialogo.text += letra;
            yield return new WaitForSeconds(velocidadTexto);
        }

        // Espera a que el jugador presione E para cerrar
        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.E));

        panelDialogo.SetActive(false);
        mostrandoDialogo = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            jugadorCerca = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            jugadorCerca = false;
        }
    }
}
