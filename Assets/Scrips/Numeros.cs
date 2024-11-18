using System.Collections;
using UnityEngine;

public class Numeros : MonoBehaviour
{
    public GameObject prefabNumero;   // Prefab de los n�meros
    public float tiempoEntreSpawns = 1.5f;
    private float minX;
    private float maxX;

    private void Start()
    {
        // Calcular l�mites de pantalla
        minX = Camera.main.ViewportToWorldPoint(new Vector2(0, 0)).x;
        maxX = Camera.main.ViewportToWorldPoint(new Vector2(0.75f, 0.75f)).x;  // Ajusta el 0.75f solo en el eje X

        // Iniciar el proceso de generaci�n de objetos como Coroutine
        GenerarNumeros();
    }

    private void GenerarNumeros()
    {
        for (int i = 0; i < 10; i++)
        {
            // Esperar antes de crear el siguiente objeto
            //yield return new WaitForSeconds(tiempoEntreSpawns);

            // Generar posici�n aleatoria en el eje X
            float posX = Random.Range(minX, maxX);
            Vector2 posicionSpawn = new Vector2(posX, transform.position.y);

            // Instanciar el prefab en la posici�n calculada y con la rotaci�n por defecto
            GameObject bola = Instantiate(prefabNumero);
            bola.transform.position = posicionSpawn;
        }
    }
}
