using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    // Prefab del objeto a instanciar
    public GameObject prefabNumero;

    // L�mites de la pantalla en el eje X e Y
    private Vector2 posMin;
    private Vector2 posMax;
    private List<GameObject> listaBolas;

    // Separaci�n m�nima entre bolas, bordes y la bola central
    public float separacionEntreBolas = 1.5f; // Espacio entre bolas
    public float separacionBordes = 0.5f;    // Espacio entre bordes y bolas
    public float separacionBolaCentral = 2.5f; // Espacio alrededor de la bola central

    // Posici�n de la bola central
    public Vector2 posicionBolaCentral;

    private void Start()
    {
        // Inicializar la lista antes de usarla
        listaBolas = new List<GameObject>();

        // Obtener l�mites de la pantalla en el eje X e Y, ajustando por la separaci�n con los bordes
        posMin = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        posMax = Camera.main.ViewportToWorldPoint(new Vector2(0.80f, 0.80f));

        // Ajustar l�mites para dejar espacio entre las bolas y los bordes
        posMin += new Vector2(separacionBordes, separacionBordes);
        posMax -= new Vector2(separacionBordes, separacionBordes);

        // Definir la posici�n de la bola central (puedes ajustar esto seg�n tu escena)
        posicionBolaCentral = new Vector2(0, 0); // Cambiar si la bola central est� en otro lugar

        // Empezar a generar objetos repetidamente
        GenerarNumeros();
    }

    private void GenerarNumeros()
    {
        for (int i = 0; i < 16; i++) // Generar 16 bolas
        {
            Vector2 posicionSpawn;
            bool posicionValida;

            // Generar una posici�n aleatoria dentro de los l�mites hasta encontrar una v�lida
            do
            {
                float posX = Random.Range(posMin.x, posMax.x);
                float posY = Random.Range(posMin.y, posMax.y);
                posicionSpawn = new Vector2(posX, posY);

                posicionValida = VerificarSeparacion(posicionSpawn);
            } while (!posicionValida);

            // Instanciar el prefab en la posici�n v�lida
            GameObject numero = Instantiate(prefabNumero);
            numero.transform.position = posicionSpawn;

            // Agregar el objeto instanciado a la lista
            listaBolas.Add(numero);
        }
    }

    private bool VerificarSeparacion(Vector2 posicion)
    {
        // Verificar si la posici�n est� suficientemente separada de la bola central
        float distanciaCentral = Vector2.Distance(posicion, posicionBolaCentral);
        if (distanciaCentral < separacionBolaCentral)
        {
            return false; // Posici�n no v�lida si est� demasiado cerca de la bola central
        }

        // Verificar si la posici�n est� suficientemente separada de otras bolas
        foreach (GameObject bola in listaBolas)
        {
            float distancia = Vector2.Distance(posicion, bola.transform.position);
            if (distancia < separacionEntreBolas)
            {
                return false; // Posici�n no v�lida si est� demasiado cerca de otra bola
            }
        }

        return true; // Posici�n v�lida
    }
}



