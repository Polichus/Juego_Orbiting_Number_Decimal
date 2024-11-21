using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Nivel2 : MonoBehaviour
{
    // Variable para contar los segundos
    private float seconds = 0;

    // Referencia a un TextMeshProUGUI para mostrar el tiempo en pantalla
    public TextMeshProUGUI timeText;

    void Start()
    {
        // Verifica que el campo timeText est� asignado
        if (timeText == null)
        {
            Debug.LogError("No se asign� un Text para mostrar el tiempo.");
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
