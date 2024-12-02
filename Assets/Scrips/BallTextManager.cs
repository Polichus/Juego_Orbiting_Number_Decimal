using UnityEngine;
using TMPro; // Aseg�rate de tener TextMeshPro importado desde el Package Manager.

public class BallTextManager : MonoBehaviour
{
    public TextMeshProUGUI textMesh; // Arrastra el componente de texto aqu�

    void Start()
    {
        // Verifica si el componente de texto est� asignado
        if (textMesh == null || textMesh.text == " ")
        {
            Debug.LogError("El componente de texto no est� asignado en el prefab.");
            return;
        }

        // Texto inicial
        textMesh.text = "�Hola!";
    }

    public void UpdateText(string newText)
    {
        // Cambiar el texto en tiempo de ejecuci�n
        if (textMesh != null)
        {
            textMesh.text = newText;
        }
        else
        {
            Debug.LogError("El componente de texto no est� asignado.");
        }
    }
}