using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IniciarPartida : MonoBehaviour
{

    public void AnarAEscenaJugant()
    {
        SceneManager.LoadScene("Niveles");
    }

    public void AnarAEscenaInstrucciones()
    {
        SceneManager.LoadScene("Instrucciones");
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
