// Bola.cs
using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class Bola : MonoBehaviour
{
    private static HashSet<float> numerosGenerados = new HashSet<float>();
    public Sprite[] spritesNumerosPossibles = new Sprite[3];
    private TextMeshProUGUI textoBola;

    void Start()
    {
        // Verificar que spritesNumerosPossibles tiene al menos un sprite
        /*if (spritesNumerosPossibles == null || spritesNumerosPossibles.Length == 0)
        {
            Debug.LogError("El array 'spritesNumerosPossibles' est� vac�o. Asigna sprites en el Inspector.");
            return;
        }*/

        // Generar un �ndice aleatorio dentro del rango de sprites disponibles
        System.Random aleatorio = new System.Random();
        int colorBola = aleatorio.Next(0, spritesNumerosPossibles.Length);
        GetComponent<SpriteRenderer>().sprite = spritesNumerosPossibles[colorBola];

        // Intentar obtener el componente TextMeshProUGUI en los hijos
        /*textoBola = GetComponentInChildren<TextMeshProUGUI>();
        if (textoBola == null)
        {
            Debug.LogError("No se encontr� el componente TextMeshProUGUI en los hijos del objeto. Aseg�rate de que el objeto tenga un hijo con TextMeshProUGUI.");
            return;  // Termina la ejecuci�n si falta el componente
        }*/
        

        // Generar un n�mero aleatorio �nico y mostrarlo en el TextMeshProUGUI
        float numeroAleatorio = GenerarNumeroAleatorio();
        //textoBola.text = numeroAleatorio.ToString("F2");

        // Asegurarse de que el n�mero generado sea �nico
        if (!numerosGenerados.Add(numeroAleatorio))
        {
            Debug.LogWarning("N�mero duplicado: " + numeroAleatorio);
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

