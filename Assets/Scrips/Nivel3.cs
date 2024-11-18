using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro; // Necesario para TextMeshProUGUI

public class Nivel3 : MonoBehaviour
{
    // Variable para contar los segundos
    private float seconds = 0;

    // Referencia a un TextMeshProUGUI para mostrar el tiempo en pantalla
    public TextMeshProUGUI timeText;

    void Start()
    {
        // Verifica que el campo timeText esté asignado
        if (timeText == null)
        {
            Debug.LogError("No se asignó un Text para mostrar el tiempo.");
        }
    }

    void Update()
    {
        // Incrementa los segundos usando deltaTime
        seconds += Time.deltaTime;

        // Actualiza el texto en pantalla con el tiempo
        if (timeText != null)
        {
            timeText.text = seconds.ToString("F2");
        }
    }
}
