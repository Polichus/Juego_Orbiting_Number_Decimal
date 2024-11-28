using UnityEngine;
using TMPro;

public class PrefabTextManager : MonoBehaviour
{
    public string canvasTag = "MainCanvas"; // Etiqueta para identificar el Canvas
    public TextMeshProUGUI prefabText;     // Referencia al TextMeshProUGUI del prefab

    private Transform canvasTransform;     // Transform del Canvas principal
    private TextMeshProUGUI textInstance;  // Instancia del texto en el Canvas
    public Bola bola;
    
    void Start()
    {
        // Buscar el Canvas en la escena
        bola = GetComponent<Bola>();
        GameObject canvas = GameObject.FindGameObjectWithTag(canvasTag);
        if (canvas == null)
        {
            Debug.LogError("No se encontr� un Canvas con la etiqueta " + canvasTag);
            return;
        }

        // Guardar la referencia al transform del Canvas
        canvasTransform = canvas.transform;

        // Verificar que el prefab tiene un componente TextMeshProUGUI asignado
        if (prefabText == null)
        {
            Debug.LogError("El campo Prefab Text no est� asignado. Aseg�rate de asignar un TextMeshProUGUI en el prefab.");
            return;
        }

        // Crear una instancia del texto en el Canvas
        textInstance = Instantiate(prefabText, canvasTransform);
        textInstance.text = bola.GenerarNumeroAleatorio().ToString(); // Texto inicial
        textInstance.fontSize = 30;            // Tama�o del texto
        textInstance.color = Color.black;        // Color del texto

        // Actualizar la posici�n inicial del texto
        UpdateTextPosition();
    }

    void Update()
    {
        // Mantener el texto sincronizado con la posici�n del prefab
        UpdateTextPosition();
    }

    private void UpdateTextPosition()
    {
        if (textInstance != null)
        {
            // Convertir la posici�n mundial del prefab a posici�n de pantalla
            Vector3 screenPosition = Camera.main.WorldToScreenPoint(transform.position);
            textInstance.rectTransform.position = screenPosition;
        }
    }
}



