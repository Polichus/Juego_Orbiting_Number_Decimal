using UnityEngine;
using TMPro;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class BolaCentral : MonoBehaviour
{
    private TextMeshProUGUI textoBolaCentral;

    void Start()
    {
        textoBolaCentral = GetComponentInChildren<TextMeshProUGUI>();

        if (textoBolaCentral == null)
        {
            Debug.LogError("Error: No se encontr� TextMeshProUGUI en el objeto central " + gameObject.name);
            return;
        }

        StartCoroutine(EsperarYGenerarSuma());
    }

    IEnumerator EsperarYGenerarSuma()
    {
        while (Bola.ObtenerNumerosGenerados().Count < 10) // Cambia 10 por la cantidad total de bolas en tu escena
        {
            yield return null; // Espera un frame
        }

        GenerarOperacionQueCoincida();
    }

    void GenerarOperacionQueCoincida()
    {
        HashSet<float> numeros = Bola.ObtenerNumerosGenerados();

        if (numeros.Count < 1)
        {
            Debug.LogError("No hay suficientes n�meros generados en las bolas circundantes.");
            textoBolaCentral.text = "Error";
            return;
        }

        List<float> listaNumeros = numeros.ToList();

        // Elegir un n�mero objetivo de los generados
        float numeroObjetivo = listaNumeros[Random.Range(0, listaNumeros.Count)];

        // Generar dos n�meros aleatorios que sumen el n�mero objetivo
        float numero1 = Random.Range(0f, numeroObjetivo); // Primer n�mero entre 0 y el n�mero objetivo
        float numero2 = numeroObjetivo - numero1; // Segundo n�mero que completa la suma

        // Redondear los n�meros a dos decimales
        numero1 = Mathf.Round(numero1 * 100f) / 100f;
        numero2 = Mathf.Round(numero2 * 100f) / 100f;

      

        // Mostrar solo los dos n�meros sumados, sin el igual ni el resultado
        textoBolaCentral.text = $"{numero1.ToString("F2")} + {numero2.ToString("F2")}";
        
    }
}



