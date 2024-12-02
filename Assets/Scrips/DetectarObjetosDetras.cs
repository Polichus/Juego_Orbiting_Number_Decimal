using UnityEngine;

public class DetectarObjetoDetras : MonoBehaviour
{
    void Update()
    {
        // Detectar si se hace clic con el botón izquierdo del ratón
        if (Input.GetMouseButtonDown(0))
        {
            // Crear un rayo desde la posición de la cámara hacia el punto donde se hizo clic
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
                Debug.Log("No has clicado en ningún objeto.");
            }
        }
    }
}