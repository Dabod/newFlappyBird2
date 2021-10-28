using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicaObstaculo : MonoBehaviour
{
    public float velocidad = 1;
    public GameObject suelo;

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.left * velocidad * Time.deltaTime;
    }
}
