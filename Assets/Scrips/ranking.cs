using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ranking : MonoBehaviour
{

    public void AnarEscenaRanking()
    {
        SceneManager.LoadScene("ranking");
    }

    public void AnarEscenaResultados()
    {
        SceneManager.LoadScene("Resultado");
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
