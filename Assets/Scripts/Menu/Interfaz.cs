using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Interfaz : MonoBehaviour
{
    public TextMeshProUGUI vidas;
    public TextMeshProUGUI balas;
    public TextMeshProUGUI botiquin;

    // Update is called once per frame
    void Update()
    {
        vidas.text = "1"; // variable de vida
        balas.text = "2"; // variable de balas
        botiquin.text = "3"; // variable de botiquin
    }
}
