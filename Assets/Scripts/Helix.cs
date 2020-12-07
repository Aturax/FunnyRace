using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Helix : MonoBehaviour
{

    [SerializeField]
    float speed;
    [SerializeField]
    GameObject engine;

    void Update()
    {
        engine.transform.Rotate(Vector3.up * speed * Time.deltaTime);
    }
}
