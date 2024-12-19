using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class scriptCopia : MonoBehaviour
{
  /*  private TextMeshProUGUI textoBolaCentral;
    public Canvas canvasPuntos;
    private float numeroObjetivo;
    private int puntos = 0; // Variable para almacenar los puntos
    public List<float> listaNumeros;
    public List<string> listaEnunciados; // Nueva lista para almacenar enunciados
    private int indiceActual = 0;
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
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 posicionMouseEnMundo = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            posicionMouseEnMundo.z = 0f;

            RaycastHit2D hit = Physics2D.Raycast(posicionMouseEnMundo, Vector2.zero);

            if (hit.collider != null)
            {
                TextMeshProUGUI textoBola = hit.collider.gameObject.GetComponentInChildren<TextMeshProUGUI>();

                if (textoBola != null && float.TryParse(textoBola.text, out float numeroBola))
                {
                    if (Mathf.Approximately(numeroBola, numeroObjetivo))
                    {
                        Debug.Log($"¡Número correcto! {numeroBola}");
                        puntos += 100;

                        TextMeshProUGUI texto = canvasPuntos.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
                        texto.text = puntos.ToString();

                        destruisBola(hit.collider.transform.root.gameObject);

                        Debug.Log("Puntos: " + puntos);
                    }
                    else
                    {
                        Debug.Log($"Número incorrecto: {numeroBola}, se esperaba {numeroObjetivo}");
                    }
                }
            }
        }
    }

    void destruisBola(GameObject bolaADestruir)
    {
        TextMeshProUGUI texto = bolaADestruir.transform.GetChild(0).GetComponentInChildren<TextMeshProUGUI>();

        if (texto != null)
        {
            for (int i = 0; i < listaNumeros.Count; i++)
            {
                if (Mathf.Approximately(float.Parse(texto.text), listaNumeros[i]))
                {
                    listaNumeros.RemoveAt(i);
                    listaEnunciados.RemoveAt(i); // Eliminar el enunciado correspondiente
                    Debug.Log($"Número y enunciado eliminados en el índice {i}");
                    break;
                }
            }
        }

        Destroy(bolaADestruir);
        AccederSiguienteElemento();
    }

    public void AccederSiguienteElemento()
    {
        if (listaEnunciados.Count > 0)
        {
            Debug.Log($"Siguiente enunciado: {listaEnunciados[0]}");
            textoBolaCentral.text = listaEnunciados[0];
        }
        else
        {
            Debug.Log("No hay más enunciados.");
            textoBolaCentral.text = "¡Completado!";
        }
    }

    IEnumerator EsperarYGenerarSuma()
    {
        while (Bola.ObtenerNumerosGenerados().Count < 16) // Asegurar que sean 16 números
        {
            yield return null;
        }

        GenerarOperacionQueCoincida();
    }

    void GenerarOperacionQueCoincida()
    {
        HashSet<float> numeros = Bola.ObtenerNumerosGenerados();

        if (numeros.Count < 16)
        {
            Debug.LogError("No hay suficientes números generados.");
            textoBolaCentral.text = "Error";
            return;
        }

        listaNumeros = numeros.ToList();
        listaEnunciados = new List<string>();

        foreach (var numero in listaNumeros)
        {
            string enunciado = $"Selecciona el número {numero:F2}";
            listaEnunciados.Add(enunciado);
        }

        // Mostrar el primer enunciado
        textoBolaCentral.text = listaEnunciados[0];
    }*/
}

