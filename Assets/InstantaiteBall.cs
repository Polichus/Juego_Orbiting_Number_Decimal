using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantaiteBall : MonoBehaviour
{
    public GameObject ballInstance;
    
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(ballInstance);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
