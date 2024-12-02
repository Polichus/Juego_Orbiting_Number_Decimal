using UnityEngine;
using TMPro; // Asegúrate de tener TextMeshPro importado desde el Package Manager.

public class BallTextManager : MonoBehaviour
{
    public TextMeshProUGUI textMesh; // Arrastra el componente de texto aquí

    void Start()
    {
        // Verifica si el componente de texto está asignado
        if (textMesh == null || textMesh.text == " ")
        {
            Debug.LogError("El componente de texto no está asignado en el prefab.");
            return;
        }

        // Texto inicial
        textMesh.text = "¡Hola!";
    }

    public void UpdateText(string newText)
    {
        // Cambiar el texto en tiempo de ejecución
        if (textMesh != null)
        {
            textMesh.text = newText;
        }
        else
        {
            Debug.LogError("El componente de texto no está asignado.");
        }
    }
}