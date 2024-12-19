using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class BolaCentral : MonoBehaviour
{
    private TextMeshProUGUI textoBolaCentral;
    public Canvas canvasPuntos;
    private float numeroObjetivo;
    private int puntos = 0;// Variable para almacenar los puntos
    public List<float> listaNumeros;
    //public string numeroobjetivo;  // El número objetivo como string
    /// <summary>
    /// public GameObject objetoAComparar;  // El objeto que quieres destruir al hacer la comparación
    /// </summary>
    public List<string> calculo = new List<string>();
    private int indiceActual = 0;
    public Canvas canvasBolasGeneradas;
    public List<float> numero1List = new List<float>();
    public List<float> numero2List = new List<float>();
    public float currentResult;

    public TextMeshProUGUI textoVidas;
    public TextMeshProUGUI textoOperacionNueva;
    TextMeshProUGUI[] textos;
   // public GameObject globalCanvas;
    void Start()
    {
        textoBolaCentral = GetComponentInChildren<TextMeshProUGUI>();
        textos = canvasBolasGeneradas.GetComponentsInChildren<TextMeshProUGUI>();

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
                    //string cleanedText = textoBola.text.Trim();
                    // Intentar convertir el texto de la bola a un número flotante



                    /*
                     *MIRAR ESTA CONDICIÓN!!!! 
                     */
                    if (float.TryParse(textoBola.text, out float numeroBola))
                    //--------------------------------------------------------------------------------------------------
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
                            AccederSiguiente();
                            // Destruye la bola y sus hijos

                            // Mostrar los puntos actuales
                            Debug.Log("Puntos: " + puntos);

                            // Treure el número correcte clicat, de la llista de números disponibles.
                            Bola.numerosGenerados.Remove(numeroBola);

                            // Generar operació nova.
                            GenerarOperacionQueCoincida();

                        }
                        else
                        {
                            Debug.Log($"Número incorrecto: {numeroBola}, se esperaba {numeroObjetivo}");
                            // Restar una vida.
                            int numVides = int.Parse(textoVidas.text);
                            numVides--;
                            textoVidas.text = numVides.ToString();
                            if(numVides <= 0)
                            {
                                textoVidas.text = "Game Over";
                                Debug.Log("¡Juego Terminado!");

                                // Desactivar la lógica del juego deshabilitando el script.
                                this.enabled = false;
                            }
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
       //float number = float.Parse(texto.text); 
       /*
        * 
        * COMPARA ENTRE LISTA NÚMEROS Y EL TEXTO DE LA PELOTA, OBTENEMOS EL INDICE PUESTO QUE TEXTOS ES UNA ARRAY QUE RECOGE LOS TEXTOS DEL CANVAS GLOBAL
        * Y LE ASIGNAMOS EL INDICE PARA ELIMINAR SU TEXTO.
        * 
        * */
        texto.text = " ";
        int index = listaNumeros.FindIndex(num => num.ToString().Contains(texto.text));
        listaNumeros.Remove(index);
        textos[index].text = "";

        //--------------------------------------------------------------------------------------------------

        Destroy(textos[index]);

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
                    currentResult = listaNumeros[i];
                    getTextTodelete = listaNumeros[i].ToString();
                    texto.text = " ";
                    TextMeshProUGUI deleteText = canvasBolasGeneradas.transform.GetChild(idxPos).GetComponent<TextMeshProUGUI>();
                    deleteText.text = " ";
                    Debug.Log("entra comparación");

                    //Destroy(texto);
                    Debug.Log("Destruido");
                }
            }
        }
       

        // if(deleteText.text == getTextTodelete)
        
            // idxPos
            // }
            Destroy(bolaADestruir);
           
            //AccederSiguienteElemento(calculo);


        

    }

    void AccederSiguiente()
    {
        float result = 0;
        for(int i = 0; i < listaNumeros.Count; i++)
        {
            //result = numero1List[i] + numero2List[i];
            if(result == currentResult)
            {
                Debug.Log("correcto");
            }
        }
    }
   /* public void AccederSiguienteElemento(List<string> listCalculos)
    {

        // Verifica si el siguiente índice está dentro del rango
        if (indiceActual + 1 < listCalculos.Count)
        {
            indiceActual++;
            Debug.Log("Siguiente elemento: " + listCalculos[indiceActual]);
        }
        else
        {
            Debug.Log("Ya estás en el último elemento.");
        }
        // textoBolaCentral.text = " ";
        textoBolaCentral.text = listCalculos[indiceActual];

        //GenerarOperacionQueCoincida();

    }*/
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
        Debug.Log(numeros);

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
        numero1List.Add(numero1);
        numero2List.Add(numero2);
        // string calculoMatematico = numero1.ToString() +"+"+ numero2.ToString();
        //calculo.Add(calculoMatematico);
        // Asegurar que los números suman al objetivo y son válidos
        if (Mathf.Abs(numero1 + numero2 - numeroObjetivo) > 0.01f)
        {
            Debug.LogError("La suma generada no coincide con el número objetivo.");
            textoBolaCentral.text = "Error";
            return;
        }



        Debug.Log(listaNumeros[1]);
        //Debug.Log(calculo[0]);
        // Mostrar la operación en la bola central
        textoBolaCentral.text = $"{numero1:F2} + {numero2:F2}";
    }

}