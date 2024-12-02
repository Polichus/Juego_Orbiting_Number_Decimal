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
                             //public string numeroobjetivo;  // El n�mero objetivo como string
    /// <summary>
    /// public GameObject objetoAComparar;  // El objeto que quieres destruir al hacer la comparaci�n
    /// </summary>
    public Canvas canvasBolasGeneradas;
    void Start()
    {
        textoBolaCentral = GetComponentInChildren<TextMeshProUGUI>();

        if (textoBolaCentral == null)
        {
            Debug.LogError("Error: No se encontr� TextMeshProUGUI en el objeto central.");
            return;
        }

        StartCoroutine(EsperarYGenerarSuma());
        // canvasBolasGeneradas = GetComponent<Canvas>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // Convertir la posici�n del mouse a coordenadas del mundo
            Vector3 posicionMouseEnMundo = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            posicionMouseEnMundo.z = 0f;

            // Realizar un Raycast2D desde la posici�n del mouse
            RaycastHit2D hit = Physics2D.Raycast(posicionMouseEnMundo, Vector2.zero);

            if (hit.collider != null)
            {
                Debug.Log("Has hecho clic en: " + hit.collider.gameObject.name);

                // Intentar obtener el texto asociado a la bola clicada
                TextMeshProUGUI textoBola = hit.collider.gameObject.GetComponentInChildren<TextMeshProUGUI>();

                if (textoBola != null)
                {
                    // Intentar convertir el texto de la bola a un n�mero flotante
                    if (float.TryParse(textoBola.text, out float numeroBola))
                    {
                        // Comparar el n�mero de la bola con el n�mero objetivo
                        if (Mathf.Approximately(numeroBola, numeroObjetivo))
                        {
                            Debug.Log($"�N�mero correcto! {numeroBola}");

                            // Sumar 100 puntos cuando el n�mero de la bola es el objetivo
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
                            Debug.Log($"N�mero incorrecto: {numeroBola}, se esperaba {numeroObjetivo}");
                        }
                    }
                    else
                    {
                        Debug.LogError("El texto no se pudo convertir en n�mero.");
                    }
                }
                else
                {
                    Debug.LogWarning("No se encontr� texto en la bola clicada.");
                }
            }
            else
            {
                Debug.Log("No has clicado en ning�n objeto.");
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

                    Debug.Log("entra comparaci�n");

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
            // Esperar hasta que todas las bolas hayan generado sus n�meros
            while (Bola.ObtenerNumerosGenerados().Count < 10) // Cambiar 10 al n�mero total de bolas
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
                Debug.LogError("No hay suficientes n�meros generados en las bolas circundantes.");
                textoBolaCentral.text = "Error";
                return;
            }

            listaNumeros = numeros.ToList(); // Esto funcionar� ahora si has agregado 'using System.Linq'

            // Elegir un n�mero objetivo que coincida con una de las bolas
            numeroObjetivo = listaNumeros[Random.Range(0, listaNumeros.Count)];

            // Generar dos n�meros que sumen el n�mero objetivo
            float numero1 = Random.Range(0f, numeroObjetivo); // Primer n�mero
            float numero2 = numeroObjetivo - numero1;         // Segundo n�mero

            // Redondear ambos n�meros a dos decimales
            numero1 = Mathf.Round(numero1 * 100f) / 100f;
            numero2 = Mathf.Round(numero2 * 100f) / 100f;

            // Asegurar que los n�meros suman al objetivo y son v�lidos
            if (Mathf.Abs(numero1 + numero2 - numeroObjetivo) > 0.01f)
            {
                Debug.LogError("La suma generada no coincide con el n�mero objetivo.");
                textoBolaCentral.text = "Error";
                return;
            }
            Debug.Log(listaNumeros[1]);

            // Mostrar la operaci�n en la bola central
            textoBolaCentral.text = $"{numero1:F2} + {numero2:F2}";
        }
    }

