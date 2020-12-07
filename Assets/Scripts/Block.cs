using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField]
    float speed;
    
    void Start()
    {

        

    }


    // Update is called once per frame
    void Update()
    {
        
        transform.Translate(Mathf.Cos(Time.time) * Time.deltaTime * speed, 0, 0);
        
    }
}
