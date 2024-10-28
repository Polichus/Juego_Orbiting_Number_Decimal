// Bola.cs
using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class Bola : MonoBehaviour
{
    private static HashSet<float> numerosGenerados = new HashSet<float>();

    private TextMeshProUGUI textoBola;

    void Start()
    {
        textoBola = GetComponentInChildren<TextMeshProUGUI>();

        if (textoBola == null)
        {
            Debug.LogError("Error: No se encontró TextMeshProUGUI en el objeto " + gameObject.name);
            return;
        }

        float numeroAleatorio = GenerarNumeroAleatorio();
        textoBola.text = numeroAleatorio.ToString("F2");

        // Asegurarnos de que el número generado sea único
        if (numerosGenerados.Add(numeroAleatorio) == false)
        {
            Debug.LogWarning("Número duplicado: " + numeroAleatorio);
        }
    }

    public static HashSet<float> ObtenerNumerosGenerados()
    {
        return numerosGenerados;
    }

    private float GenerarNumeroAleatorio()
    {
        return Mathf.Round(Random.Range(0f, 99f) * 100f) / 100f;
    }
}