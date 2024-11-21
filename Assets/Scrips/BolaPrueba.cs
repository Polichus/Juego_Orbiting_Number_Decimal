using UnityEngine;

public class BolaPrueba : MonoBehaviour
{
    // Esta funci�n se llama autom�ticamente cuando hacemos clic en el objeto con un Collider
    void OnMouseDown()
    {
        // Al hacer clic, cambiar� el color del objeto a amarillo
        GetComponent<Renderer>().material.color = Color.yellow;

        // Destruir el objeto despu�s de 0.5 segundos para simular una "explosi�n"
        Destroy(gameObject, 0.5f);

        // Mensaje de depuraci�n para verificar que el clic fue detectado
        Debug.Log("�Bola clickeada y destruida!");
    }
}
