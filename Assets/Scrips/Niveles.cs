using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Niveles : MonoBehaviour
{
    public void AnarAEscenaInicio()
    {
        SceneManager.LoadScene("PantallaInicial");
    }

    public void AnarAEscenaNivel1()
    {
        SceneManager.LoadScene("Nivel");
    }

    public void AnarAEscenaNivel3()
    {
        SceneManager.LoadScene("Nivel3");
    }

        public void AnarEscenaNivel2()
        {
            SceneManager.LoadScene("Nivel2");

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

