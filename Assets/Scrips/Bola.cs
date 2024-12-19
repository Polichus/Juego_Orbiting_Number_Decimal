using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class Bola : MonoBehaviour
{
    public static HashSet<float> numerosGenerados = new HashSet<float>();
    public Sprite[] spritesNumerosPossibles;
    private TextMeshProUGUI textoBola;

    void Start()
    {
        // Verificar sprites disponibles
        if (spritesNumerosPossibles == null || spritesNumerosPossibles.Length == 0)
        {
            Debug.LogError("El array 'spritesNumerosPossibles' está vacío. Asigna sprites en el Inspector.");
            return;
        }

        // Asignar un sprite aleatorio
        System.Random aleatorio = new System.Random();
        int colorBola = aleatorio.Next(0, spritesNumerosPossibles.Length);
        GetComponent<SpriteRenderer>().sprite = spritesNumerosPossibles[colorBola];

        // Generar número único
        textoBola = GetComponentInChildren<TextMeshProUGUI>();
        float numeroAleatorio = GenerarNumeroAleatorio();

        if (!numerosGenerados.Add(numeroAleatorio))
        {
            Debug.LogWarning("Número duplicado: " + numeroAleatorio);
            return;
        }

        // Mostrar el número
        if (textoBola != null)
            textoBola.text = numeroAleatorio.ToString("F2");
    }

    public static HashSet<float> ObtenerNumerosGenerados()
    {
        return numerosGenerados;
    }

    private float GenerarNumeroAleatorio()
    {
        float numero;
        do
        {
            numero = Mathf.Round(Random.Range(0f, 99f) * 100f) / 100f;
        } while (numerosGenerados.Contains(numero));
        return numero;
    }


}