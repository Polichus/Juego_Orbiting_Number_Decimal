using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    // Prefab del objeto a instanciar
    public GameObject prefabNumero;

    // Límites de la pantalla en el eje X e Y
    private Vector2 posMin;
    private Vector2 posMax;
    private List<GameObject> listaBolas;

    private void Start()
    {
        // Inicializar la lista antes de usarla
        listaBolas = new List<GameObject>();

        // Obtener límites de la pantalla en el eje X e Y
        posMin = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));        // Esquina inferior izquierda
        posMax = Camera.main.ViewportToWorldPoint(new Vector2(0.80f, 0.80f)); // Límites visibles (80% del viewport)

        // Empezar a generar objetos repetidamente
        GenerarNumeros();
    }

    private void GenerarNumeros()
    {
        for (int i = 0; i < 16; i++) // Generar 16 bolas
        {
            // Generar una posición aleatoria dentro de los límites de la pantalla
            float posX = Random.Range(posMin.x, posMax.x);
            float posY = Random.Range(posMin.y, posMax.y);
            Vector2 posicionSpawn = new Vector2(posX, posY);

            // Instanciar el prefab en la posición aleatoria
            GameObject numero = Instantiate(prefabNumero);
            numero.transform.position = posicionSpawn;

            // Agregar el objeto instanciado a la lista
            listaBolas.Add(numero);

            // Mover la bola si está encima de otras
            MoverBolaSiEstaEncimaDeOtras(numero);
        }
    }

    private void MoverBolaSiEstaEncimaDeOtras(GameObject bolaActual)
    {
        for (int i = 0; i < listaBolas.Count; i++)
        {
            GameObject otraBola = listaBolas[i];

            // Evitar comparar la bola consigo misma
            if (bolaActual == otraBola) continue;

            Vector2 distancia = bolaActual.transform.position - otraBola.transform.position;
            float modulDistancia = distancia.magnitude;

            // Si las bolas están demasiado cerca, mover la actual
            if (modulDistancia < 1.5f)
            {
                // Asegurarse de que la nueva posición esté dentro de los límites
                float nuevoX = Mathf.Clamp(bolaActual.transform.position.x + 1.5f, posMin.x, posMax.x);
                float nuevoY = Mathf.Clamp(bolaActual.transform.position.y, posMin.y, posMax.y);

                bolaActual.transform.position = new Vector2(nuevoX, nuevoY);

                // Volver a comprobar por si sigue estando demasiado cerca de otra bola
                i = -1; // Reinicia el bucle para verificar todas las bolas nuevamente
            }
        }
    }
}

