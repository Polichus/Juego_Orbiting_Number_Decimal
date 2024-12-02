using UnityEngine;
using TMPro;
using System.Collections.Generic;
using System.Collections;
using System.Linq;

public class BolaCentral : MonoBehaviour
{
    private TextMeshProUGUI textoBolaCentral;
    public Canvas canvasPuntos;
    private float numeroObjetivo;
    private int puntos = 0;
    List<float> listaNumeros;// Variable para almacenar los puntos
                             //public string numeroobjetivo;  // El número objetivo como string
    /// <summary>
    /// public GameObject objetoAComparar;  // El objeto que quieres destruir al hacer la comparación
    /// </summary>
    public Canvas canvasBolasGeneradas;
    void Start()
    {
        textoBolaCentral = GetComponentInChildren<TextMeshProUGUI>();

        if (textoBolaCentral == null)
        {
            Debug.LogError("Error: No se encontró TextMeshProUGUI en el objeto central.");
            return;
        }

        StartCoroutine(EsperarYGenerarSuma());
        // canvasBolasGeneradas = GetComponent<Canvas>();
    }

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

                if (textoBola != null)
                {
                    // Intentar convertir el texto de la bola a un número flotante
                    if (float.TryParse(textoBola.text, out float numeroBola))
                    {
                        // Comparar el número de la bola con el número objetivo
                        if (Mathf.Approximately(numeroBola, numeroObjetivo))
                        {
                            Debug.Log($"¡Número correcto! {numeroBola}");

                            // Sumar 100 puntos cuando el número de la bola es el objetivo
                            puntos += 100;

                            TextMeshProUGUI texto = canvasPuntos.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
                            texto.text = puntos.ToString();

                            // Destruir la bola (el GameObject principal) y todos sus hijos

                            destruisBola(hit.collider.transform.root.gameObject);
                            // Destruye la bola y sus hijos

                            // Mostrar los puntos actuales
                            Debug.Log("Puntos: " + puntos);
                        }
                        else
                        {
                            Debug.Log($"Número incorrecto: {numeroBola}, se esperaba {numeroObjetivo}");
                        }
                    }
                    else
                    {
                        Debug.LogError("El texto no se pudo convertir en número.");
                    }
                }
                else
                {
                    Debug.LogWarning("No se encontró texto en la bola clicada.");
                }
            }
            else
            {
                Debug.Log("No has clicado en ningún objeto.");
            }
        }
    }
    void destruisBola(GameObject bolaADestruir)
    {
        GameObject primerHijo = bolaADestruir.transform.GetChild(0).gameObject;
        //Canvas canvas = primerHijo.GetComponent<Canvas>();
        TextMeshProUGUI texto = primerHijo.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        string getTextTodelete = "";
        int idxPos = 0;
        if (texto != null)
        {
            Debug.Log("entra texto diff null");
            for (int i = 0; i < listaNumeros.Count; i++)
            {
                Debug.Log(listaNumeros[i]);
                Debug.Log("entra for ");
                if (texto.text == listaNumeros[i].ToString())
                {
                    idxPos = i;
                    getTextTodelete = listaNumeros[i].ToString();

                    Debug.Log("entra comparación");

                    //Destroy(texto);
                    Debug.Log("Destruido");
                }
            }
        }
        TextMeshProUGUI deleteText = canvasBolasGeneradas.transform.GetChild(idxPos).GetComponent<TextMeshProUGUI>();
        deleteText.text = " ";

        // if(deleteText.text == getTextTodelete)
        {
            // idxPos
            // }
            Destroy(bolaADestruir);
        }
    }
        IEnumerator EsperarYGenerarSuma()
        {
            // Esperar hasta que todas las bolas hayan generado sus números
            while (Bola.ObtenerNumerosGenerados().Count < 10) // Cambiar 10 al número total de bolas
            {
                yield return null;
            }

            GenerarOperacionQueCoincida();
        }

        void GenerarOperacionQueCoincida()
        {
            HashSet<float> numeros = Bola.ObtenerNumerosGenerados();

            if (numeros.Count < 1)
            {
                Debug.LogError("No hay suficientes números generados en las bolas circundantes.");
                textoBolaCentral.text = "Error";
                return;
            }

            listaNumeros = numeros.ToList(); // Esto funcionará ahora si has agregado 'using System.Linq'

            // Elegir un número objetivo que coincida con una de las bolas
            numeroObjetivo = listaNumeros[Random.Range(0, listaNumeros.Count)];

            // Generar dos números que sumen el número objetivo
            float numero1 = Random.Range(0f, numeroObjetivo); // Primer número
            float numero2 = numeroObjetivo - numero1;         // Segundo número

            // Redondear ambos números a dos decimales
            numero1 = Mathf.Round(numero1 * 100f) / 100f;
            numero2 = Mathf.Round(numero2 * 100f) / 100f;

            // Asegurar que los números suman al objetivo y son válidos
            if (Mathf.Abs(numero1 + numero2 - numeroObjetivo) > 0.01f)
            {
                Debug.LogError("La suma generada no coincide con el número objetivo.");
                textoBolaCentral.text = "Error";
                return;
            }
            Debug.Log(listaNumeros[1]);

            // Mostrar la operación en la bola central
            textoBolaCentral.text = $"{numero1:F2} + {numero2:F2}";
        }
    }

