using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public GameObject prefabNumero;
    public GameObject camera;
    public GameObject instantiateObject;

    float x; 
    float y;

    public GameObject[] ballList;
    Vector2 pos;
    List<GameObject> listaBolas;
    Vector2 posMax;
    Vector2 posMin;
    // Start is called before the first frame update

    private void Awake()
    {
        x = Random.Range(0.0f, 0.85f);
        y = Random.Range(0.0f, 0.85f);
        camera = GameObject.FindGameObjectWithTag("MainCamera");
    }
    void Start()
    {
        // Reinicia el random para que te de otra pos;
        // El pos sería i.transform.position = SetRandomPosAndPlaceInsideCameraViewPort(x,y); 
        pos = SetRandomPosAndPlaceInsideCameraViewPort(x,y);
        Instantiate(instantiateObject, pos,Quaternion.identity);
        generarNumeros();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Vector2 SetRandomPosAndPlaceInsideCameraViewPort(float x, float y)
    {
        pos = new Vector2(x, y);
        pos=camera.GetComponent<Camera>().ViewportToWorldPoint(pos);
        return pos;
    }

    public void generarNumeros()
    {
        //Debug.Log(ballList.Length);
        for (int i = 0; i < ballList.Length; i++) // Generar 16 bolas
        {
            
            // Generar una posición aleatoria dentro de los límites de la pantalla
            float posX = Random.Range(posMin.x, posMax.x);
            float posY = Random.Range(posMin.y, posMax.y);
            Vector2 posicionSpawn = new Vector2(posX, posY);


            // Instanciar el prefab en la posición aleatoria
            GameObject numero = Instantiate(ballList[i],SetRandomPosAndPlaceInsideCameraViewPort(posX,posY),Quaternion.identity);
            //Vector2 posToAvoidOverlap = MoverBolaSiEstaEncimaDeOtras(prefabNumero);
            numero.transform.position = posicionSpawn * posicionSpawn;

            // Agregar el objeto instanciado a la lista
            listaBolas.Add(numero);
            //listaBolasColliders.Add(numero.GetComponent<Collider2D>());
            // Mover la bola si está encima de otras
           // Vector2 posCam = Camera.main.ViewportToWorldPoint((Vector2)posToAvoidOverlap);
            //MoverBolaSiEstaEncimaDeOtras(numero);
           
        }
    }
    

}
