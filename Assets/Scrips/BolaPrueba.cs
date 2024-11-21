using UnityEngine;

public class BolaPrueba : MonoBehaviour
{
    // Esta función se llama automáticamente cuando hacemos clic en el objeto con un Collider
    void OnMouseDown()
    {
        // Al hacer clic, cambiará el color del objeto a amarillo
        GetComponent<Renderer>().material.color = Color.yellow;

        // Destruir el objeto después de 0.5 segundos para simular una "explosión"
        Destroy(gameObject, 0.5f);

        // Mensaje de depuración para verificar que el clic fue detectado
        Debug.Log("¡Bola clickeada y destruida!");
    }
}
