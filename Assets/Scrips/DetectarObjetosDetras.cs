using UnityEngine;

public class DetectarObjetoDetras : MonoBehaviour
{
    void Update()
    {
        // Detectar si se hace clic con el bot�n izquierdo del rat�n
        if (Input.GetMouseButtonDown(0))
        {
            // Crear un rayo desde la posici�n de la c�mara hacia el punto donde se hizo clic
            Ray rayo = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;

            // Realizar el raycast
            if (Physics.Raycast(rayo, out hitInfo))
            {
                // Mostrar en el debug el nombre del objeto clicado
                Debug.Log("Has hecho clic en: " + hitInfo.collider.gameObject.name);
            }
            else
            {
                Debug.Log("No has clicado en ning�n objeto.");
            }
        }
    }
}