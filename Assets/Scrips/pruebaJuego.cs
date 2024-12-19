using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class pruebaJuego : MonoBehaviour
{
    int puntos = 0;
    TextMeshProUGUI[] textos;
    private float numeroObjetivo;
    public TextMeshProUGUI textoVidas;
    private TextMeshProUGUI textoBolaCentral;
    public List<float> listaNumeros;
    public List<float> numero1List = new List<float>();
    public List<float> numero2List = new List<float>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // Convertir la posición del mouse a coordenadas del mundo
            Vector3 posicionMouseEnMundo = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            posicionMouseEnMundo.z = 0f;

            // Realizar un Raycast2D desde la posición del mouse
            RaycastHit2D hit = Physics2D.Raycast(posicionMouseEnMundo, Vector2.zero);

            if (hit.collider != null)
            {
                Debug.Log("Has hecho clic en: " + hit.collider.gameObject.name);

                // Intentar obtener el texto asociado a la bola clicada
                TextMeshProUGUI textoBola = hit.collider.gameObject.GetComponentInChildren<TextMeshProUGUI>();

                if (textoBola != null && float.TryParse(textoBola.text, out float numeroBola))
                {
                    // Verificar si el número coincide con el número objetivo
                    if (Mathf.Approximately(numeroBola, numeroObjetivo))
                    {
                        Debug.Log($"¡Número correcto! {numeroBola}");

                        // Destruir el objeto seleccionado
                        Destroy(hit.collider.gameObject);

                        // Generar una nueva operación matemática
                        GenerarOperacionQueCoincida();
                    }
                    else
                    {
                        Debug.Log($"Número incorrecto: {numeroBola}, se esperaba {numeroObjetivo}");
                    }
                }
                else
                {
                    Debug.LogWarning("No se encontró texto válido en la bola clicada.");
                }
            }
            else
            {
                Debug.Log("No has clicado en ningún objeto.");
            }
        }
    }


    bool ValidarOperacion(float numeroClicado)
    {
        return Mathf.Approximately(numeroClicado, numeroObjetivo);
    }


    void destruisBola(GameObject bolaADestruir)
    {
        // Obtener el texto de la bola clicada
        TextMeshProUGUI textoBola = bolaADestruir.GetComponentInChildren<TextMeshProUGUI>();

        if (textoBola != null)
        {
            // Buscar y eliminar el texto correspondiente en el Canvas Global
            for (int i = 0; i < textos.Length; i++)
            {
                if (textos[i].text == textoBola.text)
                {
                    // Borrar texto del canvas global
                    textos[i].text = "";
                    Debug.Log($"Texto eliminado del canvas global: {textos[i].name}");
                    break;
                }
            }
        }

        // Destruir la bola clicada
        Destroy(bolaADestruir);
        Debug.Log("Bola destruida.");
    }
    void RestarVida()
    {
        int numVidas = int.Parse(textoVidas.text);
        numVidas--;
        textoVidas.text = numVidas.ToString();

        if (numVidas <= 0)
        {
            textoVidas.text = "Game Over";
            Debug.Log("¡Juego Terminado!");
            this.enabled = false; // Detener el script
        }
    }

   

    void GenerarOperacionQueCoincida()
    {
        if (Bola.ObtenerNumerosGenerados().Count < 1)
        {
            Debug.LogError("No hay suficientes números generados.");
            textoBolaCentral.text = "Error";
            return;
        }

        listaNumeros = Bola.ObtenerNumerosGenerados().ToList();
        numeroObjetivo = listaNumeros[Random.Range(0, listaNumeros.Count)];

        float numero1 = Random.Range(0f, numeroObjetivo);
        float numero2 = numeroObjetivo - numero1;

        numero1 = Mathf.Round(numero1 * 100f) / 100f;
        numero2 = Mathf.Round(numero2 * 100f) / 100f;

        numero1List.Add(numero1);
        numero2List.Add(numero2);

        textoBolaCentral.text = $"{numero1:F2} + {numero2:F2}";
        Debug.Log($"Nueva operación generada: {textoBolaCentral.text}");
    }



}
