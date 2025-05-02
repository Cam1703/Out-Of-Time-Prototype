using UnityEngine;
using TMPro;
using System.Collections;

public class Dialogo_NPC : MonoBehaviour
{
    public GameObject panelDialogo;
    public TextMeshProUGUI textoDialogo;
    public string mensaje = "¡Hola, soy un NPC!";
    public float velocidadTexto = 0.05f;

    private bool estaInteractuando = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (!estaInteractuando)
            {
                StartCoroutine(MostrarDialogo());
            }
            else
            {
                textoDialogo.text = mensaje; // Completa el texto si presionas E mientras escribe
            }
        }
    }

    IEnumerator MostrarDialogo()
    {
        estaInteractuando = true;
        panelDialogo.SetActive(true);
        textoDialogo.text = "";

        foreach (char letra in mensaje.ToCharArray())
        {
            textoDialogo.text += letra;
            yield return new WaitForSeconds(velocidadTexto);
        }

        // Opcional: espera otra tecla para cerrar
        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.E));
        panelDialogo.SetActive(false);
        estaInteractuando = false;
    }
}
